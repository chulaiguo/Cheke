using System.Collections.Generic;
using System.Reflection;
using Cheke.BusinessEntity;
using Cheke.ClientSide;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using Cheke.WinCtrl.GridControlCommand;

namespace Cheke.WinCtrl.GridGroupBuddy
{
    public delegate BusinessBase CreateRightEntityDelegate(BusinessBase leftEntity);

    public delegate bool CompareEntityDelegate(BusinessBase left, BusinessBase right);

    public delegate bool CanMoveLeftToRightDelegate(BusinessBase left);

    public delegate bool CanMoveRightToLeftDelegate(BusinessBase right);

    public class GroupOperator
    {
        public CreateRightEntityDelegate CreateRightEntity;
        public CompareEntityDelegate CompareEntity;
        public CanMoveLeftToRightDelegate CanMoveLeftToRight;
        public CanMoveRightToLeftDelegate CanMoveRightToLeft;

        private string _userId = string.Empty;
        private readonly GridControl _gridControlLeft = null;
        private readonly GridControl _gridControlRight = null;

        private BusinessCollectionBase _leftDeletedList = null;

        public GroupOperator(GridControl gridControlLeft, GridControl gridControlRight)
        {
            this._gridControlLeft = gridControlLeft;
            this._gridControlRight = gridControlRight;
        }

        #region Properties

        private BusinessCollectionBase LeftDataSource
        {
            get { return this._gridControlLeft.DataSource as BusinessCollectionBase; }
        }

        private BusinessCollectionBase RightDataSource
        {
            get { return this._gridControlRight.DataSource as BusinessCollectionBase; }
        }

        private GridView GridViewLeft
        {
            get { return this._gridControlLeft.MainView as GridView; }
        }

        private GridView GridViewRight
        {
            get { return this._gridControlRight.MainView as GridView; }
        }

        private BusinessCollectionBase LeftDeletedList
        {
            get
            {
                if (this._leftDeletedList == null)
                {
                    this._leftDeletedList = Activator.CreateInstance(this.LeftDataSource.GetType()) as BusinessCollectionBase;
                }

                return this._leftDeletedList;
            }
        }

        #endregion

        public void SetDataSource(string userId, BusinessCollectionBase left, BusinessCollectionBase right)
        {
            this._userId = userId;

            this._gridControlLeft.DataSource = left;
            this.GridViewLeft.BestFitColumns();
            GridMenuFacade.RestoreLayoutFromFile(this._userId, this._gridControlLeft, this.GridViewLeft);

            this._gridControlRight.DataSource = right;
            this.GridViewRight.BestFitColumns();
            GridMenuFacade.RestoreLayoutFromFile(this._userId, this._gridControlRight, this.GridViewRight);

            this.RefreshGridControl();
        }

        public void MoveLeftToRight()
        {
            if (!this.IsReady)
                return;

            List<BusinessBase> list = GetSelectionList(this.GridViewLeft);
            foreach (BusinessBase left in list)
            {
                if(!this.CanMoveLeftToRight(left))
                    continue;

                this.DeleteLeftEntity(left);

                BusinessBase right = this.GetRightEntity(left);
                if (right != null)
                {
                    this.RightDataSource.Add(right);
                    this.GridViewRight.UpdateCurrentRow();
                    this.GridViewRight.BestFitColumns();
                }
            }
        }

        public void MoveRightToLeft()
        {
            if (!this.IsReady)
                return;

            List<BusinessBase> list = this.GetSelectionList(this.GridViewRight);
            foreach (BusinessBase right in list)
            {
                if (!this.CanMoveRightToLeft(right))
                    continue;

                this.DeleteRightEntity(right);

                BusinessBase left = this.GetLeftEntity(right);
                if (left != null)
                {
                    this.LeftDataSource.Add(left);
                }
            }
        }

        public BusinessBase GetLeftByRight(BusinessBase right)
        {
            foreach (BusinessBase left in this.LeftDeletedList)
            {
                if (this.CompareLeftAndRight(left, right))
                {
                    left.AcceptChanges();
                    return left;
                }
            }

            return null;
        }

        public void RefreshGridControl()
        {
            if (!this.IsReady)
                return;

            this.LeftDeletedList.Clear();
            this.LeftDeletedList.AcceptChanges();
            foreach (BusinessBase left in this.LeftDataSource)
            {
                foreach (BusinessBase right in this.RightDataSource)
                {
                    if (this.CompareLeftAndRight(left, right))
                    {
                        this.LeftDeletedList.Add(left);
                        break;
                    }
                }
            }

            foreach (BusinessBase entity in this.LeftDeletedList)
            {
                this.LeftDataSource.Remove(entity);
            }

            this.LeftDataSource.AcceptChanges();
        }

        public bool ReplaceData(BusinessBase entity)
        {
            if(this.LeftDataSource == null || this.RightDataSource == null)
                return false;

            if (this.ReplaceParentData(entity))
                return true;

            if(this.ReplaceLeftData(entity))
                return true;

            if (this.ReplaceRightData(entity))
                return true;

            return false;
        }

        private bool ReplaceParentData(BusinessBase parent)
        {
            PropertyInfo leftParent = EntityUtility.GetParentProperty(this.LeftDataSource.GetItemType(), parent.GetType());
            if (leftParent == null)
                return false;

            PropertyInfo rightParent = EntityUtility.GetParentProperty(this.RightDataSource.GetItemType(), parent.GetType());
            if (rightParent == null)
                return false;

            if(parent.IsDeleted)
            {
                List<BusinessBase> deletedList = new List<BusinessBase>();

                //left list
                foreach (BusinessBase item in this.LeftDataSource)
                {
                    if (parent.Equals(leftParent.GetValue(item, null)))
                    {
                        deletedList.Add(item);
                    }
                }

                foreach (BusinessBase item in deletedList)
                {
                    this.LeftDataSource.Remove(item);
                    this.LeftDataSource.AcceptChanges(item.ObjectID);
                }

                //deleted list
                deletedList.Clear();
                foreach (BusinessBase item in this.LeftDeletedList)
                {
                    if (parent.Equals(leftParent.GetValue(item, null)))
                    {
                        deletedList.Add(item);
                    }
                }

                foreach (BusinessBase item in deletedList)
                {
                    this.LeftDeletedList.Remove(item);
                    this.LeftDeletedList.AcceptChanges(item.ObjectID);
                }

                //right list
                deletedList.Clear();
                foreach (BusinessBase item in this.RightDataSource)
                {
                    if (parent.Equals(rightParent.GetValue(item, null)))
                    {
                        deletedList.Add(item);
                    }
                }

                foreach (BusinessBase item in deletedList)
                {
                    this.RightDataSource.Remove(item);
                    this.RightDataSource.AcceptChanges(item.ObjectID);
                }
            }
            else
            {
                //left list
                foreach (BusinessBase item in this.LeftDataSource)
                {
                    EntityUtility.ReplaceParent(item, leftParent, parent);
                }

                //deleted list
                foreach (BusinessBase item in this.LeftDeletedList)
                {
                    EntityUtility.ReplaceParent(item, leftParent, parent);
                }

                //right list
                foreach (BusinessBase item in this.RightDataSource)
                {
                    EntityUtility.ReplaceParent(item, rightParent, parent);
                }
            }

            return true;
        }

        private bool ReplaceLeftData(BusinessBase entity)
        {
            if(entity.GetType() != this.LeftDataSource.GetItemType())
                return false;

            int index = this.LeftDataSource.IndexOf(entity);
            if (index > -1)
            {
                if (entity.IsDeleted)
                {
                    this.LeftDataSource.RemoveAt(index);
                    this.LeftDataSource.AcceptChanges();
                }
                else
                {
                    (this.LeftDataSource[index] as BusinessBase).CopyFrom(entity, true);
                }
            }
            else
            {
                index = this.LeftDeletedList.IndexOf(entity);
                if (index > -1)
                {
                    BusinessBase right = this.FindRightEntity(entity);
                    if (entity.IsDeleted)
                    {
                        this.LeftDeletedList.RemoveAt(index);
                        this.LeftDeletedList.AcceptChanges();

                        if (right != null)
                        {
                            this.DeleteRightEntity(right);
                            this.RightDataSource.AcceptChanges(right.ObjectID);
                        }
                    }
                    else
                    {
                        (this.LeftDeletedList[index] as BusinessBase).CopyFrom(entity, true);
                        if (right != null)
                        {
                            PropertyInfo rightParent = EntityUtility.GetParentProperty(right.GetType(), entity.GetType());
                            if (rightParent != null)
                            {
                                EntityUtility.ReplaceParent(right, rightParent, entity);
                            }
                        }
                    }
                }
                else
                {
                    if (!entity.IsDeleted)
                    {
                        this.LeftDataSource.Add(entity);
                    }
                }
            }

            return true;
        }

        private bool ReplaceRightData(BusinessBase entity)
        {
            if (entity.GetType() != this.RightDataSource.GetItemType())
                return false;

            int index = this.RightDataSource.IndexOf(entity);
            if (index > -1)
            {
                if (entity.IsDeleted)
                {
                    this.RightDataSource.RemoveAt(index);
                    this.RightDataSource.AcceptChanges();
                }
                else
                {
                    (this.RightDataSource[index] as BusinessBase).CopyFrom(entity, true);
                }
            }
            else
            {
                if(!entity.IsDeleted)
                {
                    foreach (BusinessBase left in this.LeftDataSource)
                    {
                        if (!this.CompareLeftAndRight(left, entity))
                            continue;

                        this.DeleteLeftEntity(left);
                        this.RightDataSource.Add(entity);
                        break;
                    }
                }
            }

            return true;
        }

        #region Helper functions

        private void DeleteLeftEntity(BusinessBase entity)
        {
            this.LeftDataSource.Remove(entity);
            this.LeftDataSource.AcceptChanges(entity.ObjectID);

            this.LeftDeletedList.Add(entity);
            this.GridViewLeft.SelectRow(this.GridViewLeft.FocusedRowHandle);
            this.GridViewRight.SelectRow(this.GridViewRight.FocusedRowHandle);
        }

        private void DeleteRightEntity(BusinessBase entity)
        {
            this.RightDataSource.Remove(entity);
            this.GridViewLeft.SelectRow(this.GridViewLeft.FocusedRowHandle);
            this.GridViewRight.SelectRow(this.GridViewRight.FocusedRowHandle);
        }

        private BusinessBase GetLeftEntity(BusinessBase right)
        {
            foreach (BusinessBase left in this.LeftDeletedList)
            {
                if (this.CompareLeftAndRight(left, right))
                {
                    this.LeftDeletedList.Remove(left);
                    this.LeftDeletedList.AcceptChanges(left.ObjectID);

                    left.AcceptChanges();
                    return left;
                }
            }

            return null;
        }

        private BusinessBase GetRightEntity(BusinessBase left)
        {
            return this.CreateRightEntity(left);
        }

        private BusinessBase FindRightEntity(BusinessBase left)
        {
            foreach (BusinessBase right in this.RightDataSource)
            {
                if (!this.CompareLeftAndRight(left, right))
                    continue;

                return right;
            }

            return null;
        }

        private bool CompareLeftAndRight(BusinessBase left, BusinessBase right)
        {
            return this.CompareEntity(left, right);
        }

        private List<BusinessBase> GetSelectionList(GridView view)
        {
            List<BusinessBase> list = new List<BusinessBase>();

            int[] rowHandles = view.GetSelectedRows();
            if (rowHandles != null && rowHandles.Length > 0)
            {
                for (int i = 0; i < rowHandles.Length; i++)
                {
                    BusinessBase entity = view.GetRow(rowHandles[i]) as BusinessBase;
                    if (entity != null)
                    {
                        list.Add(entity);
                    }
                }
            }

            return list;
        }

        private bool IsReady
        {
            get
            {
                if (this.CompareEntity == null || this.CreateRightEntity == null ||
                    this.LeftDataSource == null || this.RightDataSource == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        #endregion
    }
}
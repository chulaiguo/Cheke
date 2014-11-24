using System;
using System.Collections.Generic;
using Cheke.BusinessEntity;

namespace Cheke.ClientSide
{
    public class EntityOperation
    {
        private readonly SecurityToken _token = null;
        private readonly string _modifiedBy = string.Empty;
        private readonly DateTime _modifiedAt = DateTime.Now;
        private readonly ILocalDataProcesser _processor = null;

        public EntityOperation(ILocalDataProcesser processer, SecurityToken token, string modifiedBy, DateTime modifiedAt)
        {
            this._token = token;
            this._modifiedBy = modifiedBy;
            this._modifiedAt = modifiedAt;
            this._processor = processer;
        }

        public Result SaveItem(BusinessBase item)
        {
            if (!item.IsDirty)
                return new Result(true);

            if (!item.IsValid)
                return new Result(item.GetBrokenRulesInfo());

            List<BusinessBase> changedList = EntityUtility.GetChanges(item);
            foreach (BusinessBase changed in changedList)
            {
                if (!changed.IsSelfDirty)
                    continue;

                if(changed.IsNew)
                {
                    changed.CreatedBy = this._modifiedBy;
                    changed.CreatedOn = this._modifiedAt;
                }
                changed.ModifiedBy = this._modifiedBy;
                changed.ModifiedOn = this._modifiedAt;

                if (changed != item)
                {
                    EntityUtility.CopyParent(item, changed);
                }
            }

            Result result = (item as IPersist).Save(this._token);
            if (result.OK)
            {
                this.ProcessResult(changedList, result);
                EntityUtility.AcceptDeletes(item, result);

                this.AcceptChanges(changedList, result);
                this.UpdateLocalData(changedList, result);
            }

            return result;
        }

        public Result SaveList(BusinessCollectionBase list)
        {
            if (!list.IsDirty)
                return new Result(true);

            //if (!list.IsValid)
            //{
            //    return new Result(list.GetBrokenRulesInfo());
            //    //return EntityUtility.GetInvalidInfo(list);
            //}

            List<BusinessBase> changedList = EntityUtility.GetChanges(list);
            foreach (BusinessBase changed in changedList)
            {
                if(!changed.IsSelfDirty)
                    continue;

                if (changed.IsNew)
                {
                    changed.CreatedBy = this._modifiedBy;
                    changed.CreatedOn = this._modifiedAt;
                }
                changed.ModifiedBy = this._modifiedBy;
                changed.ModifiedOn = this._modifiedAt;
            }

            Result result = (list as IPersist).Save(this._token);
            if (result.RowVersions.Count > 0)
            {
                this.ProcessResult(changedList, result);
                EntityUtility.AcceptDeletes(list, result);

                this.AcceptChanges(changedList, result);
                this.UpdateLocalData(changedList, result);
            }

            return result;
        }

        private void ProcessResult(List<BusinessBase> changedList, Result result)
        {
            if (changedList == null || changedList.Count == 0 || result.RowVersions.Count == 0)
                return;

            foreach (BusinessBase entity in changedList)
            {
                byte[] rowVersion = result.RowVersions[entity.ObjectID] as byte[];
                if (rowVersion == null)
                    continue;

                if(entity.IsDeleted)
                {
                    result.RowVersions[entity.ObjectID] = new byte[0];
                }
            }
        }

        private void AcceptChanges(List<BusinessBase> changedList, Result result)
        {
            if (changedList == null || changedList.Count == 0 || result.RowVersions.Count == 0)
                return;

            foreach (BusinessBase entity in changedList)
            {
                byte[] rowVersion = result.RowVersions[entity.ObjectID] as byte[];
                if (rowVersion == null || rowVersion.Length == 0)
                    continue;

                entity.RowVersion = rowVersion;
            }

            foreach (BusinessBase entity in changedList)
            {
                byte[] rowVersion = result.RowVersions[entity.ObjectID] as byte[];
                if (rowVersion == null || rowVersion.Length == 0)
                    continue;

                entity.AcceptChanges();
            }
        }

        private void UpdateLocalData(List<BusinessBase> changedList, Result result)
        {
            if (changedList == null || changedList.Count == 0 || result.RowVersions.Count == 0)
                return;

            foreach (BusinessBase entity in changedList)
            {
                byte[] rowVersion = result.RowVersions[entity.ObjectID] as byte[];
                if (rowVersion == null)
                    continue;

                //add delete flag
                if (rowVersion.Length == 0)
                {
                    entity.Delete();
                }

            }

            //Replace data
            if (this._processor != null)
            {
                this._processor.UpdateLocalData(changedList);
            }
        }
    }
}
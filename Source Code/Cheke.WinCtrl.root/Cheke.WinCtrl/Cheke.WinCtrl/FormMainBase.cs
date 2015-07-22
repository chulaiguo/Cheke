using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Cheke.BusinessEntity;
using Cheke.WinCtrl.Decoration;
using Cheke.WinCtrl.Storage;
using Cheke.WinCtrl.StringManager;
using Cheke.WinCtrl.Utils;
using Cheke.WinCtrl.GridControlCommand;

namespace Cheke.WinCtrl
{
    public partial class FormMainBase : FormBase
    {
        public static Color ItemDirtyColor = Color.BurlyWood;
        public static Color ListNewColor = Color.DarkKhaki;
        public static Color ListDirtyColor = Color.BurlyWood;

        private static FormMainBase _Instance = null;
        private long _beginTickCount = 0;
        private DateTime _serviceTime = DateTime.Now;

        public FormMainBase()
        {
            InitializeComponent();
            _Instance = this;
        }

        public FormMainBase(string userId)
            : base(userId)
        {
            InitializeComponent();

            _Instance = this;
        }

        internal static FormMainBase Instance
        {
            get { return _Instance; }
        }

        [Browsable(false)]
        public DateTime Now
        {
            get { return this._serviceTime.AddMilliseconds(Environment.TickCount - this._beginTickCount).ToLocalTime(); }
        }

        protected virtual Control WorkArea
        {
            get { return null; }
        }

        protected override void InitializeForm()
        {
            base.InitializeForm();

            this.RefreshServiceTime();

            this.LoadUserStyleFiles();
            ConditionsStyleCommand.RestoreStyleFromFile(base.UserId);
            GridMenuFacade.RestoreStyleFromFile(base.UserId);
            GridMenuFacade.ApplyApplicationStyle();
        }

        protected virtual void RefreshServiceTime()
        {
            this._serviceTime = this.GetServiceTime();
            this._beginTickCount = Environment.TickCount;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            GridMenuFacade.SaveStyleToFile(base.UserId);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (this.IsConfirmClose)
            {
                if (base.ShowQuestion(UIStringManager.CloseApplicationQuestion) != DialogResult.Yes)
                {
                    e.Cancel = true;
                    return;
                }
            }

            if (this.WorkArea == null)
                return;

            this.CloseAllChildren();
            e.Cancel = this.HasChildrenForm();
        }

        public virtual bool IsConfirmClose
        {
            get { return this.Enabled; }
        }

        public override void GetTranslateString()
        {
            base.GetTranslateString();

            UIStringManager.GetTranslateString();
            GridStringManager.GetTranslateString();
            LoginStringManager.GetTranslateString();
            NavBarStringManager.GetTranslateString();
        }

        public override void TranslateForm()
        {
            base.TranslateForm();
 
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                if (item == this)
                    continue;

                FormBase child = item as FormBase;
                if (child == null)
                    continue;

                child.TranslateForm();
            }
        }

        protected virtual DateTime GetServiceTime()
        {
            return DateTime.Now;
        }

        public virtual bool HasAddNewPrivilege(string tableName)
        {
            return true;
        }

        public virtual bool HasEditPrivilege(string tableName)
        {
            return true;
        }

        public virtual bool HasDeletePrivilege(string tableName)
        {
            return true;
        }

        public virtual bool CanBatchEdit
        {
            get { return true; }
        }

        public virtual bool CanBatchAppend
        {
            get { return true; }
        }

        public virtual bool ShowHistory
        {
            get { return false; }
        }

        public virtual bool ShowEditorTooltip
        {
            get { return false; }
        }

        public virtual string GetSaveDataErrorMessage(Result result)
        {
            return result.ToString();
        }

        public virtual void ShowEditEvents(GridControlDecorator decorator)
        {
        }

        public virtual void ShowDeleteEvents(GridControlDecorator decorator)
        {
        }

        public virtual BusinessBase GetEntityFromDB(BusinessBase entity)
        {
            return entity;
        }

        public virtual bool ExportToCSV
        {
            get { return true; }
        }

        public virtual bool ExportToXLS
        {
            get { return true; }
        }

        public virtual bool ExportToXLSX
        {
            get { return true; }
        }

        public virtual bool ExportToPDF
        {
            get { return true; }
        }

        public virtual bool ExportToTXT
        {
            get { return true; }
        }

        public virtual bool ExportToRTF
        {
            get { return true; }
        }

        public virtual bool ExportToHTML
        {
            get { return true; }
        }

        public virtual bool ExportToMHT
        {
            get { return false; }
        }

        public virtual bool CustomizeGridViewFullLayout
        {
            get { return false;}
        }

        public virtual void SaveLayoutToServer(string fileName, byte[] data)
        {

        }

        public virtual void DeleteLayoutFromServer(string fileName)
        {

        }

        protected virtual void LoadUserStyleFiles()
        {
            string prefix = string.Format("{0}.", this.UserId.ToLower());
            const string suffix = ".style";
            this.ClearLocalFiles(prefix, suffix);
        }

        protected void ClearLocalFiles(string prefix, string suffix)
        {
            StyleStorage.ClearLocalFiles(prefix, suffix);
        }

        protected void ClearLocalFile(string fileName)
        {
            StyleStorage.ClearLocalFile(fileName);
        }

        protected void SaveLayoutToIsolatedStorage(string fileName, byte[] data)
        {
            using (StyleStorage storage = new StyleStorage(fileName))
            {
                storage.DownloadLayout(data);
                storage.Dispose();
            }
        }

        public virtual DataSet LoadFromExcel(string fileName)
        {
            return null;
        }

        public virtual void OnFormLoaded(Form frm)
        {

        }

        public virtual void OnFormClosed(Form frm)
        {

        }

        public void Print()
        {
            Form frm = this.FindTopMostOpenedChild();
            if(frm == null)
                return;

            GridControlDecorator decorator = FormUtil.GetGridDecorator(frm);
            if(decorator == null)
                return;

            decorator.Print();
        }

        public void ShowPreview()
        {
            Form frm = this.FindTopMostOpenedChild();
            if (frm == null)
                return;

            GridControlDecorator decorator = FormUtil.GetGridDecorator(frm);
            if (decorator == null)
                return;

            decorator.ShowPreview();
        }

        public Form ShowChildForm(Type t)
        {
            this.Cursor = Cursors.WaitCursor;
            FormWorkBase frm = this.FindOpenedChild(t);
            if (frm == null)
            {
                frm = (FormWorkBase)Activator.CreateInstance(t, base.UserId, this.WorkArea);
            }
            else
            {
                frm.BeforeOpenAgain();
            }

            frm.BringToFront();
            frm.Show();
            this.OnChildFormActive(frm);
            this.Cursor = Cursors.Default;

            return frm;
        }

        public Form ShowChildForm(Type t, params object[] args)
        {
            this.Cursor = Cursors.WaitCursor;
            FormWorkBase frm = this.FindOpenedChild(t);
            if (frm == null)
            {
                object[] newArgs = new object[args.Length + 2];
                newArgs[0] = base.UserId;
                newArgs[1] = this.WorkArea;
                for (int i = 0; i < args.Length; i++)
                {
                    newArgs[i + 2] = args[i];
                }
                frm = (FormWorkBase)Activator.CreateInstance(t, newArgs);
            }
            else
            {
                frm.BeforeOpenAgain();
            }

            frm.BringToFront();
            frm.Show();
            this.OnChildFormActive(frm);
            this.Cursor = Cursors.Default;

            return frm;
        }

        public Form ShowChildForm(Type t, object obj)
        {
            this.Cursor = Cursors.WaitCursor;
            FormWorkBase frm = this.FindOpenedChild(t, obj);
            if (frm == null)
            {
                frm = (FormWorkBase)Activator.CreateInstance(t, base.UserId, this.WorkArea, obj);
            }
            else
            {
                frm.BeforeOpenAgain();
            }

            frm.BringToFront();
            frm.Show();
            this.OnChildFormActive(frm);
            this.Cursor = Cursors.Default;

            return frm;
        }

        public Form ShowChildForm(Type t, object obj, params object[] args)
        {
            this.Cursor = Cursors.WaitCursor;
            FormWorkBase frm = this.FindOpenedChild(t, obj);
            if (frm == null)
            {
                object[] newArgs = new object[args.Length + 3];
                newArgs[0] = base.UserId;
                newArgs[1] = this.WorkArea;
                newArgs[2] = obj;
                for (int i = 0; i < args.Length; i++)
                {
                    newArgs[i + 3] = args[i];
                }
                frm = (FormWorkBase)Activator.CreateInstance(t, newArgs);
            }
            else
            {
                frm.BeforeOpenAgain();
            }

            frm.BringToFront();
            frm.Show();
            this.OnChildFormActive(frm);
            this.Cursor = Cursors.Default;

            return frm;
        }

        protected virtual void OnChildFormActive(Form frm)
        {
            
        }

        public void CloseChildren(Type childType)
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                if (item.GetType() != childType)
                    continue;

                item.Close();
            }
        }

        public void CloseChildren(FormWorkBase parent, BusinessBase parentEntity)
        {
            if (parent == null || parentEntity == null)
                return;

            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null || child == parent)
                    continue;

                if (!child.IsChildForm(parentEntity))
                    continue;

                child.IsDeletedForm = parent.IsDeletedForm;
                child.Close();
            }
        }

        public void CloseAllChildren()
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null)
                    continue;

                if (child.Parent == this.WorkArea)
                {
                    child.Close();
                }
            }
        }

        public void SaveAllChildren()
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null)
                    continue;

                if (child.Parent == this.WorkArea)
                {
                    child.SaveAll();
                }
            }
        }

        public void CloseTopMostChild()
        {
            if (this.WorkArea == null)
                return;

            FormWorkBase frm = this.FindTopMostOpenedChild();
            if (frm != null)
            {
                frm.Close();
            }
        }

        public void SaveTopMostChild()
        {
            if (this.WorkArea == null)
                return;

            FormWorkBase frm = this.FindTopMostOpenedChild();
            if (frm != null)
            {
                frm.SaveAll();
            }
        }

        public bool IsChildExist(Form child)
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                if (child == item)
                    return true;
            }

            return false;
        }

        public bool HasTopLevelForm()
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                if (!(item is FormBase))
                    continue;

                if (item == this || !item.TopLevel)
                    continue;

                return true;
            }

            return false;
        }

        public void ResetChildrenLayout()
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null)
                    continue;

                if (child.Parent == this.WorkArea)
                {
                    FormUtil.ResetGridLayout(child);
                }
            }
        }

        public FormWorkBase GetChildByField(object fieldData)
        {
            if (fieldData == null)
                return null;

            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null)
                    continue;

                object data = FormUtil.GetFormField(child, fieldData.GetType());
                if (data == null)
                    continue;

                if (fieldData.Equals(data))
                    return child;
            }

            return null;
        }

        public List<FormWorkBase> GetChildrenByField(object fieldData)
        {
            List<FormWorkBase> list = new List<FormWorkBase>();
            if (fieldData == null)
                return list;

            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null)
                    continue;

                object data = FormUtil.GetFormField(child, fieldData.GetType());
                if (data == null)
                    continue;

                if (fieldData.Equals(data))
                    list.Add(child);
            }

            return list;
        }


        private void FormMainBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.W)
            {
                if (this.HasChildrenForm())
                {
                    FormChildrenSwitch dlg = new FormChildrenSwitch();
                    dlg.ShowDialog();
                }
            }
        }

        public bool HasChildrenForm()
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null)
                    continue;

                if (child.Parent == this.WorkArea)
                    return true;
            }

            return false;
        }

        public bool HasChildrenForm(Type t)
        {
            Form frm = this.FindOpenedChild(t);
            return frm == null ? false : true;
        }

        public bool HasChildrenForm(Type t, BusinessBase entity)
        {
            Form frm = this.FindOpenedChild(t, entity);
            return frm == null ? false : true;
        }

        public static Guid GetSoftwareID()
        {
            Guid softwareID = Guid.Empty;
            try
            {
                string fileName = string.Format("{0}\\ProductCode.cc", Application.StartupPath);
                if (File.Exists(fileName))
                {
                    byte[] data = File.ReadAllBytes(fileName);
                    if(data.Length == 0)
                    {
                        softwareID = Guid.NewGuid();
                        data = softwareID.ToByteArray();

                        FileInfo fileInfo = new FileInfo(fileName);
                        DateTime lastWriteTime = fileInfo.LastWriteTime;
                        using (FileStream fs = new FileStream(fileName, FileMode.Create))
                        {
                            fs.Write(data, 0, data.Length);
                        }

                        fileInfo = new FileInfo(fileName);
                        fileInfo.LastWriteTime = lastWriteTime;
                    }
                    else
                    {
                        softwareID = new Guid(data);
                    }
                    
                }

                return softwareID;
            }
            catch
            {
            }

            return softwareID;
        }

        #region Helper functions

        private FormWorkBase FindOpenedChild(Type childType)
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null)
                    continue;

                if (child.GetType() == childType)
                    return child;
            }

            return null;
        }

        private FormWorkBase FindOpenedChild(Type childType, object obj)
        {
            if (obj == null)
                return null;

            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null || child.GetType() != childType)
                    continue;

                if (child.Contains(obj))
                    return child;
            }

            return null;
        }

        private FormWorkBase FindTopMostOpenedChild()
        {
            ArrayList forms = new ArrayList(Application.OpenForms);
            foreach (Form item in forms)
            {
                FormWorkBase child = item as FormWorkBase;
                if (child == null)
                    continue;

                if (child.Parent != this.WorkArea)
                    continue;

                if (child.Parent.Controls.GetChildIndex(child) == 0)
                {
                    return child;
                }
            }
            return null;
        }

        #endregion
    }
}
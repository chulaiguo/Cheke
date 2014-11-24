using System.Reflection;
using System;
using System.Windows.Forms;

namespace Cheke.Translation
{
    public class Translator : TranslatorBase
    {
        private static readonly Translator _Instance = new Translator();
        private readonly DefaultFieldTranslator _defaultFieldTranslator = new DefaultFieldTranslator();
        private IFieldTranslator _fieldTranslator = null;

        private Translator()
        {
        }

        public static Translator Instance
        {
            get { return _Instance; }
        }

        public IFieldTranslator FieldTranslator
        {
            get { return this._fieldTranslator == null ? this._defaultFieldTranslator : _fieldTranslator; }
            set { _fieldTranslator = value; }
        }

        public void RemoveFormText(Form frm)
        {
            Type frmType = frm.GetType();
            string key = string.Format("{0}|Text", frmType.Name);

            base.RemoveTranslateString(key);
        }

        public void TranslateForm(Form frm)
        {
            Type frmType = frm.GetType();
            string key = string.Format("{0}|Text", frmType.Name);
            string translate = this.Translate(key);
            if (translate.Length > 0)
            {
                frm.Text = translate;
            }

            this.TranslateForm(frm, frmType);
        }

        private void TranslateForm(Form form, Type type)
        {
            if(type == typeof(Form))
                return;

            FieldInfo[] fields = this.GetFieldCollection(type, true, true);
            foreach (FieldInfo field in fields)
            {
                this.FieldTranslator.TranslateField(this, form, field);
            }

            this.TranslateForm(form, type.BaseType);
        }

        public void GetTranslateString(Form frm)
        {
            Type frmType = frm.GetType();
            string key = string.Format("{0}|Text", frmType.Name);
            if (frm.Text.Length > 0 && frm.TopLevel)
            {
                this.AddTranslateString(key, frm.Text);
            }

            this.GetTranslateString(frm, frmType);
        }

        private void GetTranslateString(Form form, Type type)
        {
            if(type == typeof(Form))
                return;

            FieldInfo[] fields = this.GetFieldCollection(type, true, true);
            foreach (FieldInfo field in fields)
            {
                this.FieldTranslator.AddFieldToTranslator(this, form, field);
            }

            this.GetTranslateString(form, type.BaseType);
        }

        private FieldInfo[] GetFieldCollection(Type type, bool includePublic, bool declaredOnly)
        {
            BindingFlags flags = BindingFlags.GetField | BindingFlags.NonPublic | BindingFlags.Instance;
            if (includePublic)
            {
                flags |= BindingFlags.Public;
            }

            if (declaredOnly)
            {
                flags |= BindingFlags.DeclaredOnly;
            }

            return type.GetFields(flags);
        }
    }
}
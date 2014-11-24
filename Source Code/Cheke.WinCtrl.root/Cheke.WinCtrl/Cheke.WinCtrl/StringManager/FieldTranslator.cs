using System.Reflection;
using System.Windows.Forms;
using Cheke.Translation;
using Cheke.WinCtrl.Common;
using Cheke.WinCtrl.Decoration;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraNavBar;

namespace Cheke.WinCtrl.StringManager
{
    public class FieldTranslator : IFieldTranslator
    {
        public virtual void TranslateField(TranslatorBase translator, Form frm, FieldInfo field)
        {
            string typeName = frm.GetType().Name;
            if (field.FieldType.IsSubclassOf(typeof(EditorBase)))
            {
                EditorBase editor = field.GetValue(frm) as EditorBase;
                if (editor == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, editor.Name);
                string translate = translator.Translate(key);
                if (translate.Length > 0)
                {
                    if (editor.TitleVisible)
                    {
                        editor.Title = translate;
                    }
                    else
                    {
                        editor.Text = translate;
                    }
                }

                this.OnTranslateField(translator, frm, field);
                return;
            }

            if (field.FieldType.IsSubclassOf(typeof(Control)))
            {
                Control control = field.GetValue(frm) as Control;
                if (control == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, control.Name);
                string translate = translator.Translate(key);
                if (translate.Length > 0)
                {
                    control.Text = translate;
                }

                this.OnTranslateField(translator, frm, field);
                return;
            }

            if (field.FieldType.IsSubclassOf(typeof(NavElement)))
            {
                NavElement control = field.GetValue(frm) as NavElement;
                if (control == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, control.Name);
                string translate = translator.Translate(key);
                if (translate.Length > 0)
                {
                    control.Caption = translate;
                }

                this.OnTranslateField(translator, frm, field);
                return;
            }

            if (field.FieldType.IsSubclassOf(typeof(BarItem)))
            {
                BarItem control = field.GetValue(frm) as BarItem;
                if (control == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, control.Name);
                string translate = translator.Translate(key);
                if (translate.Length > 0)
                {
                    control.Caption = translate;
                }

                this.OnTranslateField(translator, frm, field);
                return;
            }

            if (field.FieldType.IsSubclassOf(typeof(GridControlDecorator)))
            {
                GridControlDecorator decorator = field.GetValue(frm) as GridControlDecorator;
                if (decorator == null)
                    return;

                decorator.OnTranslateColumn = OnTranslateColumn;
                decorator.Translate();
                return;
            }
        }

        protected virtual void OnTranslateField(TranslatorBase translator, Form frm, FieldInfo field)
        {
        }

        protected virtual void OnTranslateColumn(TranslatorBase translator, string typeName, GridControlDecorator decorator, GridColumn column)
        {
        }

        public virtual void AddFieldToTranslator(TranslatorBase translator, Form frm, FieldInfo field)
        {
            string typeName = frm.GetType().Name;
            if (field.FieldType.IsSubclassOf(typeof(EditorBase)))
            {
                EditorBase editor = field.GetValue(frm) as EditorBase;
                if (editor == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, editor.Name);
                if (editor.TitleVisible)
                {
                    translator.AddTranslateString(key, editor.Title);
                }
                else
                {
                    translator.AddTranslateString(key, editor.Text);
                }
                
                this.OnGetFieldTranslateString(translator, frm, field);
                return;
            }

            if (field.FieldType.IsSubclassOf(typeof(Control)))
            {
                Control control = field.GetValue(frm) as Control;
                if (control == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, control.Name);
                translator.AddTranslateString(key, control.Text);
                this.OnGetFieldTranslateString(translator, frm, field);
                return;
            }

            if (field.FieldType.IsSubclassOf(typeof(NavElement)))
            {
                NavElement control = field.GetValue(frm) as NavElement;
                if (control == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, control.Name);
                translator.AddTranslateString(key, control.Caption);
                this.OnGetFieldTranslateString(translator, frm, field);
                return;
            }

            if (field.FieldType.IsSubclassOf(typeof(BarItem)))
            {
                BarItem control = field.GetValue(frm) as BarItem;
                if (control == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, control.Name);
                translator.AddTranslateString(key, control.Caption);
                this.OnGetFieldTranslateString(translator, frm, field);
                return;
            }

            if (field.FieldType.IsSubclassOf(typeof(GridControlDecorator)))
            {
                GridControlDecorator decorator = field.GetValue(frm) as GridControlDecorator;
                if (decorator == null)
                    return;

                decorator.OnGetColumnTranslateString = OnGetColumnTranslateString;
                decorator.GetTranslateString();
                return;
            }
        }

        protected virtual void OnGetFieldTranslateString(TranslatorBase translator, Form frm, FieldInfo field)
        {
        }

        protected virtual void OnGetColumnTranslateString(TranslatorBase translator, string typeName, GridControlDecorator decorator, GridColumn column)
        {
          
        }
    }
}
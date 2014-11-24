using System.Reflection;
using System.Windows.Forms;

namespace Cheke.Translation
{
    public class DefaultFieldTranslator : IFieldTranslator
    {
        public void TranslateField(TranslatorBase translator, Form frm, FieldInfo field)
        {
            string typeName = frm.GetType().Name;

            if (field.FieldType.IsSubclassOf(typeof(ButtonBase)))
            {
                ButtonBase button = field.GetValue(frm) as ButtonBase;
                if (button == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                string text = translator.Translate(key);
                if (text.Length > 0)
                {
                    if (translator.DefaultUIFont != null)
                    {
                        button.Font = translator.DefaultUIFont;
                    }
                    button.Text = text;
                }
            }
            else if (field.FieldType == typeof(Label))
            {
                Label label = field.GetValue(frm) as Label;
                if (label == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                string text = translator.Translate(key);
                if (text.Length > 0)
                {
                    if (translator.DefaultUIFont != null)
                    {
                        label.Font = translator.DefaultUIFont;
                    }
                    label.Text = text;
                }
            }
            else if (field.FieldType == typeof(GroupBox))
            {
                GroupBox grp = field.GetValue(frm) as GroupBox;
                if (grp == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                string text = translator.Translate(key);
                if (text.Length > 0)
                {
                    grp.Text = text;
                }
            }
            else if (field.FieldType == typeof(ColumnHeader))
            {
                ColumnHeader header = field.GetValue(frm) as ColumnHeader;
                if (header == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                string text = translator.Translate(key);
                if (text.Length > 0)
                {
                    header.Text = text;
                }
            }
            else if (field.FieldType == typeof(TabPage))
            {
                TabPage page = field.GetValue(frm) as TabPage;
                if (page == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                string text = translator.Translate(key);
                if (text.Length > 0)
                {
                    page.Text = text;
                }
            }
        }

        public void AddFieldToTranslator(TranslatorBase translator, Form frm, FieldInfo field)
        {
            string typeName = frm.GetType().Name;
            if (field.FieldType.IsSubclassOf(typeof(ButtonBase)))
            {
                ButtonBase button = field.GetValue(frm) as ButtonBase;
                if (button == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                translator.AddTranslateString(key, button.Text);
            }
            else if (field.FieldType == typeof(Label))
            {
                Label label = field.GetValue(frm) as Label;
                if (label == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                translator.AddTranslateString(key, label.Text);
            }
            else if (field.FieldType == typeof(GroupBox))
            {
                GroupBox grp = field.GetValue(frm) as GroupBox;
                if (grp == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                translator.AddTranslateString(key, grp.Text);
            }
            else if (field.FieldType == typeof(ColumnHeader))
            {
                ColumnHeader header = field.GetValue(frm) as ColumnHeader;
                if (header == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                translator.AddTranslateString(key, header.Text);
            }
            else if (field.FieldType == typeof(TabPage))
            {
                TabPage page = field.GetValue(frm) as TabPage;
                if (page == null)
                    return;

                string key = string.Format("{0}|{1}", typeName, field.Name);
                translator.AddTranslateString(key, page.Text);
            }
        }
    }
}

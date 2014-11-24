using System.Reflection;
using System.Windows.Forms;

namespace Cheke.Translation
{
    public interface IFieldTranslator
    {
        void TranslateField(TranslatorBase translator, Form frm, FieldInfo field);
        void AddFieldToTranslator(TranslatorBase translator, Form frm, FieldInfo field);
    }
}

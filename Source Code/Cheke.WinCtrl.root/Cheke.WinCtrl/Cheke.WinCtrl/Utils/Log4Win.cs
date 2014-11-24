using System.IO;
using System.Windows.Forms;
using Cheke.ClientSide;
using System;

namespace Cheke.WinCtrl.Utils
{
    public static class Log4Win
    {
        private static readonly IFileLogger _Log = null;

        static Log4Win()
        {
            //string path = Path.GetTempPath();
            //string name = Application.ProductName;
            //string filePath = string.Format(@"{0}\{1}.{2:yyyyMMdd}.txt", path, name, DateTime.Today);

            string filePath = Path.GetTempFileName();
            _Log = new FileLogger(filePath);
        }

        public static void WriteDebug(string debug)
        {
            _Log.LogDebug(debug);
        }

        public static void WriteInfo(string info)
        {
            _Log.LogInfo(info);
        }

        public static void WriteWarning(string warning)
        {
            _Log.LogWarning(warning);
        }

        public static void WriteError(string error)
        {
            _Log.LogError(error);
        }

        public static void WriteException(Exception ex)
        {
            _Log.LogException(ex);
        }

        public static void WriteOpenForm(Form frm)
        {
            //_Log.LogDebug(string.Format("You open [{0}];", frm.Text));
            //LogFormEvents(frm, frm.GetType());
        }

        public static void WriteBringFormToFront(Form form)
        {
            //_Log.LogDebug(string.Format("You Bring [{0}] To Front;", form.Text));
        }

        public static void WriteCloseForm(Form form)
        {
            //_Log.LogDebug(string.Format("You close [{0}];", form.Text));
        }

        //private static void LogFormEvents(Form frm, Type type)
        //{
        //    if (type == typeof(Form))
        //        return;

        //    FieldInfo[] fields = ReflectorUtilitiy.GetFieldCollection(type, true, true);
        //    foreach (FieldInfo field in fields)
        //    {
        //        if (field.FieldType == typeof(SimpleButton))
        //        {
        //            SimpleButton btn = field.GetValue(frm) as SimpleButton;
        //            if (btn == null)
        //                continue;

        //            btn.Click += btn_Click;
        //        }
        //    }

        //    LogFormEvents(frm, type.BaseType);
        //}

        //private static void btn_Click(object sender, EventArgs e)
        //{
        //    SimpleButton btn = sender as SimpleButton;
        //    if (btn == null)
        //        return;

        //    _Log.LogInfo(string.Format("You click [{0}] (Name={1})", btn.Text, btn.Name));
        //}
    }
}
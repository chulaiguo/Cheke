using System;
using System.IO;
using System.Windows.Forms;
using Cheke.Designer.Controls;
using Cheke.Designer.Studio;

namespace Cheke.Designer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //byte[] entity = null;
            //using (FileStream stream = new FileStream(@"F:\My Documents\My Pictures\1", FileMode.Open))
            //{
            //    entity = new byte[stream.Length];
            //    stream.Read(entity, 0, entity.Length);
            //}

            ToolboxCollection list = new ToolboxCollection();
            list.Add(new Toolbox(typeof(TextControlBase), "Text"));
            list.Add(new Toolbox(typeof(PictureControlBase), "Picture"));
            list.Add(new Toolbox(typeof(LineControlBase), "Line"));
            list.Add(new Toolbox(typeof(ShapeControlBase), "Shape"));
            list.Add(new Toolbox(typeof(Barcode39ControlBase), "Barcode"));

            FormDesigner dlg = new FormDesigner(list, true, 2.126F, 3.37F, null);
            //FormDesigner dlg = new FormDesigner(list, true, 10.6F, 6.6F, null);
            //dlg.Entity = entity;
            //dlg.ShowEditorMode();
            Application.Run(dlg);
        }
    }
}
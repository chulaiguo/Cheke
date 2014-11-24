using System;
using System.Configuration;
using System.Drawing.Design;
using Cheke.Designer.Controls;
using Cheke.Designer.Studio.Core;

namespace Cheke.Designer.Studio.Utils
{
    internal class UtilToolbox
    {
        internal static void InitToolbox(ToolboxPanel panel, HostSurface hostSurface)
        {
            LoadDefaultToolbox(panel);
            LoadUserDefineToolbox(panel);

            panel.DesignerHost = hostSurface.DesignerHost;
            ToolboxServiceImpl toolBoxService = new ToolboxServiceImpl(panel);
            hostSurface.AddService(typeof (IToolboxService), toolBoxService);
        }

        private static void LoadDefaultToolbox(ToolboxPanel panel)
        {
            string showDefaultToolbox = ConfigurationManager.AppSettings["Toolbox:ShowDefault"];
            if (showDefaultToolbox != null && showDefaultToolbox != "True")
                return;

            panel.AddToolboxCategory("Default");
            panel.AddToolboxItem("Default", typeof(TextControlBase), "Text");
            panel.AddToolboxItem("Default", typeof(LineControlBase), "Line");
            panel.AddToolboxItem("Default", typeof(ShapeControlBase), "Shape");
            panel.AddToolboxItem("Default", typeof(PictureControlBase), "Picture");
            panel.AddToolboxItem("Default", typeof(Barcode39ControlBase), "Barcode39");
        }

        private static void LoadUserDefineToolbox(ToolboxPanel panel)
        {
            foreach (string item in ConfigurationManager.AppSettings)
            {
                string[] array = item.Split(':');
                if (array.Length < 3)
                    continue;

                if (array[0] != "Toolbox")
                    continue;

                string categoryName = array[1];
                string displayName = array[2];
                string typeName = ConfigurationManager.AppSettings[item];

                Type type = Type.GetType(typeName);
                if (type == null)
                    continue;

                panel.AddToolboxCategory(categoryName);
                panel.AddToolboxItem(categoryName, type, displayName);
            }
        }
    }
}
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Reflection;

namespace Cheke.CustomerInstaller
{
    [RunInstaller(true)]
    public partial class CustomerActions : Installer
    {
        public CustomerActions()
        {
            InitializeComponent();
        }

        protected override void OnAfterUninstall(System.Collections.IDictionary savedState)
        {
            base.OnBeforeUninstall(savedState);

            Assembly thisAssembly = Assembly.GetAssembly(this.GetType());
            if (thisAssembly == null || thisAssembly.Location == null)
                return;

            int index = thisAssembly.Location.LastIndexOf('\\');
            string appPath = thisAssembly.Location.Substring(0, index);

            string[] dirs = Directory.GetDirectories(appPath);
            foreach (string dir in dirs)
            {
                Directory.Delete(dir, true);
            }

            string[] files = Directory.GetFiles(appPath);
            foreach (string file in files)
            {
                if (file == thisAssembly.Location)
                    continue;

                File.Delete(file);
            }
        }
    }
}
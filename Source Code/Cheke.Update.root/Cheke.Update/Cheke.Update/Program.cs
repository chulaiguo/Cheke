using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;

namespace Cheke.Update
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;

            Console.WriteLine("Please waiting...");

            //Host ExecutablePath
            string startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string executablePath;
            if (args[0].ToLower().EndsWith("exe"))
            {
                executablePath = args[0];
            }
            else
            {
                executablePath = string.Format("{0}\\{1}.exe", startupPath, args[0]);
            }

            //Waiting 5s
            Thread.Sleep(5000);

            try
            {
                //copy files
                Dictionary<string, string> updatingFiles = GetUpdatingFiles(startupPath);
                foreach (KeyValuePair<string, string> pair in updatingFiles)
                {
                    Console.WriteLine(string.Format("Copy {0}...", pair.Value));
                    File.Copy(pair.Key, pair.Value, true);
                }

                //restart
                Console.WriteLine();
                Console.WriteLine(string.Format("Restart {0} ...", executablePath));

                StartApp(executablePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("Exception: {0}", ex.Message));
                Console.WriteLine(string.Format("StackTrace: {0}", ex.StackTrace));
                Console.WriteLine();
                Console.WriteLine("Enter any key to exit...");

                Console.ReadKey();
            }
        }

        private static void StartApp(string executablePath)
        {
            if (!HasEveryoneFullControl(GetParentFolder(executablePath)))
            {
                string verb = string.Empty;
                OperatingSystem osInfo = Environment.OSVersion;
                if (osInfo.Platform == PlatformID.Win32NT && osInfo.Version.Major >= 6)
                {
                    verb = "runas";
                }

                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = executablePath;
                processInfo.Verb = verb;
                processInfo.CreateNoWindow = false;
                processInfo.Arguments = "RunAsAdministrator";
                Process.Start(processInfo);
            }
            else
            {
                Process.Start(executablePath);
            }
        }

        private static string GetParentFolder(string path)
        {
            int index = path.LastIndexOf('\\');
            if (index >= 0)
            {
                path = path.Substring(0, index);
            }

            return path;
        }

        private static bool HasEveryoneFullControl(string path)
        {
            DirectorySecurity dSecurity = Directory.GetAccessControl(path);
            foreach (FileSystemAccessRule acr in dSecurity.GetAccessRules(true, true, typeof(NTAccount)))
            {
                if (acr.IdentityReference.Value == "Everyone"
                    && acr.FileSystemRights == FileSystemRights.FullControl)
                {
                    return true;
                }
            }

            return false;
        }

        private static Dictionary<string, string> GetUpdatingFiles(string startupPath)
        {
            const string updateExtension = ".update";

            Dictionary<string, string> updatingFiles = new Dictionary<string, string>();
            DirectoryInfo dirUpdate = new DirectoryInfo(startupPath);
            foreach (FileInfo item in dirUpdate.GetFiles())
            {
                if (item.Extension.ToLower() != updateExtension)
                    continue;

                string oldFilePath = item.FullName.Substring(0, item.FullName.Length - updateExtension.Length);
                FileInfo oldFile = new FileInfo(oldFilePath);
                if (oldFile.Exists && item.LastWriteTime.Ticks == oldFile.LastWriteTime.Ticks)
                    continue;

                updatingFiles.Add(item.FullName, oldFilePath);
            }

            return updatingFiles;
        }
    }
}

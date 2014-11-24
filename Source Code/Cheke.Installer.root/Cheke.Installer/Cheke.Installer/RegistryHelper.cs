using System;
using System.Collections.Generic;
using Microsoft.Win32;

namespace Cheke.Installer
{
    public static class RegistryHelper
    {
        public static void AutomaticStartService(string serviceName)
        {
            try
            {
                string keyPath = @"SYSTEM\CurrentControlSet\Services\" + serviceName;
                RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, true);
                if (key != null)
                {
                    object ret = key.GetValue("DelayedAutostart");
                    if (ret != null)
                    {
                        key.SetValue("DelayedAutostart", 0);
                    }

                    key.SetValue("Start", 2); //2:Automatic, 3:Manul, 4:Disabled
                    key.Close();
                }
            }
            catch
            {
            }
        }

        public static void ManulStartService(string serviceName)
        {
            try
            {
                string keyPath = @"SYSTEM\CurrentControlSet\Services\" + serviceName;
                RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, true);
                if (key != null)
                {
                    key.SetValue("Start", 3); //2:Automatic, 3:Manul, 4:Disabled
                    key.Close();
                }
            }
            catch
            {
            }
        }

        public static void DisabledStartService(string serviceName)
        {
            try
            {
                string keyPath = @"SYSTEM\CurrentControlSet\Services\" + serviceName;
                RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath, true);
                if (key != null)
                {
                    key.SetValue("Start", 4); //2:Automatic, 3:Manul, 4:Disabled
                    key.Close();
                }
            }
            catch
            {
            }
        }

        public static void WriteSoftwareIDToRegister(string softewareName)
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                if (software == null)
                    return;

                RegistryKey dir = software.CreateSubKey(softewareName);
                if (dir == null)
                    return;

                dir.SetValue("SoftwareID", Guid.NewGuid().ToString());
                dir.Close();
            }
            catch
            {
            }
        }

        public static void WriteToRegister(string softewareName, string key, string value)
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                if (software == null)
                    return;

                RegistryKey dir = software.CreateSubKey(softewareName);
                if (dir == null)
                    return;

                dir.SetValue(key, value);
                dir.Close();
            }
            catch
            {
            }
        }

        public static void WriteToRegister(string softewareName, IDictionary<string, string>  keyList)
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                if (software == null)
                    return;

                RegistryKey dir = software.CreateSubKey(softewareName);
                if (dir == null)
                    return;

                foreach (KeyValuePair<string, string> pair in keyList)
                {
                    dir.SetValue(pair.Key, pair.Value);
                }
                
                dir.Close();
            }
            catch
            {
            }
        }

        public static void RemoveToRegister(string softewareName)
        {
            try
            {
                RegistryKey hklm = Registry.LocalMachine;
                RegistryKey software = hklm.OpenSubKey("SOFTWARE", true);
                if (software == null)
                    return;

                software.DeleteSubKeyTree(softewareName);
                software.Close();
            }
            catch
            {
            }
        }
    }
}

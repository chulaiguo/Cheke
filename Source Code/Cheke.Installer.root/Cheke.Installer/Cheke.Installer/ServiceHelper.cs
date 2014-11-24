using System;
using System.Management;
using System.ServiceProcess;

namespace Cheke.Installer
{
    public static class ServiceHelper
    {
        public static void RestartService(string serviceName)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                TimeSpan timeout = TimeSpan.FromSeconds(30);

                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }

                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            catch
            {
            }
        }

        public static void StartService(string serviceName)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                TimeSpan timeout = TimeSpan.FromSeconds(30);

                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            catch
            {
            }
        }

        public static void StopService(string serviceName)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                TimeSpan timeout = TimeSpan.FromSeconds(30);

                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
            }
            catch
            {
            }
        }

        public static void WatchRunningService(string serviceName)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                if (service.Status == ServiceControllerStatus.Running)
                    return;

                TimeSpan timeout = TimeSpan.FromSeconds(30);
                if (service.Status == ServiceControllerStatus.Stopped)
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running, timeout);
                }
            }
            catch
            {
            }
        }

        public static void WatchStoppedService(string serviceName)
        {
            try
            {
                ServiceController service = new ServiceController(serviceName);
                if (service.Status == ServiceControllerStatus.Stopped)
                    return;

                TimeSpan timeout = TimeSpan.FromSeconds(30);
                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
                }
            }
            catch
            {
            }
        }

        public static bool IsAutomaticStartMode(string serviceName)
        {
            string startMode = GetStartMode(serviceName);
            return string.Compare(startMode, "Automatic",StringComparison.OrdinalIgnoreCase) == 0
                || string.Compare(startMode, "Auto", StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool IsManualStartMode(string serviceName)
        {
            string startMode = GetStartMode(serviceName);
            return string.Compare(startMode, "Manual", StringComparison.OrdinalIgnoreCase) == 0;
        }

        public static bool IsDisabledStartMode(string serviceName)
        {
            string startMode = GetStartMode(serviceName);
            return string.Compare(startMode, "Disabled", StringComparison.OrdinalIgnoreCase) == 0;
        }

        private static string GetStartMode(string serviceName)
        {
            try
            {
                ManagementPath mp = new ManagementPath(string.Format("Win32_Service.Name='{0}'", serviceName));
                using (ManagementObject mo = new ManagementObject(mp))
                {
                    return mo["StartMode"].ToString();
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        public static void SetAutomaticStartMode(string serviceName)
        {
            SetStartMode(serviceName, "Automatic");
        }

        public static void SetManualStartMode(string serviceName)
        {
            SetStartMode(serviceName, "Manual");
        }

        public static void SetDisabledStartMode(string serviceName)
        {
            SetStartMode(serviceName, "Disabled");
        }
      
        private static void SetStartMode(string serviceName, string startMode)
        {
            try
            {
                // "Automatic" ,"Manual" ,"Disabled"
                ManagementPath mp = new ManagementPath(string.Format("Win32_Service.Name='{0}'", serviceName));
                using (ManagementObject mo = new ManagementObject(mp))
                {
                    mo.InvokeMethod("ChangeStartMode", new object[] { startMode });
                }
            }
            catch
            {
            }
        }
    }
}

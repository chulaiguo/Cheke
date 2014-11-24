using System;
using NetFwTypeLib;

namespace Cheke.Installer
{
    public static class FirewallHelper
    {
        private static INetFwMgr GetManager()
        {
            //Type NetFwMgrType = Type.GetTypeFromCLSID(new Guid("{304CE942-6E39-40D8-943A-B913C40C9CD4}"));
            Type NetFwMgrType = Type.GetTypeFromProgID("HNetCfg.FwMgr");
            return Activator.CreateInstance(NetFwMgrType) as INetFwMgr;
        }

        public static void FireWallTrigger(bool enable)
        {
            try
            {
                INetFwMgr mgr = GetManager();
                if (mgr == null)
                    return;

                mgr.LocalPolicy.CurrentProfile.FirewallEnabled = enable;
            }
            catch
            {
            }
        }

        public static void FireWallService(string name, bool enable)
        {
            try
            {
                INetFwMgr mgr = GetManager();
                if (mgr == null)
                    return;

                foreach (INetFwService serv in mgr.LocalPolicy.CurrentProfile.Services)
                {
                    if (serv.Name.ToUpper() == name.ToUpper())
                    {
                        serv.Enabled = enable;
                        return;
                    }
                }
            }
            catch
            {
            }
        }

        public static void AuthorizeProgram(string title, string path)
        {
            try
            {
                INetFwMgr mgr = GetManager();
                if (mgr == null)
                    return;

                Type type = Type.GetTypeFromProgID("HNetCfg.FwAuthorizedApplication");
                INetFwAuthorizedApplication authapp = Activator.CreateInstance(type) as INetFwAuthorizedApplication;
                if (authapp == null)
                    return;

                authapp.Name = title;
                authapp.ProcessImageFileName = path;
                authapp.Enabled = true;
                authapp.IpVersion = NET_FW_IP_VERSION_.NET_FW_IP_VERSION_ANY;
                authapp.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
                authapp.RemoteAddresses = "*";

                bool exist = false;
                foreach (INetFwAuthorizedApplication mApp in mgr.LocalPolicy.CurrentProfile.AuthorizedApplications)
                {
                    if (authapp == mApp)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    mgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Add(authapp);
                }
            }
            catch
            {
            }
        }

        public static void DeleteProgram(string executablePath)
        {
            try
            {
                INetFwMgr mgr = GetManager();
                if (mgr == null)
                    return;

                mgr.LocalPolicy.CurrentProfile.AuthorizedApplications.Remove(executablePath);
            }
            catch
            {
            }
        }

        public static void AuthorizePort(string name, int port, string protocol)
        {
            try
            {
                INetFwMgr mgr = GetManager();
                if (mgr == null)
                    return;

                INetFwOpenPort objPort = (INetFwOpenPort)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwOpenPort"));
                objPort.Name = name;
                objPort.Port = port;
                objPort.Protocol = GetProtocol(protocol);
                objPort.Scope = NET_FW_SCOPE_.NET_FW_SCOPE_ALL;
                objPort.Enabled = true;

                bool exist = false;
                foreach (INetFwOpenPort mPort in mgr.LocalPolicy.CurrentProfile.GloballyOpenPorts)
                {
                    if (objPort == mPort)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    mgr.LocalPolicy.CurrentProfile.GloballyOpenPorts.Add(objPort);
                }
            }
            catch
            {
            }
        }

        public static void DeletePort(int port, string protocol)
        {
            try
            {
                INetFwMgr mgr = GetManager();
                if (mgr == null)
                    return;

                mgr.LocalPolicy.CurrentProfile.GloballyOpenPorts.Remove(port, GetProtocol(protocol));
            }
            catch
            {
            }
        }

        private static NET_FW_IP_PROTOCOL_ GetProtocol(string protocol)
        {
            if (protocol.ToUpper() == "TCP")
            {
                return NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
            }

            if (protocol.ToUpper() == "UDP")
            {
                return NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
            }

            return  NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
        }
    }
}

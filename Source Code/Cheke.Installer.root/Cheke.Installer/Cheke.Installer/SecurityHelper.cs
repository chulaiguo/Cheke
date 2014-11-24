using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Cheke.Installer
{
    public static class SecurityHelper
    {
        public static void AddEveryoneFullControl(string path)
        {
            DirectorySecurity dSecurity = Directory.GetAccessControl(path);
            SecurityIdentifier everyone = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            dSecurity.AddAccessRule(new FileSystemAccessRule(everyone, FileSystemRights.FullControl | FileSystemRights.Synchronize, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.InheritOnly, AccessControlType.Allow));
            Directory.SetAccessControl(path, dSecurity);
        }

        public static bool HasEveryoneFullControl(string path)
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
    }
}

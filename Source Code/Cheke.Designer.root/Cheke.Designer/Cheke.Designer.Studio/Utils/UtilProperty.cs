using System.Windows.Forms;

namespace Cheke.Designer.Studio.Utils
{
    internal static class UtilProperty
    {
        internal static void InitProperty(PropertyGrid propertyGrid, HostSurface hostSurface)
        {
            hostSurface.AddService(typeof(PropertyGrid), propertyGrid);
        }
    }
}
using System;

namespace Cheke.ClientSide
{
    public interface IFileLogger : IDisposable
    {
        bool Enabled { get;set; }

        void LogDebug(string debug);
        void LogInfo(string info);
        void LogWarning(string warning);
        void LogError(string error);
        void LogException(Exception ex);
    }
}

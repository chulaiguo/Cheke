using System;
using System.IO;
using System.Text;

namespace Cheke.ClientSide
{
    public class FileLogger : IFileLogger
    {
        private bool _enabled = true;
        private StreamWriter _writer;

        public FileLogger(string filePath)
        {
            if (!File.Exists(filePath))
            {
                FileStream fs = File.Create(filePath);
                fs.Close();
            }

            this._writer = new StreamWriter(File.Open(filePath, FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write, FileShare.Read));
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        #region Dispose
        private void Close()
        {
            if (this._writer != null)
            {
                try
                {
                    this._writer.Close();
                    this._writer = null;
                }
                catch
                {
                }
            }
        }

        public void Dispose()
        {
            this.Close();
            GC.SuppressFinalize(this);
        }

        ~FileLogger()
        {
            this.Close();
        }
        #endregion

        private void Log(string msg)
        {
            if (!this.Enabled)
            {
                return;
            }

            lock (this._writer)
            {
                this._writer.WriteLine(msg);
                this._writer.WriteLine();
                this._writer.Flush();
            }
        } 

        public void LogDebug(string debug)
        {
            this.Log(debug);
        }

        public void LogInfo(string info)
        {
            this.Log(info);
        }

        public void LogWarning(string warning)
        {
            this.Log(warning);
        }

        public void LogError(string error)
        {
            this.Log(error);
        }

        public void LogException(Exception ex)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Source: {0}", ex.Source));
            builder.AppendLine(ex.Message);
            for (Exception exception = ex.InnerException; exception != null; exception = exception.InnerException)
            {
                builder.AppendLine(exception.Message);
            }

            builder.Append(string.Format("StackTrace: {0}", ex.StackTrace));
            this.Log(builder.ToString());
        }
    }
}
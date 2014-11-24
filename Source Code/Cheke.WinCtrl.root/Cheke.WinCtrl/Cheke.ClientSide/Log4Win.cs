using System;
using System.IO;
using System.Text;

namespace Cheke.ClientSide
{
    public class Log4Win
    {
        private string _productName = string.Empty;

        public Log4Win(string productName)
        {
            this._productName = productName;
        }

        public void WriteDebug(string debug)
        {
            WriteLog(debug);
        }

        public void WriteInfo(string info)
        {
            WriteLog(info);
        }

        public void WriteWarning(string warning)
        {
            WriteLog(warning);
        }

        public void WriteError(string error)
        {
            WriteLog(error);
        }

        public void WriteException(Exception ex)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format("Source: {0}", ex.Source));
            builder.AppendLine(ex.Message);
            for (Exception exception = ex.InnerException; exception != null; exception = exception.InnerException)
            {
                builder.AppendLine(exception.Message);
            }

            builder.Append(string.Format("StackTrace: {0}", ex.StackTrace));
            WriteLog(builder.ToString());
        }

        private void WriteLog(string message)
        {
            FileStream fs = File.Open(this.GetLogFileName(), FileMode.Append, FileAccess.Write);
            StreamWriter stream = new StreamWriter(fs);
            DateTime now = DateTime.Now;
            stream.WriteLine(string.Format("{0:HH:mm:ss} {1:d3} {2}", now, now.Millisecond, message));
            stream.Close();
            fs.Close();
        }

        private string GetLogFileName()
        {
            string path = Path.GetTempPath();
            string name = this._productName;
            return string.Format(@"{0}\{1}.{2:yyyyMMdd}.txt", path, name, DateTime.Today);
        }
    }
}
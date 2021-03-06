﻿using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;

namespace Cheke.WebAPI.Controllers
{
    public class UpdateServiceController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetUpdateInfo()
        {
            try
            {
                string projectName = this.Request.Content.ReadAsStringAsync().Result;

                StringBuilder builder = new StringBuilder();
                string rootPath = System.Web.Hosting.HostingEnvironment.MapPath(string.Format("~/{0}", projectName));
                if (!string.IsNullOrEmpty(rootPath) && Directory.Exists(rootPath))
                { 
                    DirectoryInfo di = new DirectoryInfo(rootPath);
                    foreach (FileInfo fi in di.GetFiles())
                    {
                        builder.AppendFormat("{0}:{1}|", fi.Name, fi.LastWriteTime.Ticks);
                    }
                }

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                res.Content = new StringContent(builder.ToString().TrimEnd('|'));
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                return res;
            }
            catch (System.Exception ex)
            {
                return this.CreateExceptionResponse(ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage GetUpdateFile()
        {
            try
            {
                string projectName = string.Empty;
                string fileName = string.Empty;
                string[] splits = this.Request.Content.ReadAsStringAsync().Result.Split('|');
                if (splits.Length >= 2)
                {
                    projectName = splits[0];
                    fileName = splits[1];
                }

                byte[] data = null;

                string rootPath = System.Web.Hosting.HostingEnvironment.MapPath(string.Format("~/{0}", projectName));
                if (!string.IsNullOrEmpty(rootPath) && Directory.Exists(rootPath))
                {
                    string filePath = string.Format(@"{0}\{1}", rootPath, fileName);
                    if (File.Exists(filePath))
                    {
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            data = new byte[fs.Length];
                            fs.Read(data, 0, (int) fs.Length);
                        }
                    }
                }

                if (data == null)
                {
                    data = new byte[0];
                }

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                res.Content = new ByteArrayContent(Infrastructure.Utils.Compress(data));
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                return res;
            }
            catch (System.Exception ex)
            {
                return this.CreateExceptionResponse(ex);
            }
        }

        private HttpResponseMessage CreateExceptionResponse(System.Exception ex)
        {
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            res.Content = new ByteArrayContent(Infrastructure.Utils.Serialize(ex));
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return res;
        }
    }
}

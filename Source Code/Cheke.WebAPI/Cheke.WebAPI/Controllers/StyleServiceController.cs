using System;
using System.Collections;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Cheke.WebAPI.Controllers
{
    public class StyleServiceController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage GetStyleFiles()
        {
            try
            {
                string projectName = string.Empty;
                string userId = string.Empty;
                string[] splits = this.Request.Content.ReadAsStringAsync().Result.Split('|');
                if (splits.Length >= 2)
                {
                    projectName = splits[0];
                    userId = splits[1];
                }

                Hashtable table = new Hashtable();

                string rootPath = ConfigurationManager.AppSettings[projectName];
                if (!string.IsNullOrEmpty(rootPath) && Directory.Exists(rootPath))
                {
                    string userPath = string.Format(@"{0}\{1}", rootPath, userId);
                    if (Directory.Exists(userPath))
                    {
                        string[] files = Directory.GetFiles(userPath);
                        foreach (string file in files)
                        {
                            FileInfo info = new FileInfo(file);
                            using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                            {
                                byte[] data = new byte[fs.Length];
                                fs.Read(data, 0, data.Length);

                                table.Add(info.Name, data);
                            }
                        }
                    }
                }

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                res.Content = new ByteArrayContent(Infrastructure.Utils.CompressObject(table));
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
                return res;
            }
            catch (Exception ex)
            {
                return this.CreateExceptionResponse(ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage AddStyleFile()
        {
            try
            {
                byte[] token = this.Request.Content.ReadAsByteArrayAsync().Result;
                Hashtable table = Infrastructure.Utils.DecompressObject(token) as Hashtable;
                if (table != null)
                {
                    foreach (DictionaryEntry pair in table)
                    {
                        string[] key = pair.Key as string[];
                        byte[] data = pair.Value as byte[];
                        if(key == null || key.Length < 3 || data == null)
                            continue;

                        string projectName = key[0];
                        string userId = key[1];
                        string fileName = key[2];

                        string rootPath = ConfigurationManager.AppSettings[projectName];
                        if (string.IsNullOrEmpty(rootPath) || !Directory.Exists(rootPath))
                            continue;

                        string userPath = string.Format(@"{0}\{1}", rootPath, userId);
                        if (!Directory.Exists(userPath))
                        {
                            Directory.CreateDirectory(userPath);
                        }

                        string filePath = string.Format(@"{0}\{1}", userPath, fileName);
                        using ( FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
                        {
                            fs.SetLength(0);
                            fs.Write(data, 0, data.Length);
                        }
                    }
                }

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                res.Content = new StringContent("OK");
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                return res;
            }
            catch (Exception ex)
            {
                return this.CreateExceptionResponse(ex);
            }
        }

        [HttpPost]
        public HttpResponseMessage DeleteStyleFile()
        {
            try
            {
                string projectName = string.Empty;
                string userId = string.Empty;
                string fileName = string.Empty;
                string[] splits = this.Request.Content.ReadAsStringAsync().Result.Split('|');
                if (splits.Length >= 3)
                {
                    projectName = splits[0];
                    userId = splits[1];
                    fileName = splits[2];
                }

                string rootPath = ConfigurationManager.AppSettings[projectName];
                if (!string.IsNullOrEmpty(rootPath) && Directory.Exists(rootPath))
                {
                    string userPath = string.Format(@"{0}\{1}", rootPath, userId);
                    if (Directory.Exists(userPath))
                    {
                        string filePath = string.Format(@"{0}\{1}", userPath, fileName);
                        if (File.Exists(filePath))
                        {
                            File.Delete(filePath);
                        }
                    }
                }

                HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                res.Content = new StringContent("OK");
                res.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
                return res;
            }
            catch (Exception ex)
            {
                return this.CreateExceptionResponse(ex);
            }
        }

        private HttpResponseMessage CreateExceptionResponse(Exception ex)
        {
            HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            res.Content = new ByteArrayContent(Infrastructure.Utils.Serialize(ex));
            res.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            return res;
        }
    }
}

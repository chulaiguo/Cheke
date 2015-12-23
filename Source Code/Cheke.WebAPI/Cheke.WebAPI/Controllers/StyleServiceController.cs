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
        [HttpGet]
        public HttpResponseMessage GetStyleFiles(string projectName, string userId)
        {
            try
            {
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
        public HttpResponseMessage AddStyleFile(string projectName)
        {
            try
            {
                string rootPath = ConfigurationManager.AppSettings[projectName];

                byte[] token = this.Request.Content.ReadAsByteArrayAsync().Result;
                Hashtable table = Infrastructure.Utils.DecompressObject(token) as Hashtable;
                if (table != null && !string.IsNullOrEmpty(rootPath) && Directory.Exists(rootPath))
                {
                    foreach (DictionaryEntry pair in table)
                    {
                        string[] key = pair.Key as string[];
                        byte[] data = pair.Value as byte[];
                        if(key == null || key.Length < 2 || data == null)
                            continue;

                        string userId = key[0];
                        string fileName = key[1];

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

        [HttpGet]
        public HttpResponseMessage DeleteStyleFile(string projectName, string userId, string fileName)
        {
            try
            {
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

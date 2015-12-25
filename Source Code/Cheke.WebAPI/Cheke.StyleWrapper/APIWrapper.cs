using System;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Cheke.StyleWrapper
{
	public static class APIWrapper
    {
		public static Hashtable GetStyleFiles(string projectName, string userId)
        {
			string baseAddress = System.Configuration.ConfigurationManager.AppSettings["Cheke_StyleService:BaseAddress"];

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(string.Format("{0}/StyleService/", baseAddress.TrimEnd('/')));
            HttpContent content = new StringContent(string.Format("{0}|{1}", projectName, userId));

            HttpResponseMessage res = client.PostAsync("GetStyleFiles", content).Result;
            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("The remote server returned an error: (404) Not Found");
            }
            if (!res.IsSuccessStatusCode)
			{
				throw Utils.DeserializeException(res.Content.ReadAsByteArrayAsync().Result);
			}

			return Utils.DecompressObject(res.Content.ReadAsByteArrayAsync().Result) as Hashtable;
        }

        public static void AddStyleFile(string projectName, string userId, string fileName, byte[] data)
        {
            string baseAddress = System.Configuration.ConfigurationManager.AppSettings["Cheke_StyleService:BaseAddress"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(string.Format("{0}/StyleService/", baseAddress.TrimEnd('/')));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("image/jpg"));

            Hashtable table = new Hashtable();
            table.Add(new string[] { projectName, userId, fileName}, data);
            HttpContent content = new ByteArrayContent(Utils.CompressObject(table));

            HttpResponseMessage res = client.PostAsync("AddStyleFile", content).Result;
            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("The remote server returned an error: (404) Not Found");
            }

            if (!res.IsSuccessStatusCode)
            {
                throw Utils.DeserializeException(res.Content.ReadAsByteArrayAsync().Result);
            }
        }

        public static void DeleteStyleFile(string projectName, string userId, string fileName)
        {
            string baseAddress = System.Configuration.ConfigurationManager.AppSettings["Cheke_StyleService:BaseAddress"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(string.Format("{0}/StyleService/", baseAddress.TrimEnd('/')));
            HttpContent content = new StringContent(string.Format("{0}|{1}|{2}", projectName, userId, fileName));

            HttpResponseMessage res = client.PostAsync("DeleteStyleFile", content).Result;
            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("The remote server returned an error: (404) Not Found");
            }

            if (!res.IsSuccessStatusCode)
            {
                throw Utils.DeserializeException(res.Content.ReadAsByteArrayAsync().Result);
            }
        }
    }
}

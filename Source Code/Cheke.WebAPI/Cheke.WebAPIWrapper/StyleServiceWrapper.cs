using System;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Cheke.WebAPIWrapper
{
	public static class StyleServiceWrapper
    {
		public static Hashtable GetStyleFiles(string projectName, string userId)
        {
			string baseAddress = System.Configuration.ConfigurationManager.AppSettings["Cheke_StyleService:BaseAddress"];

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(string.Format("{0}/StyleService/", baseAddress.TrimEnd('/')));

			HttpResponseMessage res = client.GetAsync(string.Format("GetStyleFiles/{0}?userId={1}", projectName, userId)).Result;
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
            table.Add(new string[] {userId, fileName}, data);
            HttpContent content = new ByteArrayContent(Utils.CompressObject(table));

            HttpResponseMessage res = client.PostAsync(string.Format("AddStyleFile/{0}", projectName), content).Result;
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

            HttpResponseMessage res = client.GetAsync(string.Format("DeleteStyleFile/{0}?userId={1}&fileName={2}", projectName, userId, fileName)).Result;
            if (!res.IsSuccessStatusCode)
            {
                throw Utils.DeserializeException(res.Content.ReadAsByteArrayAsync().Result);
            }
        }
    }
}

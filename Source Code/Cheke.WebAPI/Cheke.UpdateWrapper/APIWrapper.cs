using System;
using System.Net.Http;
using System.Text;

namespace Cheke.UpdateWrapper
{
	public static class APIWrapper
    {
		public static string[] GetUpdateInfo(string projectName)
		{
            string baseAddress = System.Configuration.ConfigurationManager.AppSettings["Cheke_UpdateService:BaseAddress"];

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(string.Format("{0}/UpdateService/", baseAddress.TrimEnd('/')));
            HttpContent content = new StringContent(projectName);

            HttpResponseMessage res = client.PostAsync("GetUpdateInfo", content).Result;
            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("The remote server returned an error: (404) Not Found");
            }

            if (!res.IsSuccessStatusCode)
			{
				throw Utils.DeserializeException(res.Content.ReadAsByteArrayAsync().Result);
			}

			return res.Content.ReadAsStringAsync().Result.Split('|');
		}

        public static byte[] GetUpdateFile(string projectName, string fileName)
        {
            string baseAddress = System.Configuration.ConfigurationManager.AppSettings["Cheke_UpdateService:BaseAddress"];

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(string.Format("{0}/UpdateService/", baseAddress.TrimEnd('/')));
            HttpContent content = new StringContent(string.Format("{0}|{1}", projectName, fileName));

            HttpResponseMessage res = client.PostAsync("GetUpdateFile", content).Result;
            if (res.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("The remote server returned an error: (404) Not Found");
            }

            if (!res.IsSuccessStatusCode)
            {
                throw Utils.DeserializeException(res.Content.ReadAsByteArrayAsync().Result);
            }

            return Utils.Decompress(res.Content.ReadAsByteArrayAsync().Result);
        }
    }
}

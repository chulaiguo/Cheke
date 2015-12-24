using System;
using System.Net.Http;

namespace Cheke.UpdateServiceWrapper
{
	public static class UpdateWrapper
    {
		public static string[] GetUpdateInfo(string projectName)
		{
			string baseAddress = System.Configuration.ConfigurationManager.AppSettings["Cheke_UpdateService:BaseAddress"];

			HttpClient client = new HttpClient();
			client.BaseAddress = new Uri(string.Format("{0}/UpdateService/", baseAddress.TrimEnd('/')));

			HttpResponseMessage res = client.GetAsync(string.Format("GetUpdateInfo/{0}", projectName)).Result;
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

            HttpResponseMessage res = client.GetAsync(string.Format("GetUpdateFile/{0}?fileName={1}", projectName, fileName)).Result;
            if (!res.IsSuccessStatusCode)
            {
                throw Utils.DeserializeException(res.Content.ReadAsByteArrayAsync().Result);
            }

            return Utils.Decompress(res.Content.ReadAsByteArrayAsync().Result);
        }
    }
}

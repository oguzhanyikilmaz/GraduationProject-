using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RequestLibrary
{
   public class Requests
    {
        static HttpClient httpClient = new HttpClient();
        public async Task<int> Add(object entity)
        {
            var convertModel = JsonConvert.SerializeObject(entity);
            var content = new StringContent(convertModel, Encoding.UTF8, "application/json");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            var response = await httpClient.PostAsync("https://localhost:44325/api/Payments", content);

            if (response != null)
            {
                return 1;
            }
            else
                return 0;
        }
    }
}

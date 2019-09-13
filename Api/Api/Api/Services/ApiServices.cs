using Api.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
  public  class ApiServices 
    {


        public ApiServices()
        {
        }
        public async Task<Restaurants> getNearBySearch(string results)
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync($"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=18.491955, -69.936898&radius=1500&type=restaurant&keyword=cruise&key=ApiKey");
            return JsonConvert.DeserializeObject<Restaurants>(response);

        }
    }
}

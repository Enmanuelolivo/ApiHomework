using Api.Model;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Api.Services
{
    public interface IApiServices
    {
        [Get("/api/place/nearbysearch/json?location=18.491955, -69.936898&radius=1500&type=restaurant&keyword=cruise&key=ApiKey")]
        Task<Restaurants> getNearBySearch();
    }
}

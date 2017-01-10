using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<string> Index()
        {
            var client = new System.Net.Http.HttpClient { BaseAddress = new Uri("http://localhost:5002") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));

            var response = await client.GetAsync("api/home");
            if (response.IsSuccessStatusCode)
            {                
                using(var stream = await response.Content.ReadAsStreamAsync())
                {
                    var model = ProtoBuf.Serializer.Deserialize<ProtobufModelDto>(stream);
                    return $"{model.Name}, {model.StringValue}, {model.Id}";
                }
            }

            return "Failed";
        }        
    }
}
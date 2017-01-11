using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<string> Index()
        {
            var client = new System.Net.Http.HttpClient { BaseAddress = new Uri("http://localhost:5002") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync("api/home");
            if (response.IsSuccessStatusCode)
            {                
                using(var stream = await response.Content.ReadAsStreamAsync())
                {
                    ProtobufModelDto model = null;
                    if (response.Content.Headers.ContentType.MediaType == "application/x-protobuf")
                    {
                        model = ProtoBuf.Serializer.Deserialize<ProtobufModelDto>(stream);
                        return $"{model.Name}, {model.StringValue}, {model.Id}";
                    }

                    var content = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<ProtobufModelDto>(content);
                    return $"{model.Name}, {model.StringValue}, {model.Id}";  
                }
            }

            return "Failed";
        }        
    }
}
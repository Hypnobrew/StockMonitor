using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Infrastructure;
using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public string Index()
        {
            var client = new System.Net.Http.HttpClient { BaseAddress = new Uri("http://localhost:5002") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-protobuf"));

            var response = client.GetAsync("api/Home").Result;
             
            if (response.IsSuccessStatusCode)
            {                
                var model = response.Content.ReadAsStringAsync().Result;

                var formatter = new ProtobufInputFormatter();
                formatter
                
                //var model = response.Content.ReadAsAsync<ProtobufModelDto>(new[] { new ProtobufInputFormatter()}).Result;
                //return $"{model.Name}, {model.StringValue}, {model.Id}";
            }

            return "Failed";
        }        
    }
}
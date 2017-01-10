using Infrastructure.Model;
using Microsoft.AspNetCore.Mvc;

namespace Crawler.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [HttpGet]

        public ProtobufModelDto Get()
        {
            return new ProtobufModelDto() { 
                Id = 1, 
                Name = "Protobuf test", 
                StringValue = "PoC test message for Protobuf on .Net Core" };
        }        
    }
}
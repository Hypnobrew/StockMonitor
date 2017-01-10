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
            return new ProtobufModelDto() { Id = 1, Name = "HelloWorld", StringValue = "My first MVC 6 Protobuf service" };
        }        
    }
}
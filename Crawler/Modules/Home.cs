using Nancy;

namespace Crawler
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Nancy");
        }
    }
}
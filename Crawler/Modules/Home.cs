using Nancy;

namespace Service1
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Nancy");
        }
    }
}
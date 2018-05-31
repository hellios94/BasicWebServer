using BasicWebServer.Application.Views;
using BasicWebServer.Server.Enums;
using BasicWebServer.Server.HTTP.Contracts;
using BasicWebServer.Server.HTTP.Response;

namespace BasicWebServer.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

            return response;
        }
    }
}
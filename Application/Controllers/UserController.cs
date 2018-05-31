using BasicWebServer.Application.Views;
using BasicWebServer.Server;
using BasicWebServer.Server.Enums;
using BasicWebServer.Server.HTTP.Contracts;
using BasicWebServer.Server.HTTP.Response;

namespace BasicWebServer.Application.Controllers
{
    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };

            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }
    }
}
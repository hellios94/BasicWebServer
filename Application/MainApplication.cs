using BasicWebServer.Application.Controllers;
using BasicWebServer.Server.Routing.Contracts;


namespace BasicWebServer.Application
{
    public class MainApplication
    {
        public void Configure(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.Get("/", request => new HomeController().Index());

            appRouteConfig.Get("/register", request => new UserController()
                          .RegisterGet());

            appRouteConfig.Post("/register", request => new UserController()
                          .RegisterPost(request.FormData["name"]));

            appRouteConfig.Get("/user/{(?<name>[a-z]+)}", request => new UserController()
                          .Details(request.UrlParameters["name"]));
        }
    }
}
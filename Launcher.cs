using BasicWebServer.Server.Routing.Contracts;
using BasicWebServer.Server.Routing;
using BasicWebServer.Application;


namespace BasicWebServer
{
    public class Launcher
    {
        public static void Main()
        {
            int Port = 8230;

            IAppRouteConfig routeConfig = new AppRouteConfig();

            var app = new MainApplication();

            app.Configure(routeConfig);

            BasicWebServer.Server.WebServer webServer = new BasicWebServer.Server.WebServer(Port, routeConfig);

            webServer.Run();
        }
    }
}
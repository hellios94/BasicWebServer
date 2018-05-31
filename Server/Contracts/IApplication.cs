using BasicWebServer.Server.Routing.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebServer.Server.Contracts
{
    public interface IApplication
    {

        void Start(IAppRouteConfig appRouteConfig);

    }
}

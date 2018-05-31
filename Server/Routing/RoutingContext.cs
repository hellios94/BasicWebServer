using System.Collections.Generic;
using BasicWebServer.Server.Handlers;
using BasicWebServer.Server.Routing.Contracts;

namespace BasicWebServer.Server.Routing
{
    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(IEnumerable<string> parameters, RequestHandler requestHandler)
        {
            this.Parameters = parameters;
            this.RequestHandler = requestHandler;
        }

        public IEnumerable<string> Parameters { get; }

        public RequestHandler RequestHandler { get; }
    }
}
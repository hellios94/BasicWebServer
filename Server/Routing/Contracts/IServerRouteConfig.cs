using System.Collections.Generic;
using BasicWebServer.Server.Enums;

namespace BasicWebServer.Server.Routing.Contracts
{
    public interface IServerRouteConfig
    {
        IDictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}
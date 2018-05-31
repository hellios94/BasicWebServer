using System;
using System.Collections.Generic;
using BasicWebServer.Server.Enums;
using BasicWebServer.Server.Handlers;
using BasicWebServer.Server.HTTP.Contracts;

namespace BasicWebServer.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, IDictionary<string, RequestHandler>> Routes { get; }

        void Get(string route, Func<IHttpRequest, IHttpResponse> handler);

        void Post(string route, Func<IHttpRequest, IHttpResponse> handler);

        void AddRoute(string route, HttpRequestMethod method, RequestHandler handler);
    }
}
using BasicWebServer.Server.Handlers.Contracts;
using BasicWebServer.Server.HTTP.Contracts;
using System;


namespace BasicWebServer.Server.Handlers
{
    public class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpRequest, IHttpResponse> handlerFunc;

        public RequestHandler(Func<IHttpRequest, IHttpResponse> handlerFunc)
        {
            this.handlerFunc = handlerFunc;
        }

        public IHttpResponse Handle(IHttpRequest httpRequest)
        {
            IHttpResponse response = this.handlerFunc(httpRequest);

            response.AddHeader("Content-Type", "text/html");

            return response;
        }
    }
}
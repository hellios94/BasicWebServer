using BasicWebServer.Server.HTTP.Contracts;

namespace BasicWebServer.Server.Handlers.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpRequest httpRequest);
    }
}
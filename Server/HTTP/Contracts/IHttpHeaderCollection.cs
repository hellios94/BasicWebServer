using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Server.Handlers.Contracts
{
    public interface IHttpHeaderCollection
    {
        void AddHeader(HttpHeader header);

        bool ContainsKey(string key);

        HttpHeader GetHeader(string key);
    }
}
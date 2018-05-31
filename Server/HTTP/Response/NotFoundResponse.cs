using BasicWebServer.Server.Enums;

namespace BasicWebServer.Server.HTTP.Response
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
        {
            this.StatusCode = HttpStatusCode.NotFound;
        }
    }
}
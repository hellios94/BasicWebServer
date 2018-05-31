using BasicWebServer.Server.Enums;
using BasicWebServer.Server.HTTP.Contracts;
using System.Text;

namespace BasicWebServer.Server.HTTP.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
        protected HttpResponse()
        {
            this.HeaderCollection = new HttpHeaderCollection();
        }

        public HttpHeaderCollection HeaderCollection { get; }

        public HttpStatusCode StatusCode { get; protected set; }

        public string StatusMessage => this.StatusCode.ToString();

        public void AddHeader(string key, string redirectUrl)
        {
            HttpHeader httpHeader = new HttpHeader(key, redirectUrl);

            this.HeaderCollection.AddHeader(httpHeader);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int codeOfStatus = (int)this.StatusCode;

            sb.AppendLine($"HTTP/1.1 {codeOfStatus} {this.StatusMessage}");
            sb.AppendLine(this.HeaderCollection.ToString());
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
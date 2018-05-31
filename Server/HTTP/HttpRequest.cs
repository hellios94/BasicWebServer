using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using BasicWebServer.Server.Enums;
using BasicWebServer.Server.Exceptions;
using BasicWebServer.Server.HTTP.Contracts;


namespace BasicWebServer.Server.HTTP
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, string>();
            this.HeaderCollection = new HttpHeaderCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        public Dictionary<string, string> FormData { get; private set; }

        public HttpHeaderCollection HeaderCollection { get; private set; }

        public string Path { get; private set; }

        public Dictionary<string, string> QueryParameters { get; private set; }

        public HttpRequestMethod RequestMethod { get; private set; }

        public string Url { get; private set; }

        public Dictionary<string, string> UrlParameters { get; private set; }

        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters[key] = value;
        }

        private void ParseRequest(string requestString)
        {
            string[] requestMessageLines = requestString.Split(Environment.NewLine);

            string[] requestLine = requestMessageLines[0]
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                throw new BadRequestException("Invalid request line");
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];

            ParsePath();

            ParseHeaders(requestMessageLines);

            this.ParseParameters();

            this.ParseFormData(requestMessageLines.Last());
        }

        private void ParsePath()
        {
            this.Path = this.Url.Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, String.Empty);

            HttpHeaderCollection httpHeaderCollection = new HttpHeaderCollection();

            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i].Split(new[] { ": " }, StringSplitOptions.RemoveEmptyEntries);

                HttpHeader httpHeader = new HttpHeader(headerArgs[0], headerArgs[1].Trim());

                httpHeaderCollection.AddHeader(httpHeader);
            }

            if (!httpHeaderCollection.ContainsKey("Host"))
            {
                throw new BadRequestException("Invalid request");
            }
        }

        private HttpRequestMethod ParseRequestMethod(string requestMethod)
        {
            if (!Enum.TryParse(requestMethod, out HttpRequestMethod method))
            {
                throw new BadRequestException("Invalid request method");
            }

            return method;
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }
            string query = this.Url
                        .Split(new char[] { '?' }, StringSplitOptions.RemoveEmptyEntries)
                        .Last();

            this.ParseQuery(query, this.UrlParameters);
        }

        private void ParseFormData(string formDataLine)
        {
            if (this.RequestMethod != HttpRequestMethod.POST)
            {
                return;
            }
            this.ParseQuery(formDataLine, this.FormData);
        }

        private void ParseQuery(string query, IDictionary<string, string> dictionary)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split('&');

            foreach (var pair in queryPairs)
            {
                string[] splitted = pair.Split('=');
                if (splitted.Length != 2)
                {
                    return;
                }
                string key = WebUtility.UrlDecode(splitted[0]);
                string value = WebUtility.UrlDecode(splitted[1]);
                dictionary.Add(key, value);
            }
        }
    }
}
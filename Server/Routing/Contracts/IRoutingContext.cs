﻿using BasicWebServer.Server.Handlers;
using System.Collections.Generic;


namespace BasicWebServer.Server.Routing.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}
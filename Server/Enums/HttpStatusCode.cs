﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BasicWebServer.Server.Enums
{
    public enum HttpStatusCode
    {
        OK = 200,
        MovedPermamently = 301,
        Found = 302,
        MovedTemporary = 303,
        NotAuthorized = 401,
        NotFound = 404,
        InternalServerError = 500
    }
}

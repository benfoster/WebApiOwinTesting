﻿using System.Collections.Generic;
using System.Web.Http;

namespace WebApiOwinTesting.Controllers
{
    public class ValuesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new[] { "hello", "world" };
        }

        public string Get(int id)
        {
            return "hello world";
        }
    }
}

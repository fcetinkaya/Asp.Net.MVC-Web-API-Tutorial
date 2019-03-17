using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI_Example.Controllers
{
    [EnableCors("*", "*", "*")] // All method,header share...
    public class CityController : ApiController
    {
        string[] GetOne = { "Fatih", "Mahmut", "Melike", "Selma" };
        public string[] Get()
        {
            return GetOne;
        }

        public string Get(int id)
        {
            return GetOne[0];
        }
    }
}

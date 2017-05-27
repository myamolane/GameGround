using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace GameGround.Api.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        [HttpGet]
        public Metadata<string> Index()
        {
            return new Metadata<string>("From TestController");
        }
        
        
    }
}
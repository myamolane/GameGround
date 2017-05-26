using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameGround.Api.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet,Route("get")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
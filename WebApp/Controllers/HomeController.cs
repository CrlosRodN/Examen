using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Security;

namespace WebApp.Controllers
{
    [SecurityFilter]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult vCustomers()
        {
            
            return View();
        }

        public ActionResult eCustomers()
        {
            return View();
        }

        public ActionResult vCuenta()
        {

            return View();
        }

        public ActionResult vDiraccion()
        {

            return View();
        }

        public ActionResult vCredito()
        {

            return View();
        }
    }
}
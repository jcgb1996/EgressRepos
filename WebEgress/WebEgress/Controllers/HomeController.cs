﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEgress.Helper;

namespace WebEgress.Controllers
{
    //[SesionActiva]
    [NoLogin]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CargarLayoutHome()
        {
            //ViewBag.Message = "Your application description page.";

            return View("VistaPrueba");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HoplaHelpdesk.Models;
using System.Data.SqlClient;

namespace HoplaHelpdesk.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        hoplaEntities db = new hoplaEntities();

        public ActionResult Index()
        {
            try
            {
                if (!db.DatabaseExists())
                {
                    //throw new SqlException();
                }
            }
            catch(SqlException)
            {
                ViewData["Message"] = "Could not connect to database!";

                return View();
            }
            ViewData["Message"] = "Welcome to Hopla Helpdesk";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
﻿using MusicStore.Core.Interfaces.Repository;
using MusicStore.Core.Models;
using MusicStore.Infrastructure.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IDatabaseCalls dbinterface = new DatabaseCallImpl();
           // DatabaseCallImpl dbc = new DatabaseCallImpl(); 
            List<DataContentsModel> data =dbinterface.GetAllData("~/App_Data/Data.json");
            return View(data);
           
        }

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
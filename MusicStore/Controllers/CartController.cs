using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Service;
using MusicStore.Interfaces;

namespace MusicStore.Controllers
{
    public class CartController : Controller
    {
        
        // GET: Cart
        public ActionResult Index()
        {
            DatabaseCalls dbc = new DatabaseCallImpl();

            List<DataContentsModel> listofselecteddata = dbc.getAllData("~/App_Data/Cart.json");

            if (!listofselecteddata.Any())

                return View("NoItemInCart");
            else

                return View(listofselecteddata);
        }

        [HttpPost]
        public string Index(DataContentsModel dataset)
        {
            //Console.Write(dataset);
           // listofselecteddata.Add(dataset);
            DatabaseCalls dbc = new DatabaseCallImpl();
            string response = dbc.writeData(dataset);
            return "successfull";
        }

    }
}
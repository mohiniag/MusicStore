using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class CartController : Controller
    {
        List<DataContentsModel> listofselecteddata = new List<DataContentsModel>();
        // GET: Cart
        public ActionResult Index(DataContentsModel dataset)
        {
            Console.Write(dataset);
            listofselecteddata.Add(dataset);
            return View(listofselecteddata);
        }


    }
}
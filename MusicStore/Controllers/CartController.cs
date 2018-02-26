using MusicStore.Models;
using System.Collections.Generic;
using System.Linq;
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

            List<DataContentsModel> listofselecteddata = dbc.GetAllData("~/App_Data/Cart.json");

            if (!listofselecteddata.Any())

                return View("NoItemInCart");
            else

                return View(listofselecteddata);
        }

        [HttpPost]
        public void Index(DataContentsModel dataset)
        {
            DatabaseCalls dbc = new DatabaseCallImpl();
            string response = dbc.AddToCart(dataset);
            
        }
        [HttpPost]
        public void RemoveItem(int ID)
        {
            System.Console.Write(ID);
            DatabaseCalls dbc = new DatabaseCallImpl();
            string response=dbc.RemoveFromCart(ID);
        }

    }
}
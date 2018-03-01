using MusicStore.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MusicStore.Infrastructure.Repository;
using MusicStore.Core.Interfaces.Repository;

namespace MusicStore.Controllers
{
    public class CartController : Controller
    {
        
        // GET: Cart
        public ActionResult Index()
        {
            IDatabaseCalls dbc = new DatabaseCallImpl();

            List<DataContentsModel> listofselecteddata = dbc.GetAllData("~/App_Data/Cart.json");

            if (!listofselecteddata.Any())

                return View("NoItemInCart");
            else

                return View(listofselecteddata);
        }

        [HttpPost]
        public void Index(DataContentsModel dataset)
        {
            IDatabaseCalls dbc = new DatabaseCallImpl();
            string response = dbc.AddToCart(dataset);
            
        }
        [HttpPost]
        public void RemoveItem(int ID)
        {
            System.Console.Write(ID);
            IDatabaseCalls dbc = new DatabaseCallImpl();
            string response=dbc.RemoveFromCart(ID);
        }
        public ActionResult Payment(decimal amount)
        {
            return RedirectToRoute("payment", new { amount = amount});
        }

    }
}
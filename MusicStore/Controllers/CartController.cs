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
        private readonly IDatabaseCalls _dbCall;

        public CartController()
        {

        }
        public CartController(IDatabaseCalls _dbCall)
        {
            this._dbCall = _dbCall;
        }


        // GET: Cart
        public ActionResult Index()
        {
                  
            List<DataContentsModel> listofselecteddata = _dbCall.GetAllData(Constants.Constants.cartUrl);

            if (listofselecteddata == null)
                return View("ErrorLoading");
            else if (!listofselecteddata.Any())
                return View("NoItemInCart");
            else

                return View(listofselecteddata);

        }

        [HttpPost]
        public string Index(DataContentsModel dataset)
        {
          
            string response = _dbCall.AddToCart(dataset);
            return response;

        }
        [HttpPost]
        public string RemoveItem(int ID)
        {
            string response = _dbCall.RemoveFromCart(ID);
            return response;
        }
        public ActionResult Payment(decimal amount)
        {
            return RedirectToRoute("payment", new { amount = amount });
        }

    }
}
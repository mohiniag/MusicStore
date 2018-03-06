using MusicStore.Core.Models;
using System.Web.Mvc;
using MusicStore.Business;
using System;
using MusicStore.Core.Interfaces.Repository;

namespace MusicStore.Controllers
{
    public class MakePaymentController : Controller
    {
        // GET: MakePayment

       [Route("MakePayment/{pay}/{amount}")]
        public ActionResult pay(decimal amount)
        {
           
            return View();
        }

        public ActionResult Index(CustomerDetails model)
        {
            IPaymentGateway paymentGateway = new PaymentGateway();
            try
            {
                if (ModelState.IsValid)
                {
         
                    model.CardFee = 100;
                    model.customerIp = "172.10.114";
                    //to be removed
                    model.payableAmount = "55.5";
                    // call business layer 
                    paymentGateway.FetchedCustomerDetails(model);
                }
                else
                {
                    return View("index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("error");
            }

            return View("confirmation", model);
        }

      

       

        

               

    

    }
}
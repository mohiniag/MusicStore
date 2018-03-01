using MusicStore.Core.Models;
using System.Web.Mvc;
using MusicStore.Business.BusinessLogic;
using System;

namespace MusicStore.Controllers
{
    public class MakePaymentController : Controller
    {
        // GET: MakePayment

       [Route("pay/{amount:decimal}/")]
        public ActionResult Index(decimal amount)
        {
           
            return View();
        }

        public ActionResult Index(CustomerDetails model)
        {
            PaymentGateway paymentGateway = new PaymentGateway();
            try
            {
                if (ModelState.IsValid)
                {
                    model.Id = 1;
                    model.CardFee = 100;
                    model.customerIp = "172.10.114";
                    // call business layer 
                    var objData = paymentGateway.FetchedCustomerDetails(model);
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
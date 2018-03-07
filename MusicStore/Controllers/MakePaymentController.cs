using MusicStore.Core.Models;
using System.Web.Mvc;
using MusicStore.Core.Interfaces.Repository;
using MusicStore.Business.PaymentGateway;

namespace MusicStore.Controllers
{
    public class MakePaymentController : Controller
    {
        // GET: MakePayment

        [Route("pay/{amount:decimal}/creditcard")]
        public ActionResult Index(decimal amount)
        {
            CustomerDetails customerDetails = new CustomerDetails();
            customerDetails.payableAmount = amount.ToString();
            return View(customerDetails);
        }
        [HttpPost]
        public ActionResult pay(CustomerDetails model)
        {
            IPaymentGateway paymentGateway = new PaymentGateway();

            if (ModelState.IsValid)
            {

                model.CardFee = 100;
                model.customerIp = "172.10.114";

                string paymentconfirmation = paymentGateway.FetchedCustomerDetails(model);

                ViewBag.Data = paymentconfirmation;
                return View("index");
            }
            else
            {
                ViewBag.Data = "Enter Valid Details";
                return View("index");
            }
            
        }

    }
}
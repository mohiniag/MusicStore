using MusicStore.Core.Models;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class MakePaymentController : Controller
    {
        // GET: MakePayment
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet, Route("pay/{amount}")]
        public ActionResult Index(string amount)
        {
            CustomerDetails customer = new CustomerDetails();
            customer.payableAmount = amount;
            return View(customer);
        }
    }
}
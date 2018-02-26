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
        [HttpPost]
        public ActionResult Index(string amount)
        {
            return View();
        }
    }
}
using MusicStore.Core.Interfaces.Repository;
using MusicStore.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MusicStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDatabaseCalls _dbCall;


        public HomeController(IDatabaseCalls _dbCall)
        {
            this._dbCall = _dbCall;
        }

        public ActionResult Index()
        {
          

            List<DataContentsModel> data = _dbCall.GetAllData(Constants.Constants.dataUrl);
            if (data == null|| !data.Any())
            {
                return View("Error");
            }
            return View(data);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
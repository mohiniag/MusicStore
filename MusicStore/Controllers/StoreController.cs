using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        
        public ActionResult Index()
        {
            //var catagories = storeDB.Catagories.ToList();

            //  return View(catagories);
           // return View();
            var genres = new List<Genre>
             {
               new Genre { Name = "Disco"},
                new Genre { Name = "Jazz"},
              new Genre { Name = "Rock"}
             };
            return View(genres);
        }

        //
        // GET: /Store/Browse?genre=Disco

        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Items from database
            //var catagorieModel = storeDB.Catagories.Include("Items")
            //  .Single(g => g.Name == catagorie);

            //return View(catagorieModel);
            var genreModel = new Genre { Name = genre };
            return View(genreModel);
            
        }

        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            //var item = storeDB.Items.Find(id);

            // return View(item);
            var album = new Album { Title = "Album " + id };
            return View(album);
            
        }
    }
}
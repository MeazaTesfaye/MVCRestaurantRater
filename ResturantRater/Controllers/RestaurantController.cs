using RestaurantRater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResturantRater.Controllers
{
    public class RestaurantController : Controller
    {
        private RestaurantDbContext _db = new RestaurantDbContext();
        // GET: Restaurant/Index
        public ActionResult Index() //gives us in action
        {

            return View(_db.Restaurants.ToList());
        }

        //Get : Restaurant Create
        public ActionResult Create()
        {
            return View();
        }

        //Post:Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create (Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _db.Restaurants.Add(restaurant);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(restaurant);
        }
    }
}
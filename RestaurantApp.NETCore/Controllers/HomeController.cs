using Microsoft.AspNetCore.Mvc;
using RestaurantApp.NETCore.Entities;
using RestaurantApp.NETCore.Models;
using RestaurantApp.NETCore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.NETCore.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        public HomeController(IRestaurantData restaurantData)
        {
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreeting = "Hello, from configurable file";

            return View(model: model);
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                _restaurantData.Add(restaurant);

                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, RestaurantEditViewModel input)
        {
            var restaurant = _restaurantData.Get(id);
            if (restaurant != null  && ModelState.IsValid)
            {
                restaurant.Name = input.Name;
                restaurant.Cuisine = input.Cuisine;

                return RedirectToAction("Details", new { id = restaurant.Id });
            }

            return View(restaurant);
        }
    }
}

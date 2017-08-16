using Microsoft.AspNetCore.Mvc;
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
    }
}

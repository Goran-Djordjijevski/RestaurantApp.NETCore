using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantApp.NETCore.Controllers
{
    [Route("[controller]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "+1-555-555-555-555";
        }

        [Route("[action]")]
        public string Country()
        {
            return "Serbia";
        }
    }
}

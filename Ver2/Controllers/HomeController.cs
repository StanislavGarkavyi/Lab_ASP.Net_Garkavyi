using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ver2.Data.Interfaces;
using Ver2.ViewModels;

namespace Ver2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllRooms _carRep;
        public HomeController(IAllRooms carRep)
        {
            _carRep = carRep;
        }
        [Route("")]
        public ViewResult Index()
        {
            var homeCars = new HomeViewModel
            {
                favRoom = _carRep.getFavRooms
            };
        return View(homeCars);
        }
    }
}
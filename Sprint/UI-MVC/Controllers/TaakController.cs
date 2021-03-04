using System;
using System.Collections.Generic;
using GP.BL;
using GP.BL.Domain;
using Microsoft.AspNetCore.Mvc;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class TaakController : Controller
    {
        private IManager _mgr;

        public TaakController()
        {
            _mgr = new Manager();
        }
       
        public IActionResult Index()
        {
            List<Taak> allTaken = _mgr.GetAllTaken();
            return View(allTaken);
        }
        

        public IActionResult Details(Functie functie, double uur)
        { 
            var taken = _mgr.GetAllTakenWithFunctieAndUur(functie,uur);
            return View(taken);
        }
    }
}
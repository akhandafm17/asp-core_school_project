using System.Collections.Generic;
using GP.BL;
using GP.BL.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class WerknemerController : Controller
    {

        private IManager _mgr;

        public WerknemerController()
        {
            _mgr = new Manager();
        }
        public IActionResult Index()
        {
            List<Werknemer> werknemersList = _mgr.GetAllWerknemers();
            return View(werknemersList);
        } 

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult RemoveError()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddWerknemerModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var werknemer = _mgr.AddWerknemer(
                model.Werknemer.Pid,
                model.Werknemer.WerkgeverPid,
                model.Werknemer.Naam,
                model.Werknemer.Uurloon,
                model.Werknemer.Werkdag,
                model.Werknemer.Functie
            );
            return RedirectToAction("Details", new {id=werknemer.Pid});
        }

        

        public IActionResult Details(int id)
        {
            WerknemerDetailsModel werknemer = new WerknemerDetailsModel()
            {
                Id = id,
                Werknemer = _mgr.GetWerknemerWithtaken(id)
            };
            return View(werknemer);
        }

        public IActionResult Delete(int taakid)
        {
            TaakModel taakModel = new TaakModel()
            {
                Taak = _mgr.GetTaak(taakid)
            };
            return View(taakModel);
        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int pid,int taakid)//0,8
        {

            if (pid != 0 || taakid != 0)
            {
                _mgr.DeleteWerknemerTaak(pid,taakid);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("removeError");
            }
        }

    }
}
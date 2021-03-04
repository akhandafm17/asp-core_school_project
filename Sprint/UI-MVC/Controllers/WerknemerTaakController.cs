using GP.BL;
using GP.BL.Domain;
using Microsoft.AspNetCore.Mvc;
using UI_MVC.Models;

namespace UI_MVC.Controllers
{
    public class WerknemerTaakController : Controller
    {
        private IManager _mgr;

        public WerknemerTaakController()
        {
            _mgr = new Manager();
        }
        
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult Add(AddWerknemerTaak model)
        {
            
            int pid = model.WerknemerTaak.Werknemer.Pid;
           
            Taak taak = new Taak()
            {
                TaakId = model.WerknemerTaak.Taak.TaakId,
                Functie = model.WerknemerTaak.Taak.Functie,
                Pid = pid,
                Uur = model.WerknemerTaak.Taak.Uur
            };
            
            WerknemerTaak werknemerTaak = new WerknemerTaak()
            {
                Afdeling = model.WerknemerTaak.Afdeling,
                Taak = taak,
                Taakbeschrijving = model.WerknemerTaak.Taakbeschrijving,
                Werknemer = _mgr.GetWerknemer(pid)
            };
            _mgr.CreateWerknemerTaak(werknemerTaak);
            return RedirectToAction("Details","Werknemer", new {id=werknemerTaak.Werknemer.Pid});
        }
    }
}
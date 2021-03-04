using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GP.BL.Domain;
using GP.DAL;
using GP.DAL.EF;

namespace GP.BL
{
    public class Manager : IManager
    {
        //private readonly IRepository _repo;
        private readonly Repository _repo;

        public Manager()
        {
            _repo = new Repository();
        }

        public Werknemer AddWerknemer(int pid,int werkgeverpid, string naam, double? uurloon, DateTime werkdag,
            Functie functie = Functie.I) {
            
            var werknemer = new Werknemer(pid,werkgeverpid,naam,uurloon,werkdag,functie);
            if (Validate(werknemer))
            {
                _repo.CreateWerknemer(werknemer);
            }
            return werknemer;
        }

        public Taak AddTaak(int taakId, int pid, double uur, Functie functie)
        {
            var taak = new Taak(taakId,pid,uur,functie);
            if (Validate(taak))
            {
                _repo.CreateTaak(taak);
            }
            return taak;
            
        }

        private void AddWerknemer(Werknemer werknemer)
        {
             _repo.CreateWerknemer(werknemer);
        }

        private void AddTaak(Taak taak)
        {
             _repo.CreateTaak(taak);
        }
        public Werknemer GetWerknemer(int id)
        {
            return _repo.ReadWerknemer(id);
        }
        

        public List<Werkgever> GetAllWerkgevers()
        {
            return _repo.ReadAllWerkgevers();
        }

        public List<Werknemer> GetWerknemersByFunctie(int cijfer)
        {
            return _repo.ReadWerknemerByFunctie(cijfer);
        }

        public Werknemer GetWerknemerWithWerkgever(int id)
        {
            return _repo.ReadWerknemerWithWerkgever(id);
        }

        public Werknemer GetWerknemerWithtaken(int id)
        {
            return _repo.ReadWerknemerWithTaken(id);
        }

        public Taak GetTaak(int id)
        {
            return _repo.ReadTaak(id);
        }

        public List<Taak> GetTakenByFunctie(int cijfer)
        {
            return _repo.ReadTakenByFunctie(cijfer);
        }

        public List<Taak> GetTakenByUur(double uur)
        {
            return _repo.ReadTakenByUur(uur);
        }

        public List<Taak> GetTakenByFunctieAndUur(int cijfer, double uur)
        {
            return _repo.ReadTakenByFunctieAndUur(cijfer, uur);
        }

        public List<Werknemer> GetAllWerknemers()
        {
            return _repo.ReadAllWerknemers();
        }

        public List<Taak> GetAllTaken()
        {
            return _repo.ReadAllTaken();
        }

        public Werknemer GetWerknemerByName(string naam)
        {
            return GetAllWerknemers().Find(x => x.Naam.Equals(naam));
        }

        public Taak GetTaakById(int id)
        {
            return GetAllTaken().Find(x => x.TaakId.Equals(id));
        }

        public List<Taak> GetAllTakenFromWerknemer(int pid)
        {
            return _repo.ReadWerknemerTaak(pid);
        }

        public List<Werknemer> GetAllWerknemersWithTaken()
        {
            return _repo.ReadAllWerknemersWithTaken();
        }

        public List<Taak> GetAllTakenWithWerknemers()
        {
            return _repo.ReadAllTakenWithWerknemers();
        }

        public List<Werknemer> GetAllWerknemersWithWerkgever()
        {
            return _repo.ReadAllWerknemersWithWerkgever();
        }

     

        public void CreateWerknemerTaak(WerknemerTaak werknemerTaak)
        {
             _repo.CreateWerknemerTaak(werknemerTaak);
        }

        public void DeleteWerknemerTaak(int werknemerId, int taakId)
        {
            _repo.DeleteWerknemerTaak(werknemerId,taakId);
        }

        public List<Taak> GetAllTakenWithFunctieAndUur(Functie functie, double uur)
        {
            return _repo.ReadAllTakenWithFunctieAndUur(functie, uur);
        }


        private static bool Validate(Werknemer werknemer)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(werknemer, new ValidationContext(werknemer), errors, true);
            if (valid) 
                return true;
            
            foreach (var error in errors)
                Console.WriteLine(error.ErrorMessage);
            return false;

        }
        private static bool Validate(Taak taak)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            bool valid = Validator.TryValidateObject(taak, new ValidationContext(taak), errors, true);
            if (valid) 
                return true;
            
            foreach (var error in errors)
                Console.WriteLine(error.ErrorMessage);
            return false;
        }
    }
}
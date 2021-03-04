using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using GP.BL.Domain;
using Microsoft.EntityFrameworkCore;

namespace GP.DAL.EF
{
    public class Repository : IRepository
    {
        private SprintDbContext ctx { get; set; }

        public Repository()
        {
            ctx = new SprintDbContext();
        }

        public Werknemer ReadWerknemer(int id)
        {
            return ctx.Werknemers.Find(id);
        }

    
        public Werknemer ReadWerknemerWithWerkgever(int id)
        {
            return ctx.Werknemers.Where(x => x.Pid == id).Include(x => x.Werkgever).ThenInclude(x => x.Naam).First();
        }

        public Werknemer ReadWerknemerWithTaken(int id)
        {
            return ctx.Werknemers.Where(x => x.Pid.Equals(id)).Include(x => x.Taken).ThenInclude(x => x.Taak).First();
        }

        public Taak ReadTaak(int id)
        {
            return ctx.Taken.Find(id);
        }

        public List<Werkgever> ReadAllWerkgevers()
        {
            return ctx.Werkgevers.ToList();
        }

        public List<Werknemer> ReadAllWerknemers()
        {
            return ctx.Werknemers.ToList();
        }

        public List<Taak> ReadAllTaken()
        {
            return ctx.Taken.ToList();
        } 

        public List<Werknemer> ReadWerknemerByFunctie(int cijfer)
        {
            var item = (Functie)Enum.GetValues(typeof(Functie)).GetValue(cijfer-1);
            return new List<Werknemer>(ctx.Werknemers.Where(x => x.Functie.Equals(item)));
        }

        public List<Taak> ReadTakenByFunctie(int cijfer)
        {
            var item = (Functie)Enum.GetValues(typeof(Functie)).GetValue(cijfer-1);
            return  new List<Taak>(ctx.Taken.Where(x => x.Functie.Equals(item)));
        }

        public List<Taak> ReadTakenByUur(double uur)
        {
            return new List<Taak>(ctx.Taken.Where(x => x.Uur.Equals(uur)));
        }

        public List<Taak> ReadTakenByFunctieAndUur(int cijfer, double uur)
        {
            var item = (Functie)Enum.GetValues(typeof(Functie)).GetValue(cijfer-1);
            return new List<Taak>(ctx.Taken.Where(x => x.Functie.Equals(item) && x.Uur.Equals(uur)));
        }

        public void CreateWerknemer(Werknemer werknemer)
        {
            ctx.Werknemers.Add(werknemer);
            ctx.SaveChanges();
        }

        public void CreateTaak(Taak taak)
        {
            ctx.Taken.Add(taak);
            ctx.SaveChanges();
        }

        public void Delete(Werknemer wm)
        {
            ctx.Werknemers.Remove(wm);
            ctx.SaveChanges();
        }

        public void Delete(Werkgever wg)
        {
            ctx.Werkgevers.Remove(wg);
            ctx.SaveChanges();
        }

        public void Delete(Taak t)
        {
            ctx.Taken.Remove(t);
            ctx.SaveChanges();
        }
        
        public List<Taak> ReadWerknemerTaak(int pid)
        {
            return ctx.Taken.Where(x => x.Pid.Equals(pid)).Include(x => x.Taken).ToList();
        }
        public List<Werknemer> ReadAllWerknemersWithTaken()
        {
            var taken = ctx.Werknemers.Include(x => x.Taken).ThenInclude(x => x.Taak).ToList();
            return taken;
        }

        public List<Taak> ReadAllTakenWithWerknemers()
        { 
            return ctx.Taken
                .Include(x => x.Werknemers)
                .ThenInclude(x => x.Werknemer)
                .ToList();
        }

        public List<Werknemer> ReadAllWerknemersWithWerkgever()
        {
            return ctx.Werknemers.Include(x => x.Werkgever).ToList();
        }

        
        public void CreateWerknemerTaak(WerknemerTaak werknemerTaak)
        {
            ctx.WerknemerTaken.Add(werknemerTaak);
            ctx.SaveChanges();
        }

        public void DeleteWerknemerTaak(int werknemerId, int taakId)
        {
           // var werknemerTaak = ctx.WerknemerTaken.FirstOrDefault(x => x.Werknemer.Pid.Equals(werknemerId) && x.Taak.TaakId.Equals(taakId));
            //var taak = ctx.Taken.First(x => x.TaakId.Equals(taakId));
            //ctx.Taken.Remove(taak);
            var taak = ctx.Taken.FirstOrDefault(x => x.Pid.Equals(werknemerId) && x.TaakId.Equals(taakId));
            if (taak == null)
            {
                ctx.Taken.Remove(taak);
            }
            else
            {
                 taak = ctx.Taken.First(x => x.Pid.Equals(werknemerId) && x.TaakId.Equals(taakId));
                 ctx.Taken.Remove(taak);
            }
            //ctx.WerknemerTaken.Remove(werknemerTaak);
           ctx.SaveChanges();
        }

        public WerknemerTaak GetWerknemerTaakId(int taakId)
        {
            return ctx.WerknemerTaken.FirstOrDefault(x => x.Taak.TaakId.Equals(taakId));
        }

        public List<Taak>ReadAllTakenWithFunctieAndUur(Functie functie, double uur)
        {
            return ctx.Taken.ToList().FindAll(x => x.Functie.Equals(functie) && x.Uur.Equals(uur));
        }
    }
}
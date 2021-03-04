using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using GP.BL.Domain;

namespace GP.DAL
{
    public class InMemoryRepository : IRepository
    {
        private static readonly List<Werknemer> _werknemers = new List<Werknemer>();
        private static readonly List<Taak> _taken = new List<Taak>();

         static InMemoryRepository()
         {
             Seed();
         }

         private static void Seed() 
         {
             _taken.Add(new Taak(1,1, 8.00, Functie.F));
             _taken.Add(new Taak(2,7, 8.30, Functie.F));
             _taken.Add(new Taak(3,2, 9.00, Functie.I));
             _taken.Add(new Taak(4,4, 10.00, Functie.I));
             _taken.Add(new Taak(5,3, 10.00, Functie.B));
             _taken.Add(new Taak(6,6, 14.00, Functie.B1));
             _taken.Add(new Taak(7,5, 06.00, Functie.B2));
             _werknemers.Add(new Werknemer(1,8,"Marwan Akhandaf",11.20,new DateTime(2020,9,26),Functie.I));
             _werknemers.Add(new Werknemer(2,8,"Moncef Akhandaf",10.00,new DateTime(2020,9,26),Functie.F));
             _werknemers.Add(new Werknemer(3,8,"Naila Akhandaf",10.00,new DateTime(2020,9,25),Functie.B));
             _werknemers.Add(new Werknemer(4,8,"Sofie Vanderbergen",18.50,new DateTime(2020,9,26),Functie.I));
             _werknemers.Add(new Werknemer(5,8,"Loic meeuws",9.20,new DateTime(2020,9,26),Functie.I));
             _werknemers.Add(new Werknemer(6,8,"Nathan Deridder",14.40,new DateTime(2020,9,27),Functie.I));
             _werknemers.Add(new Werknemer(7,8,"Maxi Kaleta",12.00,new DateTime(2020,12,26),Functie.F));
             _werknemers.Add(new Werknemer(8,8,"Malika tabit",20.00,new DateTime(2020,11,15),Functie.Z));
         }


         public Werknemer ReadWerknemer(int id)
         {
             return _werknemers.Find(x => x.Pid.Equals(id));
         }

         public WerknemerTaak ReadWerknemerByTaakId(Werknemer werknemer, Taak taak)
         {
             throw new NotImplementedException();
         }

         public WerknemerTaak ReadWerknemerByTaakId(int taakid)
         {
             throw new NotImplementedException();
         }

         public Werknemer ReadWerknemerWithWerkgever(int id)
         {
             throw new NotImplementedException();
         }

         public Werknemer ReadWerknemerWithTaken(int id)
         {
             throw new NotImplementedException();
         }

         public Taak ReadTaak(int id)
         {
             return _taken.Find(x => x.TaakId.Equals(id));
         }

         public List<Werkgever> ReadAllWerkgevers()
         {
             throw new NotImplementedException();
         }


         public List<Werknemer> ReadAllWerknemers()
         {
             return _werknemers;
         }

         public List<Taak> ReadAllTaken()
         {
             return _taken;
         }

         public List<Werknemer> ReadWerknemerByFunctie(int cijfer)
         {
             var item = (Functie)Enum.GetValues(typeof(Functie)).GetValue(cijfer-1);
             return _werknemers.FindAll(x => x.Functie.Equals(item));
         }

         public List<Taak> ReadTakenByFunctie(int cijfer)
         {
             var item = (Functie)Enum.GetValues(typeof(Functie)).GetValue(cijfer-1);
             return _taken.FindAll(x => x.Functie.Equals(item));
         }

         public List<Taak> ReadTakenByUur(double uur)
         {
             return _taken.FindAll(x => x.Uur.Equals(uur));
         }

         public List<Taak> ReadTakenByFunctieAndUur(int cijfer, double uur)
         {
             var item = (Functie)Enum.GetValues(typeof(Functie)).GetValue(cijfer-1);
             return _taken.FindAll(x => x.Functie.Equals(item) && x.Uur.Equals(uur));
         }

         public void CreateWerknemer(Werknemer werknemer)
         {
             throw new NotImplementedException();
         }

         public void CreateTaak(Taak taak)
         {
             throw new NotImplementedException();
         }

         public void Delete(Werknemer wm)
         {
             throw new NotImplementedException();
         }

         public void Delete(Werkgever wg)
         {
             throw new NotImplementedException();
         }

         public void Delete(Taak t)
         {
             throw new NotImplementedException();
         }

         public List<Taak> ReadWerknemerTaak(int pid)
         {
             throw new NotImplementedException();
         }

         public List<Werknemer> ReadAllWerknemersWithTaken()
         {
             throw new NotImplementedException();
         }

         public List<Taak> ReadAllTakenWithWerknemers()
         {
             throw new NotImplementedException();
         }

         public List<Werknemer> ReadAllWerknemersWithWerkgever()
         {
             throw new NotImplementedException();
         }

         public Werknemer ReadWerknemerWithWerkgever()
         {
             throw new NotImplementedException();
         }

         public void CreateWerknemerTaak(WerknemerTaak werknemerTaak)
         {
             throw new NotImplementedException();
         }

         public void DeleteWerknemerTaak(int werknemerId, int taakId)
         {
             throw new NotImplementedException();
         }

         public WerknemerTaak GetWerknemerTaakId(int taakId)
         {
             throw new NotImplementedException();
         }

         public List<Taak> ReadAllTakenWithFunctieAndUur(Functie functie, double uur)
         {
             throw new NotImplementedException();
         }

         public List<Taak> ReadAllTakenWithTaakidAndPid(int taakID, int pid)
         {
             throw new NotImplementedException();
         }

         public List<WerknemerTaak> readPidFromTaakId(int taakId)
         {
             throw new NotImplementedException();
         }
    }
}
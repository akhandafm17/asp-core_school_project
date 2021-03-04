using System.Collections.Generic;
using System.Linq;
using GP.BL.Domain;

namespace GP.DAL
{
    public interface IRepository
    {
        Werknemer ReadWerknemer(int id);
       
        Werknemer ReadWerknemerWithWerkgever(int id);
        Werknemer ReadWerknemerWithTaken(int id);
        Taak ReadTaak(int id);
        List<Werkgever> ReadAllWerkgevers();
        List<Werknemer> ReadAllWerknemers();
        List<Taak> ReadAllTaken();
        List<Werknemer>ReadWerknemerByFunctie(int cijfer);
        List<Taak> ReadTakenByFunctie(int cijfer);
        List<Taak> ReadTakenByUur(double uur);
        List<Taak>ReadTakenByFunctieAndUur(int cijfer, double uur);
        void CreateWerknemer(Werknemer werknemer);
        void CreateTaak(Taak taak);

        void Delete(Werknemer wm);
        void Delete(Werkgever wg);
        void Delete(Taak t);
       // public List<WerknemerTaak> ReadWerknemerTaak(int pid);
        public List<Taak> ReadWerknemerTaak(int pid);
        public List<Werknemer> ReadAllWerknemersWithTaken();
        public List<Taak> ReadAllTakenWithWerknemers();
        public List<Werknemer> ReadAllWerknemersWithWerkgever();

        void CreateWerknemerTaak(WerknemerTaak werknemerTaak);
        void DeleteWerknemerTaak(int werknemerId, int taakId);
        WerknemerTaak GetWerknemerTaakId(int taakId);
       List<Taak> ReadAllTakenWithFunctieAndUur(Functie functie, double uur);

    }
}
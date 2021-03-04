using System;
using System.Collections.Generic;
using GP.BL.Domain;

namespace GP.BL
{
    public interface IManager
    {
        Werknemer AddWerknemer(int pid,int werkgeverpid, string naam, double? uurloon, DateTime werkdag,
            Functie functie = Functie.I);

        Taak AddTaak(int taakId, int pid, double uur, Functie functie);
        Werknemer GetWerknemer(int id);
        
        List<Werkgever> GetAllWerkgevers();
        List<Werknemer> GetWerknemersByFunctie(int cijfer);
        Werknemer GetWerknemerWithWerkgever(int id);
        Werknemer GetWerknemerWithtaken(int id);
        Taak GetTaak(int id);
        List<Taak> GetTakenByFunctie(int cijfer);
        List<Taak> GetTakenByUur(double uur);
        List<Taak> GetTakenByFunctieAndUur(int cijfer, double uur);
        List<Werknemer> GetAllWerknemers();
        List<Taak> GetAllTaken();
        Werknemer GetWerknemerByName(string naam);
        Taak GetTaakById(int id);
        List<Taak> GetAllTakenFromWerknemer(int pid);
        List<Werknemer> GetAllWerknemersWithTaken();
        List<Taak> GetAllTakenWithWerknemers();
        void CreateWerknemerTaak(WerknemerTaak werknemerTaak);
        void DeleteWerknemerTaak(int werknemerId, int taakId);
        List<Taak> GetAllTakenWithFunctieAndUur(Functie functie, double uur);




    }
}
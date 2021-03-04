using System;
using System.Collections.Generic;
using System.Linq;
using GP.BL;
using GP.BL.Domain;

namespace GP.UI.CA
{
    class Program
    {
        private static IManager _mgr;
        static void Main(string[] args)
        {
            _mgr = new Manager();
           int keuze;
            Werknemer werkn = new Werknemer();
           // List<Werknemer> werknemers = _mgr.GetAllWerknemers();
            Taak taak = new Taak();
           // List<Taak> taken = _mgr.GetAllTaken();
            
            
            do
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("=============================");
                Console.WriteLine("0) Quit");
                Console.WriteLine("1) show all werknemers");
                Console.WriteLine("2) show all Taken");
                Console.WriteLine("3) show werkgever details");
                Console.WriteLine("4) show werknemers of Functie");
                Console.WriteLine("5) show Taken of Functie and/or uur");
                Console.WriteLine("6) Voeg werknemer toe");
                Console.WriteLine("7) Voeg Taak toe");
                Console.WriteLine("8) Voeg Taak toe aan Werknemer");
                Console.WriteLine("9) Verwijder Taak van Werknemer");
                bool valid = int.TryParse(Console.ReadLine(), out keuze);
                

                switch (keuze)
                {
                    case 1:
                        _mgr.GetAllWerknemersWithTaken().ForEach(x =>
                        {
                            Console.WriteLine(x.ToString());
                            x.Taken?.ToList().ForEach(t =>
                            {
                                Console.WriteLine("Waarvan de taken zijn:");
                                Console.WriteLine("\t taakID: "+t.Taak.Pid+" taakbeschrijving: "+t.Taakbeschrijving);
                            });
                        });
                        break;
                    case 2:
                        _mgr.GetAllTakenWithWerknemers().ForEach(x =>
                        {
                            Console.WriteLine(x.ToString());
                            x.Werknemers.ToList().ForEach(w =>
                            {
                                Console.WriteLine("Waarvan de werknemers zijn: ");
                                Console.WriteLine("\t"+w.Werknemer);
                            });
                        });
                        break; 
                    case 3:
                        _mgr.GetAllWerkgevers().ForEach(x =>
                       {
                           Console.WriteLine(x.ToString());
                       });
                       Console.WriteLine("");
                       break;
                    case 4:
                        Console.WriteLine("Welke functie wilt u zien (1 = I, 2 = H, 3 = B, 4 = F, 5 = Z, 6 = B1, 7 = B2): ");
                        int cijfer = int.Parse(Console.ReadLine());
                        
                        var filteredList = _mgr.GetWerknemersByFunctie(cijfer);
                        foreach (var werknemer in filteredList)
                        {
                            Console.WriteLine(werknemer.ToString());
                        }
                        Console.WriteLine("");
                        break;
                    case 5:
                        Console.WriteLine("Voer Functie in (1 = I, 2 = H, 3 = B, 4 = F, 5 = Z, 6 = B1, 7 = B2) of laat leeg: ");
                        int functiecijfer;
                        
                        bool cijferCheck = int.TryParse(Console.ReadLine(), out functiecijfer);
                        Console.WriteLine("Voer uur in of laat leeg: ");
                        double uur;
                        bool uurCheck = double.TryParse(Console.ReadLine(), out uur);
                       
                        if (cijferCheck && uurCheck)
                        {
                            var taakList = _mgr.GetTakenByFunctieAndUur(functiecijfer, uur);
                            foreach (var t in taakList)
                            {
                                Console.WriteLine(t.ToString());
                            }
                        }
                        else if (cijferCheck)
                        {
                            var cijferlist = _mgr.GetTakenByFunctie(functiecijfer);
                            foreach (var t in cijferlist)
                            {
                                Console.WriteLine(t.ToString());
                            }
                        }
                        else if (uurCheck)
                        {
                            var uurList = _mgr.GetTakenByUur(uur);
                           
                            foreach (var t in uurList)
                            {
                                Console.WriteLine(t.ToString());
                            }
                        }
                        else
                        {
                            foreach (var t in _mgr.GetAllTaken())
                            {
                                Console.WriteLine(t.ToString());
                            }
                        }
                        
                        break;
                    case 6:
                        Console.WriteLine("Pid: ");
                        int pid = int.Parse(Console.ReadLine());
                        Console.WriteLine("werkgeverId: ");
                        int wid = int.Parse(Console.ReadLine());
                        Console.WriteLine("naam: ");
                        string naam = Console.ReadLine();
                        Console.WriteLine("uurloon: ");
                        double uurloon = double.Parse(Console.ReadLine());
                        Console.WriteLine("werkdag (dd/mm/yyyy): ");
                        DateTime werkdag = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("functie (1 = I, 2 = H, 3 = B, 4 = F, 5 = Z, 6 = B1, 7 = B2): ");
                        int functie = int.Parse(Console.ReadLine());
                        var item = (Functie)Enum.GetValues(typeof(Functie)).GetValue(functie-1);
                        _mgr.AddWerknemer(pid, wid, naam, uurloon, werkdag, item);
                            break;
                    case 7:
                        Console.WriteLine("taakId: ");
                        int taakId = int.Parse(Console.ReadLine());
                        Console.WriteLine("pid: ");
                        int tPid = int.Parse(Console.ReadLine());
                        Console.WriteLine("uur: ");
                        double tuur = double.Parse(Console.ReadLine());
                        Console.WriteLine("functie (1 = I, 2 = H, 3 = B, 4 = F, 5 = Z, 6 = B1, 7 = B2): ");
                        int tfunctie = int.Parse(Console.ReadLine());
                        var element = (Functie)Enum.GetValues(typeof(Functie)).GetValue(tfunctie-1);
                        _mgr.AddTaak(taakId, tPid, tuur, element);
                        break;
                    case 8:
                        Console.WriteLine("Kies een werknemer aan wie je een taak wil toewijzen");
                        _mgr.GetAllWerknemers().ToList().ForEach(x => Console.WriteLine("Id: {0} naam: {1}", x.Pid,x.Naam));
                        int chosenId;
                        bool IdTry = int.TryParse(Console.ReadLine(), out chosenId);
                        if (!IdTry)
                        {
                            Console.WriteLine("FOUT: Kies de gewenste ID van de werknemer?");
                        }

                        var w = _mgr.GetWerknemer(chosenId);
                        if (w is null)
                        {
                            Console.WriteLine("FOUT: Deze Werknemer staat niet in de lijst?");
                        }
                        else
                        {
                            Console.WriteLine("Welke taak wil je toevoegen");
                            _mgr.GetAllTaken().ForEach(x => Console.WriteLine("Id: {0} naam: {1}", x.TaakId,x.Uur));
                            int chosenTaakId;
                            bool TaakIdTry = int.TryParse(Console.ReadLine(), out chosenTaakId);
                            if (!TaakIdTry)
                            {
                                Console.WriteLine("FOUT: Kies de gewenste Taak ID?");
                            }

                            var t = _mgr.GetTaak(chosenTaakId);
                            if (t is null)
                            {
                                Console.WriteLine("FOUT: Deze Taak staat niet in de lijst?");
                            }
                            else
                            {
                                Console.WriteLine("Voor welke Afdeling:");
                                Console.WriteLine("Afdeling (1 = Koeken, 2 = Koffie, 3 = NONFOOD, 4 = Frigo, 5 = Conserves, 6 = Wasmiddelen, 7 = Alcohol, 8 = Brood, 9= Energiedranken, 10 = Diepvries, 11 = Kassa): ");
                                int afdeling;
                                bool afdelingTry = int.TryParse(Console.ReadLine(), out afdeling);
                                if (!afdelingTry)
                                {
                                    Console.WriteLine("FOUT: de gekozen afdeling staat niet in de lijst?");
                                }
                                Console.WriteLine("Voer een beschrijving in voor de Taak: ");
                                string beschrijving = Console.ReadLine();


                                _mgr.CreateWerknemerTaak(new WerknemerTaak()
                                {    
                                    Taak = t,
                                    Afdeling = (Afdelingen)Enum.GetValues(typeof(Afdelingen)).GetValue(afdeling-1),
                                    Taakbeschrijving = beschrijving,
                                    Werknemer = w
                                });
                            }
                            
                        }
                        break;
                    case 9:
                        Console.WriteLine("Van Welke werknemer wilt u een taak van verwijderen?");
                        _mgr.GetAllWerknemers().ForEach(x => Console.WriteLine("Id: {0} naam: {1}", x.Pid,x.Naam));
                        int wID;
                        bool wIdTry = int.TryParse(Console.ReadLine(), out wID);
                        if (!wIdTry)
                        {
                            Console.WriteLine(" FOUT: Kies de gewenste ID van de werknemer?");
                        }
                        Console.WriteLine("Welke taak wilt u verwijderen?");
                        var getAll = _mgr.GetAllTakenFromWerknemer(wID);
                        
                        _mgr.GetAllTakenFromWerknemer(wID).ForEach(x => Console.WriteLine("Id: {0} uur: {1}" , x.TaakId,x.Uur) );
                        int removeTaakId;
                        bool removeTaakIdTry = int.TryParse(Console.ReadLine(), out removeTaakId);
                        if (!removeTaakIdTry)
                        {
                            Console.WriteLine("FOUT: Kies de gewenste ID van de werknemer?");
                        }

                        if (wIdTry && removeTaakIdTry)
                        {
                            _mgr.DeleteWerknemerTaak(wID,removeTaakId);
                            Console.WriteLine("Taak verwijdert van werknemer {0}",_mgr.GetWerknemer(wID));
                        }
                        else
                        {
                            Console.WriteLine(" FOUT: Taak niet verwijdert");
                        }
                        break;
                } 
            } while (keuze != 0);
        }
    }
}

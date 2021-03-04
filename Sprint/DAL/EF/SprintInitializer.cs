using System;
using System.Collections.Generic;
using System.Linq;
using GP.BL.Domain;
using Microsoft.EntityFrameworkCore;

namespace GP.DAL.EF
{
    public static class SprintInitializer
    {
     // private static readonly List<Werknemer> _werknemers = new List<Werknemer>();
     // private static readonly List<Taak> _taken = new List<Taak>();
     // private static bool _init = false;

        public static void Initialize(SprintDbContext ctx, bool dropCreateDatabase = false)
        {
            if (dropCreateDatabase)
                ctx.Database.EnsureDeleted();
            if (ctx.Database.EnsureCreated())
                Seed(ctx);
           
        }

        private static void Seed(SprintDbContext ctx)
        {
            ctx.Werknemers.Add(new Werknemer(1,8,"Marwan Akhandaf",11.20,new DateTime(2020,9,26)));
            ctx.Werknemers.Add(new Werknemer(2,8,"Moncef Akhandaf",10.00,new DateTime(2020,9,26),Functie.F));
            ctx.Werknemers.Add(new Werknemer(3,8,"Naila Akhandaf",10.00,new DateTime(2020,9,25),Functie.B));
            ctx.Werknemers.Add(new Werknemer(4,8,"Sofie Vanderbergen",18.50,new DateTime(2020,9,26),Functie.F));
            ctx.Werknemers.Add(new Werknemer(5,8,"Loic meeuws",9.20,new DateTime(2020,9,26)));
            ctx.Werknemers.Add(new Werknemer(6,8,"Nathan Deridder",14.40,new DateTime(2020,9,27),Functie.F));
            ctx.Werknemers.Add(new Werknemer(7,8,"Maxi Kaleta",12.00,new DateTime(2020,12,26),Functie.F));
            ctx.Werknemers.Add(new Werknemer(8,8,"Malika tabit",20.00,new DateTime(2020,12,15),Functie.F));
            ctx.Werknemers.Add(new Werknemer(9,9,"Johan cruijf",20.00,new DateTime(2020,12,15)));
            ctx.Werknemers.Add(new Werknemer(10,10,"Linda Versmissen",20.00,new DateTime(2020,11,15),Functie.B1));
            ctx.Taken.Add(new Taak(1,1, 8.00, Functie.F));
            ctx.Taken.Add(new Taak(2,7, 8.30, Functie.F));
            ctx.Taken.Add(new Taak(3,2, 9.00, Functie.I));
            ctx.Taken.Add(new Taak(4,4, 10.00, Functie.I));
            ctx.Taken.Add(new Taak(5,3, 10.00, Functie.B));
            ctx.Taken.Add(new Taak(6,6, 14.00, Functie.B));
            ctx.Taken.Add(new Taak(7,5, 06.00, Functie.B));
            ctx.Werkgevers.Add(new Werkgever(8, "Malika Tabit"));
            ctx.Werkgevers.Add(new Werkgever(9, "Johan cruijf"));
            ctx.Werkgevers.Add(new Werkgever(10, "Linda Versmissen"));
            var werknemertaak = new List<WerknemerTaak>()
            {
                new WerknemerTaak()
                {
                    Werknemer = new Werknemer(11, 8, "Ilyas Akhandaf", 11.20, new DateTime(2020, 9, 26)),
                    Taak = new Taak(8, 11, 8.00, Functie.F),
                    Afdeling = Afdelingen.FRIGO,
                    Taakbeschrijving = "groenten aanvullen"
                },
                new WerknemerTaak()
                {
                    Werknemer = new Werknemer(12,8,"Sofie Vanderbergen",18.50,new DateTime(2020,9,26),Functie.I),
                    Taak = new Taak(9, 12, 10.00, Functie.I),
                    Afdeling = Afdelingen.KOFFIE,
                    Taakbeschrijving = "koffie aanvullen"
                },
                new WerknemerTaak()
                {
                    Werknemer = new Werknemer(13,8,"Maxi Kaleta",12.00,new DateTime(2020,12,26),Functie.B),
                    Taak = new Taak(10, 13, 18.00, Functie.B),
                    Afdeling = Afdelingen.KASSA,
                    Taakbeschrijving = "Kassa versterking"
                },
                new WerknemerTaak()
                {
                    Werknemer = new Werknemer(14,8,"Benjamin Akhandaf",10.00,new DateTime(2020,9,25),Functie.I),
                    Taak = new Taak(11, 14, 19.00, Functie.I),
                    Afdeling = Afdelingen.ENERGIEDRANKEN,
                    Taakbeschrijving = "Plastic en karton uithalen"
                },
                new WerknemerTaak()
                {
                    Werknemer = new Werknemer(15,10,"Linda Versmissen",20.00,new DateTime(2020,11,15),Functie.B1),
                    Taak = new Taak(12, 15, 11.00, Functie.B1),
                    Afdeling = Afdelingen.KASSA,
                    Taakbeschrijving = "Hoofdkassa"
                }
            };
            werknemertaak.ForEach(x => ctx.WerknemerTaken.Add(x));
            //wegschrijven in databank
            ctx.SaveChanges();
            
            foreach (var entry in ctx.ChangeTracker.Entries().ToList())
            {
                entry.State = EntityState.Detached;
            }
        }
    }
}
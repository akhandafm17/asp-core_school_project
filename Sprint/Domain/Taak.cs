using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GP.BL.Domain
{
     public class Taak
    {
         //Property's
        [Key]    
        public int TaakId { get; set; }
        public int Pid { get;  set; }
        [Required]
        [Range(0,23.5)]
        public double Uur { get;  set; }
        [Required]
        public Functie Functie { get;  set; }
        public List<Taak> Taken { get;  set; }
        public List<WerknemerTaak> Werknemers { get; set; }

        public Taak(int taakId,int pid, double uur, Functie functie)
        {
            Pid = pid;
            Uur = uur;
            Functie = functie;
            Taken = new List<Taak>();
        }

        public Taak()
        {
            Taken = new List<Taak>();
        }
        
        
        public override string ToString()
        {
            return $"taakId: {TaakId.ToString()} pid: {Pid.ToString()} uur: {Uur} functie: {Functie.ToString()}";
        }
    }
}
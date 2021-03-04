using System.ComponentModel.DataAnnotations;

namespace GP.BL.Domain
{
     public class Werkgever
    {
        //property's
        [Key]
        public int Pid { get; private set; }
        [Required]
        [MinLength(5)]
        public string Naam { get;  private set; }

        public Werkgever(int pid, string naam)
        {
            Pid = pid;
            Naam = naam;
        }

        public Werkgever()
        {
            
        }
        
        public override string ToString()
        {
            return $"pid: {Pid.ToString()} naam: {Naam} ";
            
        } 
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace GP.BL.Domain
{
    public class Werknemer : IValidatableObject
    {
     //Property's
        [Key]    
        public int Pid { get; set; }
        [Required]    
        public int WerkgeverPid { get;  set; }
        
        [Required(ErrorMessage = "Naam is verplicht in te vullen!", AllowEmptyStrings = false)]
        [MinLength(5, ErrorMessage = "Naam moet mistens 5 karakters bevatten.")]
        public string Naam { get;  set; }
        [Range(10,30,ErrorMessage = "uurloon kan niet lager zijn dan 10 euro en niet hoger dan 30 euro")]
        public double? Uurloon { get;  set; }
        //[Required(ErrorMessage = "Volgende werkdag datum is verplicht in te vullen !")]    
        public DateTime Werkdag { get;  set; }
            
        public Functie Functie { get;  set; }
        public List<Werknemer> Werknemers { get;  set; }
       
        public Werkgever Werkgever { get; set; }
        
        public ICollection<WerknemerTaak>Taken { get; set; }
       

        public Werknemer(int pid,int werkgeverpid , string naam, double? uurloon, DateTime werkdag, Functie functie = Functie.I)
        {
            Pid = pid;
            WerkgeverPid = werkgeverpid;
            Naam = naam;
            Uurloon = uurloon;
            Werkdag = werkdag;
            Functie = functie; 
            Werknemers = new List<Werknemer>();
        }
        
        public Werknemer(int werkgeverpid , string naam, double? uurloon, DateTime werkdag, Functie functie = Functie.I)
        {
            WerkgeverPid = werkgeverpid;
            Naam = naam;
            Uurloon = uurloon;
            Werkdag = werkdag;
            Functie = functie; 
            Werknemers = new List<Werknemer>();
        }

        public Werknemer()
        {
            Werknemers = new List<Werknemer>();
        }
     
        
        public override string ToString()
        {
            return $"pid: {this.Pid.ToString()} werkgeverPID: {this.WerkgeverPid} naam: {this.Naam} uurloon: {this.Uurloon.ToString()} werkdag: {this.Werkdag.ToString()} functie: {this.Functie.ToString()}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (this.Werkdag <= DateTime.Now)
            {
                string errorMessage = "datum werkdag moet in de toekomst gepland worden.";
                errors.Add(new ValidationResult(errorMessage, new []{"Werkdag"}));
            }
            
         
            if (Naam.Length < 5)
            {
                string errorMessage = "Voer uw voornaam en achternaam in?";
                errors.Add(new ValidationResult(errorMessage, new string[Convert.ToInt32("Naam")]));
            }
            
            
            

            return errors;
        }
    }
}
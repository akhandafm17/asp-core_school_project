using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GP.BL.Domain
{
    public class WerknemerTaak
    {
        
        [Required]
        public Werknemer Werknemer { get; set; }
        [Required]
        public Taak Taak { get; set; }

        public Afdelingen Afdeling { get; set; }
        public string Taakbeschrijving { get; set; }
    }
}
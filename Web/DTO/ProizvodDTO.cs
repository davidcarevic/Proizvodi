using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.DTO
{
    public class ProizvodDTOs
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
        [MinLength(1, ErrorMessage = "You must write a description"), MaxLength(255, ErrorMessage = "The description is too long")]
        public string Opis { get; set; }
        [Required]
        public double Cena { get; set; }
        [Required]
        public int KatId { get; set; }
        [Required]
        public int ProId { get; set; }
        [Required]
        public int DobId { get; set; }
    }
}

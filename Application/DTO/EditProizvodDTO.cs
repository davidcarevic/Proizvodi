using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class EditProizvodDTO
    {
        public int Id { get; set; }

        
        public string Naziv { get; set; }
       
        public string Opis { get; set; }
        
        public double Cena { get; set; }
        
        public int KatId { get; set; }
        
        public int ProId { get; set; }
        
        public int DobId { get; set; }
    }
}

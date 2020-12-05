using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class GetProizvodDTO
    {
        public int Id { get; set; }

        
        public string Naziv { get; set; }
       
        public string Opis { get; set; }
     
        public double Cena { get; set; }
      
        public int KatId { get; set; }
      
        public int ProId { get; set; }
        
        public int DobId { get; set; }
/*
        public string Kategorija { get; set; }
        public string Proizvodjac { get; set; }
        public string Dobavljac { get; set; }*/

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}

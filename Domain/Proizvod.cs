using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Proizvod:BaseEntity
    {
        public string Opis { get; set; }
        public double Cena { get; set; } // mozda decimal ili tako nesto za neke druge cifre
        public int KatId { get; set; }
        public int ProId { get; set; }
        public int DobId { get; set; }

        public Kategorija Kategorija { get; set; }
        public Dobavljac Dobavljac { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
    }
}

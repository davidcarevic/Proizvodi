using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Proizvodjac:BaseEntity
    {
        public ICollection<Proizvod> Proizvods { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Dobavljac:BaseEntity
    {
        public ICollection<Proizvod> Proizvods { get; set; }
    }
}

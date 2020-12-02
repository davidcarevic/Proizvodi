using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class Kategorija:BaseEntity
    {
        public ICollection<Proizvod> Proizvods { get; set; }
    }
}

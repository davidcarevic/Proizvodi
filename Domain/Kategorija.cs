using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Kategorija:BaseEntity
    {
        public ICollection<Proizvod> Proizvods { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class EditProizvodjacDTO
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}

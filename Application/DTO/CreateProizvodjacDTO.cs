﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateProizvodjacDTO
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }
    }
}

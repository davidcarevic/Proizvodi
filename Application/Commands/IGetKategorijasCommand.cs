﻿using Application.DTO;
using Application.Interfaces;
using Application.Searchs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands
{
    public interface IGetKategorijasCommand:ICommand< Search,IEnumerable<GetKategorijaDTO>>
    {
    }
}

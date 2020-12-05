using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public abstract class BaseEFCommand
    {
        protected ProizvodiContext _context;

        protected BaseEFCommand(ProizvodiContext context)
        {
            _context = context;
        }
    }
}

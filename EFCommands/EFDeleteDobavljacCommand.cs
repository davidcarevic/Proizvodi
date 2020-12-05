using Application.Commands;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFDeleteDobavljacCommand : BaseEFCommand, IDeleteDobavljacCommand
    {
        public  EFDeleteDobavljacCommand(ProizvodiContext context):base(context){}

        public void Execute(int request)
        {
            var item = _context.Dobavljacs.Find(request);
            if (item == null)
                throw new EntityNotFoundException("Supplier");

            _context.Remove(item);  
            _context.SaveChanges();
        }
    }
}

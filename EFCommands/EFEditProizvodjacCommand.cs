using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public class EFEditProizvodjacCommand : BaseEFCommand, IEditProizvodjacCommand
    {
        public  EFEditProizvodjacCommand(ProizvodiContext context):base(context){}

    public void Execute(EditProizvodjacDTO request) {
            var pro = _context.Proizvodjacs.Find(request.Id);

            if (pro == null)
                throw new EntityNotFoundException("Maker");


            pro.Naziv = request.Naziv;
            pro.ModifiedOn = DateTime.Now;

            _context.SaveChanges();
        }

    }
}

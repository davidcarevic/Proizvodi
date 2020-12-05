using Application.Commands;
using Application.DTO;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Exceptions;

namespace EFCommands
{
    public class EFGetProizvodCommand:BaseEFCommand,IGetProizvodCommand
    {
        public EFGetProizvodCommand(ProizvodiContext context) : base(context) { }

        public GetProizvodDTO Execute(int request)
        {

            var r = _context.Proizvods.Where(u => u.Id == request).First();

            if (r == null) { throw new EntityNotFoundException("Article"); }

            return new GetProizvodDTO
            {
                Id = r.Id,
                Naziv = r.Naziv,
                Opis = r.Opis,
                Cena = r.Cena,
                KatId = r.KatId,
                DobId = r.DobId,
                ProId = r.ProId,
                CreatedOn = r.CreatedOn,
                ModifiedOn = r.ModifiedOn



            };
        }
    }
}

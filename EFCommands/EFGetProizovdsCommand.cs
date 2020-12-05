using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searchs;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EFCommands
{
    public class EFGetProizovdsCommand:BaseEFCommand, IGetProizvodsCommand
    {
        public EFGetProizovdsCommand(ProizvodiContext context) : base(context) { }

        public IEnumerable<GetProizvodDTO> Execute(Search request) {

            var query = _context.Proizvods.AsQueryable();

            if (request.Keyword != null)
            {
                if (!query.Any(r => r.Naziv.ToLower().Contains(request.Keyword.ToLower())))
                {
                    throw new EntityNotFoundException("Article");
                }

                query = query.Where(r => r.Naziv.ToLower().Contains(request.Keyword.ToLower()));

            }

            return query.Select(r => new GetProizvodDTO
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


            }

          );
        }
    }
}

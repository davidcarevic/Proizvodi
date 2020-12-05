using Application.Commands;
using Application.DTO;
using Application.Exceptions;
using Application.Searchs;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EFCommands
{
    public class EFGetProizvodjacsCommand:BaseEFCommand, IGetProizvodjacsCommand
    {
        public EFGetProizvodjacsCommand(ProizvodiContext context) : base(context) { }

        public IEnumerable<GetProizvodjacDTO> Execute(Search request)
        {

            var query = _context.Proizvodjacs.AsQueryable();

            if (request.Keyword != null)
            {
                if (!query.Any(r => r.Naziv.ToLower().Contains(request.Keyword.ToLower())))
                {
                    throw new EntityNotFoundException("Maker");
                }

                query = query.Where(r => r.Naziv.ToLower().Contains(request.Keyword.ToLower()));

            }

            return query.Select(r => new GetProizvodjacDTO
            {
                Id = r.Id,
                Naziv = r.Naziv,
                CreatedOn = r.CreatedOn,
                ModifiedOn = r.ModifiedOn


            }

          );
        }
    }
}

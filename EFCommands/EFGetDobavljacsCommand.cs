using Application.Commands;
using Application.DTO;
using Application.Searchs;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Application.Exceptions;

namespace EFCommands
{
    public class EFGetDobavljacsCommand:BaseEFCommand, IGetDobavljacsCommand
    {
        public EFGetDobavljacsCommand(ProizvodiContext context) : base(context) { }

        public IEnumerable<GetDobavljacDTO> Execute(Search request)
        {

            var query = _context.Dobavljacs.AsQueryable();

            if (request.Keyword != null)
            {
                if (!query.Any(r => r.Naziv.ToLower().Contains(request.Keyword.ToLower())))
                {
                    throw new EntityNotFoundException("Supplier");
                }

                query = query.Where(r => r.Naziv.ToLower().Contains(request.Keyword.ToLower()));

            }

            return query.Select(r => new GetDobavljacDTO
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

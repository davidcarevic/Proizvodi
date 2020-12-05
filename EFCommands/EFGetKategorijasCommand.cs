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
    public class EFGetKategorijasCommand: BaseEFCommand, IGetKategorijasCommand
    {
        public EFGetKategorijasCommand(ProizvodiContext context) : base(context) { }

        public IEnumerable<GetKategorijaDTO> Execute(Search request)
        {

            var query = _context.Kategorijas.AsQueryable();

            if (request.Keyword != null)
            {
                if (!query.Any(r => r.Naziv.ToLower().Contains(request.Keyword.ToLower())))
                {
                    throw new EntityNotFoundException("Category");
                }

                query = query.Where(r => r.Naziv.ToLower().Contains(request.Keyword.ToLower()));

            }

            return query.Select(r => new GetKategorijaDTO
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

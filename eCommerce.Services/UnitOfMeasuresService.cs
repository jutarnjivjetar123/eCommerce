using eCommerce.Model;
using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class UnitOfMeasuresService(
            eCommerceContext dbContext,
            IMapper mapper
        ) :
        BaseCRUDService<eCommerce.Model.UnitOfMeasures, UnitOfMeasureSearchObject, Database.UnitOfMeasures, UnitOfMeasuresInsertRequest, UnitOfMeasuresUpdateRequest>(dbContext, mapper), IUnitOfMeasureService
    {
        public override IQueryable<Database.UnitOfMeasures> AddFilter(UnitOfMeasureSearchObject search, IQueryable<Database.UnitOfMeasures> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrEmpty(search.NameGTE)) {
                filteredQuery = filteredQuery.Where(x => x.Name.StartsWith(search.NameGTE));
            }

            return filteredQuery;
        }

        public override void BeforeInsert(UnitOfMeasuresInsertRequest request, Database.UnitOfMeasures entity)
        {

            if (dbContext.UnitOfMeasures.Any(
                    x => x.Name.ToLower() == request.Name.ToLower() && x.UnitOfMeasureId != entity.UnitOfMeasureId
                )) {
                throw new Exception("Ovaj naziv već postoji!");
            }
            base.BeforeInsert(request, entity);
        }

        public override void BeforeUpdate(UnitOfMeasuresUpdateRequest request, Database.UnitOfMeasures entity)
        {

            if (dbContext.UnitOfMeasures.Any(
                   x => x.Name.ToLower() == request.Name.ToLower() && x.UnitOfMeasureId != entity.UnitOfMeasureId
               ))
            {
                throw new Exception("Ovaj naziv već postoji!");
            }
            base.BeforeUpdate(request, entity);
        }
    }
}

using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eCommerce.Model;
using eCommerce.Services.Model.Requests;
namespace eCommerce.Services
{
    public class ProductsService : BaseCRUDService<eCommerce.Model.Products, ProductsSearchObject, Database.Products, ProductsInsertRequest, ProductsUpdateRequest>, IProductsService
    {

        public ProductsService(
                eCommerceContext context,
                IMapper mapper
            ) : base(context, mapper)
        {
            
        }


        public override IQueryable<Database.Products> AddFilter(ProductsSearchObject search, IQueryable<Database.Products> query)
        {

            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search.FTS)) {
                filteredQuery = filteredQuery.Where(x => x.Name.Contains(search.FTS));
            }

            return filteredQuery;
        }

        public override void BeforeInsert(ProductsInsertRequest request, Database.Products entity)
        {
            //TODO: throw exception if product code is existing
            base.BeforeInsert(request, entity);
        }
    }
}

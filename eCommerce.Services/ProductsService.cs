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

namespace eCommerce.Services
{
    public class ProductsService : BaseService<Model.Products, ProductsSearchObject, Database.Products>, IProductsService
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
    }
}

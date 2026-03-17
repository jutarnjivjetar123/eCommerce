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
    public class ProductsService(
            eCommerceContext dbContext,
            IMapper mapper
        ) : IProductsService
    {

        private readonly eCommerceContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;


        public List<Model.Products> GetList(ProductsSearchObject searchObject)
        {
            List<Model.Products> result = new();

            var query = _dbContext.Products.AsQueryable();


            if (!string.IsNullOrWhiteSpace(searchObject.FTS)) {

                query = query.Where(
                        x => x.Name.Contains(searchObject.FTS) ||
                        x.Code.Contains(searchObject.FTS)
                    );
            }

            var list = query.ToList();

            result = _mapper.Map(list, result);

            return result;
        }
    }
}

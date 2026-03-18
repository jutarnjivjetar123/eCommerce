using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class ProductCategoriesService(
            eCommerceContext dbContext,
            IMapper mapper
        ) : IProductCategoriesService
    {

        private readonly eCommerceContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;


        public List<Model.ProductCategories> GetList(ProductCategoriesSearchObject searchObject)
        {
            List<Model.ProductCategories> result = new();

            var query = _dbContext.ProductCategories.AsQueryable();


            if (!string.IsNullOrWhiteSpace(searchObject.NameGTE)) {

                query = query.Where(x => x.Name.StartsWith(searchObject.NameGTE));
                
            }

            if (searchObject.Page.HasValue && searchObject.PageSize.HasValue) {

                query = query.Skip(searchObject.Page.Value * searchObject.PageSize.Value).Take(searchObject.PageSize.Value);

            }

            var list = query.ToList();

            result = _mapper.Map(list, result);

            return result;
        }
    }
}

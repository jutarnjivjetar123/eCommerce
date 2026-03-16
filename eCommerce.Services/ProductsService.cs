using eCommerce.Model;
using eCommerce.Services.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class ProductsService(
            eCommerceContext dbContext
        ) : IProductsService
    {

        private readonly eCommerceContext _dbContext = dbContext;
        
        public List<Model.Products> GetList()
        {
            var list = _dbContext.Products.ToList();

            var result = new List<Model.Products>();
            foreach (var item in list)
            {
                result.Add(
                        new Model.Products
                        {
                            ProductId = item.ProductId,
                            Name = item.Name,
                            Price = item.Price

                        }
                    );
            }

            

            return result;
        }
    }
}

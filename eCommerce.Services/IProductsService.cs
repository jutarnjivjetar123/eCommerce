using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public interface IProductsService : ICRUDService<Products, ProductsSearchObject, ProductsInsertRequest, ProductsUpdateRequest>
    {
        public Products Activate(int id);
        public Products Hide(int id);
        public Products Edit(int id);
        public List<string> AllowedActions(int id);
    }
}

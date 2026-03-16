using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public interface IProductsService
    {
        List<Model.Products> GetList();
    }
}

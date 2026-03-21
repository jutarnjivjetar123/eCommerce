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
    public class ProductCategoriesService(eCommerceContext context, IMapper mapper) : BaseService<Model.ProductCategories, ProductCategoriesSearchObject, Database.ProductCategories>(context, mapper), IProductCategoriesService
    {
    }
}

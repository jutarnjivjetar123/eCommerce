using eCommerce.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.ProductsStateMachine
{
    public class ActiveProductState : BaseProductsState
    {
        public ActiveProductState(eCommerceContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
        }
    }
}

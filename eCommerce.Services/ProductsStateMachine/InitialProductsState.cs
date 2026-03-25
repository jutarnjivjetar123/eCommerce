using eCommerce.Model;
using eCommerce.Services.Database;
using eCommerce.Services.Model.Requests;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.ProductsStateMachine
{
    public class InitialProductsState : BaseProductsState
    {
        private readonly eCommerceContext _dbContext;
        private readonly IMapper _mapper;
        public InitialProductsState(eCommerceContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override eCommerce.Model.Products Insert(ProductsInsertRequest request)
        {
            
            var set = _dbContext.Set<Database.Products>();

            var entity = _mapper.Map<Database.Products>(request);

            entity.StateMachine = "draft";
            set.Add(entity);
            _dbContext.SaveChanges();
            return _mapper.Map<eCommerce.Model.Products>(entity);


        }

        public override List<string> AllowedActions(Database.Products entity)
        {
            return new() { 
               nameof(Insert),

            };
        }

        
    }
}

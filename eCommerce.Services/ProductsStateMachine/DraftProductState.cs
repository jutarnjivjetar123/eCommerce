using Azure.Core;
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
    public class DraftProductState : BaseProductsState
    {
        private eCommerceContext _dbContext;
        private IMapper _mapper;
        public DraftProductState(eCommerceContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override eCommerce.Model.Products Update(int id, ProductsUpdateRequest request)
        {

            var set = _dbContext.Set<Database.Products>();

            var entity = set.Find(id);

            _mapper.Map(request, entity);

            return _mapper.Map<eCommerce.Model.Products>(entity);
        }

        public override eCommerce.Model.Products Activate(int id)
        {

            var set = _dbContext.Set<Database.Products>();

            var entity = set.Find(id);

            entity.StateMachine = "active";

            _dbContext.SaveChanges();

            return _mapper.Map<eCommerce.Model.Products>(entity);

        }

        public override eCommerce.Model.Products Hide(int id)
        {
            var set = _dbContext.Set<Database.Products>();

            var entity = set.Find(id);

            entity.StateMachine = "hidden";

            _dbContext.SaveChanges();


            return _mapper.Map<eCommerce.Model.Products>(entity);
        }

        public override List<string> AllowedActions(Database.Products entity)
        {
            return new() { 
                nameof(Activate),
                nameof(Update),
                nameof(Hide)
            };
        }
    }
}

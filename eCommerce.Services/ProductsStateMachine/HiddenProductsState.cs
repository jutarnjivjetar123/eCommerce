using eCommerce.Services.Database;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.ProductsStateMachine
{
    public class HiddenProductsState : BaseProductsState
    {
        private eCommerceContext _dbContext;
        private IMapper _mapper;

        public HiddenProductsState(eCommerceContext dbContext, IMapper mapper, IServiceProvider serviceProvider) : base(dbContext, mapper, serviceProvider)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public override eCommerce.Model.Products Edit(int id)
        {
            var set = _dbContext.Set<Database.Products>();

            var entity = set.Find(id);

            entity.StateMachine = "draft";

            _dbContext.SaveChanges();


            return _mapper.Map<eCommerce.Model.Products>(entity);
        }


        public override List<string> AllowedActions(Products entity)
        {
            return new() { nameof(Edit) };
        }
    }
}

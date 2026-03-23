using Azure.Core;
using eCommerce.Model;
using eCommerce.Model;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using eCommerce.Services.Model.Requests;
using eCommerce.Services.ProductsStateMachine;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace eCommerce.Services
{
    public class ProductsService : BaseCRUDService<eCommerce.Model.Products, ProductsSearchObject, Database.Products, ProductsInsertRequest, ProductsUpdateRequest>, IProductsService
    {

        private BaseProductsState _baseProductsState { get; set; }

        public ProductsService(
                eCommerceContext context,
                IMapper mapper,
                BaseProductsState baseProductsState
            ) : base(context, mapper)
        {
            _baseProductsState = baseProductsState;
        }


        public override IQueryable<Database.Products> AddFilter(ProductsSearchObject search, IQueryable<Database.Products> query)
        {

            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search.FTS)) {
                filteredQuery = filteredQuery.Where(x => x.Name.Contains(search.FTS));
            }

            return filteredQuery;
        }

        public override eCommerce.Model.Products Insert(ProductsInsertRequest request)
        {

            var state = _baseProductsState.CreateState("initial");
            return state.Insert(request);
        }

        public override eCommerce.Model.Products Update(int id, ProductsUpdateRequest request)
        {
            var entity = GetById(id);
            var state = _baseProductsState.CreateState(entity.StateMachine);

            return state.Update(id, request);
        }

        public eCommerce.Model.Products Activate(int id)
        {
            var entity = GetById(id);
            var state = _baseProductsState.CreateState(entity.StateMachine);

            return state.Activate(id);
        }
    }
}

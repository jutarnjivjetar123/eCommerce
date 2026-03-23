using eCommerce.Services.Database;
using eCommerce.Services.Model.Requests;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;


namespace eCommerce.Services.ProductsStateMachine
{
    public class BaseProductsState
    {
        private readonly eCommerceContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        public BaseProductsState(
                eCommerceContext dbContext,
                IMapper mapper,
                IServiceProvider serviceProvider
            )
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }

        public virtual eCommerce.Model.Products Insert(ProductsInsertRequest request) {
            throw new Exception("Method now allowed");
        }

        public virtual eCommerce.Model.Products Update(int id, ProductsUpdateRequest request) {
            throw new Exception("Method now allowed");
        }

        public virtual eCommerce.Model.Products Activate(int id) {
            throw new Exception("Method now allowed");
        }

        public virtual eCommerce.Model.Products Hide(int id) {
            throw new Exception("Method not allowed");
        }

        public BaseProductsState CreateState(string stateName) {

            switch (stateName)
            {
                case "initial":
                    return _serviceProvider.GetService<InitialProductsState>();
                case "draft":
                    return _serviceProvider.GetService<DraftProductState>();
                case "active":
                    return _serviceProvider.GetService<ActiveProductState>();
                default:
                    throw new Exception("State not recognized!");
            }

        }
    }
}


//Initial -> Draft -> Active -> Hidden -> Active
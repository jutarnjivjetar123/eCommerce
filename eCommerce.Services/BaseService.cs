using eCommerce.Model;
using eCommerce.Services.Database;
using MapsterMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class BaseService<TModel, TSearch, TDbEntity> : IService<TModel, TSearch> where TSearch : BaseSearchObject where TDbEntity : class where TModel : class
    {

        private readonly eCommerceContext _context;
        private readonly IMapper _mapper;
        public BaseService(
                eCommerceContext context,
                IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }

        public TModel GetById(int id)
        {
            var entity = _context.Set<TDbEntity>().Find(id);


            if (entity == null) {
                return null;
            }
            return _mapper.Map<TModel>(entity);
        }

        public PagedResult<TModel> GetPaged(TSearch search)
        {
            var query = _context.Set<TDbEntity>().AsQueryable();

            query = AddFilter(search, query);

            int count = query.Count();
            
            if (search.Page.HasValue && search.PageSize.HasValue) {

                query = query.Skip(search.Page.Value * search.PageSize.Value).Take(search.PageSize.Value);
            }

            var list = query.ToList();

            var result = _mapper.Map<List<TModel>>(list);

            PagedResult<TModel> pagedResult = new();
            pagedResult.ResultList = result;
            pagedResult.Count = count;

            return pagedResult;
        }


        public virtual IQueryable<TDbEntity> AddFilter(TSearch search, IQueryable<TDbEntity> query) {
            return query;
        }
    }
}

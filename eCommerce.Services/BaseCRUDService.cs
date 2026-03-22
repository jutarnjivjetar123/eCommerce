using eCommerce.Model;
using eCommerce.Model.Requests;
using eCommerce.Services.Database;
using eCommerce.Services.Helpers;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public abstract class BaseCRUDService<TModel, TSearch, TDbEntity, TInsert, TUpdate>(eCommerceContext context, IMapper mapper) : BaseService<TModel, TSearch, TDbEntity>(context, mapper)
        where TModel : class
        where TSearch : BaseSearchObject
        where TDbEntity : class
        
    {
        public TModel Insert(TInsert request)
        {

            TDbEntity entity = mapper.Map<TDbEntity>(request);

            BeforeInsert(request, entity);
            context.Add(entity);
            context.SaveChanges();



            return mapper.Map<TModel>(entity);

        }

        public virtual void BeforeInsert(TInsert request, TDbEntity entity) { 
            
        }

        public TModel Update(int id, TUpdate request) {

            var set = context.Set<TDbEntity>();

            var entity = set.Find(id);

            mapper.Map(request, entity);

            BeforeUpdate(request, entity);

            context.SaveChanges();

            return mapper.Map<TModel>(entity);
        }

        public virtual void BeforeUpdate(TUpdate request, TDbEntity entity) { }
    }
}

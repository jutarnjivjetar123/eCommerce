using eCommerce.Model;
using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public interface IUnitOfMeasureService : ICRUDService<UnitOfMeasures, UnitOfMeasureSearchObject, UnitOfMeasuresInsertRequest, UnitOfMeasuresUpdateRequest>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class UnitOfMeasures
    {
        public int UnitOfMeasureId { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Products> Products { get; } = new List<Products>();
    }
}

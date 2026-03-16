using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class Warehouses
    {
        public int WarehouseId { get; set; }

        public string Name { get; set; } = null!;

        public string? Address { get; set; }

        public string? Description { get; set; }

        public virtual ICollection<Sales> Sales { get; } = new List<Sales>();

        public virtual ICollection<PurchaseEntries> PurchaseEntries { get; } = new List<PurchaseEntries>();
    }
}

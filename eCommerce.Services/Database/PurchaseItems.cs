using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class PurchaseItems
    {
        public int PurchaseItemId { get; set; }

        public int PurchaseEntryId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public virtual Products Product { get; set; } = null!;

        public virtual PurchaseEntries PurchaseEntry { get; set; } = null!;
    }
}

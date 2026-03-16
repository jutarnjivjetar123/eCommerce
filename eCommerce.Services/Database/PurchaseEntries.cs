using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class PurchaseEntries
    {
        public int PurchaseEntryId { get; set; }

        public string InvoiceNumber { get; set; } = null!;

        public DateTime Date { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal VAT { get; set; }

        public string? Note { get; set; }

        public int WarehouseId { get; set; }

        public int UserId { get; set; }

        public int SupplierId { get; set; }

        public virtual Suppliers Supplier { get; set; } = null!;

        public virtual Users User { get; set; } = null!;

        public virtual Warehouses Warehouse { get; set; } = null!;

        public virtual ICollection<PurchaseItems> PurchaseItems { get; } = new List<PurchaseItems>();
    }
}

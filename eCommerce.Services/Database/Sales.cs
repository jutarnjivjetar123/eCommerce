using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class Sales
    {
        public int SaleId { get; set; }

        public string InvoiceNumber { get; set; } = null!;

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public bool IsLocked { get; set; }

        public decimal AmountWithoutVAT { get; set; }

        public decimal AmountWithVAT { get; set; }

        public int? OrderId { get; set; }

        public int WarehouseId { get; set; }

        public virtual ICollection<SalesItems> SalesItems { get; } = new List<SalesItems>();

        public virtual Users User { get; set; } = null!;

        public virtual Orders? Order { get; set; }

        public virtual Warehouses Warehouse { get; set; } = null!;
    }
}

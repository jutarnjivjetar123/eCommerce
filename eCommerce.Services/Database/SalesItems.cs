using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{

    public partial class SalesItems
    {
        public int SalesItemId { get; set; }

        public int SaleId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal? Discount { get; set; }

        public virtual Sales Sale { get; set; } = null!;

        public virtual Products Product { get; set; } = null!;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class Products
    {
        public int ProductId { get; set; }

        public string Name { get; set; } = null!;

        public string Code { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int UnitOfMeasureId { get; set; }

        public byte[]? Image { get; set; }

        public byte[]? Thumbnail { get; set; }

        public bool? Status { get; set; }

        public string? StateMachine { get; set; }

        public virtual ICollection<SalesItems> SalesItems { get; } = new List<SalesItems>();

        public virtual UnitOfMeasures UnitOfMeasure { get; set; } = null!;

        public virtual ICollection<OrderItems> OrderItems { get; } = new List<OrderItems>();

        public virtual ICollection<Reviews> Reviews { get; } = new List<Reviews>();

        public virtual ICollection<PurchaseItems> PurchaseItems { get; } = new List<PurchaseItems>();

        public virtual ProductCategories Category { get; set; } = null!;
    }
}

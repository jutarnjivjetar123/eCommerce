using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class Orders
    {
        public int OrderId { get; set; }

        public string OrderNumber { get; set; } = null!;

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public bool IsCompleted { get; set; }

        public bool? IsCancelled { get; set; }

        public virtual ICollection<Sales> Sales { get; } = new List<Sales>();

        public virtual Customers Customer { get; set; } = null!;

        public virtual ICollection<OrderItems> OrderItems { get; } = new List<OrderItems>();
    }
}

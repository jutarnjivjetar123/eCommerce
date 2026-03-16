using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class Reviews
    {
        public int ReviewId { get; set; }

        public int ProductId { get; set; }

        public int CustomerId { get; set; }

        public DateTime Date { get; set; }

        public int Rating { get; set; }

        public virtual Customers Customer { get; set; } = null!;

        public virtual Products Product { get; set; } = null!;
    }
}

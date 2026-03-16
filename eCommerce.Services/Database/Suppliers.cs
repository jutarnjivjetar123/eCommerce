using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Database
{
    public partial class Suppliers
    {
        public int SupplierId { get; set; }

        public string Name { get; set; } = null!;

        public string? ContactPerson { get; set; }

        public string Address { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public string? Fax { get; set; }

        public string? Website { get; set; }

        public string Email { get; set; } = null!;

        public string? BankAccounts { get; set; }

        public string? Note { get; set; }

        public bool IsActive { get; set; }

        public virtual ICollection<PurchaseEntries> PurchaseEntries { get; } = new List<PurchaseEntries>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services.Model.Requests
{
    public partial class ProductsInsertRequest
    {


        public string? Name { get; set; } = null!;

        public string? Code { get; set; } = null!;

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public int UnitOfMeasureId { get; set; }

        //public byte[]? Image { get; set; }

        //public byte[]? Thumbnail { get; set; }

        //public bool? Status { get; set; }

        //public string? StateMachine { get; set; }

    }
}

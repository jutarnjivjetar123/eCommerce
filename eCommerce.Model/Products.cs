using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model
{
    public class Products
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string? StateMachine { get; set; }
    }
}

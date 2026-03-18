using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model.SearchObjects
{
    public class ProductCategoriesSearchObject
    {
        public string? NameGTE { get; set; }

        public int? Page { get; set; }

        public int? PageSize { get; set; }
    }
}

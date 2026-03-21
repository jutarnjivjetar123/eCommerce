using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerce.Model.SearchObjects
{
    // Ensure UsersSearchObject inherits from BaseSearchObject to satisfy the generic constraint in IService<TModel, TSearch>
    public class UsersSearchObject : BaseSearchObject
    {
        public string? FirstNameGTE { get; set; }

        public string? LastNameGTE { get; set; }

        public string? Email { get; set; }

        public string? Username { get; set; }

        public bool? IsUserRolesIncluded { get; set; }

        public string? OrderBy { get; set; }
    }
}

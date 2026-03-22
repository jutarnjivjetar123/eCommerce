using eCommerce.Model;
using eCommerce.Model.Requests;
using eCommerce.Model.SearchObjects;
using eCommerce.Services.Database;
using eCommerce.Services.Helpers;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace eCommerce.Services
{
    public class UsersService(
            eCommerceContext dbContext,
            IMapper mapper

        ) : 
        BaseCRUDService<eCommerce.Model.Users, UsersSearchObject, Database.Users, UsersInsertRequest, UsersUpdateRequest>(dbContext, mapper), IUsersService
    {

        private readonly eCommerceContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;

        public override IQueryable<Database.Users> AddFilter(UsersSearchObject search, IQueryable<Database.Users> query)
        {
            var filteredQuery = base.AddFilter(search, query);

            if (!string.IsNullOrWhiteSpace(search.FirstNameGTE))
            {

                filteredQuery = query.Where(x => x.FirstName.StartsWith(search.FirstNameGTE));
            }
            

            if (!string.IsNullOrWhiteSpace(search.LastNameGTE))
            {
                filteredQuery = query.Where(x => x.LastName.StartsWith(search.LastNameGTE));
            }

            if (!string.IsNullOrEmpty(search.Email))
            {
                filteredQuery = query.Where(x => x.Email == search.Email);
            }

            if (!string.IsNullOrWhiteSpace(search.Username))
            {
                filteredQuery = query.Where(x => x.Username == search.Username);
            }

            if (search.IsUserRolesIncluded.HasValue && search.IsUserRolesIncluded.Value) {
                filteredQuery = query.Include(x => x.UserRoles).ThenInclude(x => x.Role);
            }

            if (!string.IsNullOrEmpty(search.OrderBy)) {
                filteredQuery = filteredQuery.OrderBy(search.OrderBy);
            }

            return filteredQuery;
        }

        public override void BeforeInsert(UsersInsertRequest request, Database.Users entity)
        {
            if (request.Password != request.PasswordConfirm)
            {
                throw new Exception("Lozinka i potvrda lozinke moraju biti isti!");
            }

            entity.PasswordSalt = PasswordHelper.GenerateSalt();
            entity.PasswordHash = PasswordHelper.GenerateHash(entity.PasswordSalt, request.Password);

            base.BeforeInsert(request, entity);
        }

        public override void BeforeUpdate(UsersUpdateRequest request, Database.Users entity)
        {
            base.BeforeUpdate(request, entity);
        }


        //public Model.Users Update(int id, UsersUpdateRequest request)
        //{
        //    var entity = _dbContext.Users.Find(id);

        //    _mapper.Map(request, entity);



        //    if (request.Password != null) { 
            

        //        if (request.Password != request.PasswordConfirm) {
        //            throw new Exception("Lozinka i potvrda lozinke moraju biti isti!");
        //        }


        //        entity.PasswordSalt = PasswordHelper.GenerateSalt();
        //        entity.PasswordHash = PasswordHelper.GenerateHash(entity.PasswordSalt, request.Password);

        //    }

        //    _dbContext.Users.Update(entity);
        //    _dbContext.SaveChanges();

        //    return _mapper.Map<Model.Users>(entity);
        //}

        
    }
}

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
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Services
{
    public class UsersService(
            eCommerceContext dbContext,
            IMapper mapper

        ) : IUsersService
    {

        private readonly eCommerceContext _dbContext = dbContext;
        private readonly IMapper _mapper = mapper;
        
        public virtual List<Model.Users> GetList(UsersSearchObject searchObject)
        {

            List<Model.Users> result = new List<Model.Users>();

            var query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchObject.FirstNameGTE)) {

                query = query.Where(x => x.FirstName.StartsWith(searchObject.FirstNameGTE));
            }

            if (!string.IsNullOrWhiteSpace(searchObject.LastNameGTE)) {
                query = query.Where(x => x.LastName.StartsWith(searchObject.LastNameGTE));
            }

            if (!string.IsNullOrEmpty(searchObject.Email)) {
                query = query.Where(x => x.Email == searchObject.Email);
            }

            if (!string.IsNullOrWhiteSpace(searchObject.Username)) { 
                query = query.Where(x => x.Username == searchObject.Username);
            }
            


            var list = query.ToList();
            
            
            result = _mapper.Map(list, result);
            return result;
        }

        public Model.Users Insert(UsersInsertRequest request)
        {
            if (request.Password != request.PasswordConfirm) {
                throw new Exception("Lozinka i potvrda lozinke moraju biti isti!");
            }

            var entity = new Database.Users();

            _mapper.Map(request, entity);

            entity.PasswordSalt = PasswordHelper.GenerateSalt();
            entity.PasswordHash = PasswordHelper.GenerateHash(entity.PasswordSalt, request.Password);

            _dbContext.Users.Add(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<Model.Users>(entity);

        }

        public Model.Users Update(int id, UsersUpdateRequest request)
        {
            var entity = _dbContext.Users.Find(id);

            _mapper.Map(request, entity);



            if (request.Password != null) { 
            

                if (request.Password != request.PasswordConfirm) {
                    throw new Exception("Lozinka i potvrda lozinke moraju biti isti!");
                }


                entity.PasswordSalt = PasswordHelper.GenerateSalt();
                entity.PasswordHash = PasswordHelper.GenerateHash(entity.PasswordSalt, request.Password);

            }

            _dbContext.Users.Update(entity);
            _dbContext.SaveChanges();

            return _mapper.Map<Model.Users>(entity);
        }
    }
}

using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly DatabaseContext context;

        public UserRepository(DatabaseContext context)
        {
            this.context = context;
        }

        public void Add(UserModel user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void Delete(UserModel user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> GetAll() => context.Users.ToList();

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel GetByUsernameAndPassword(string username, string password)
        {
            return context.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        public void Update(UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}

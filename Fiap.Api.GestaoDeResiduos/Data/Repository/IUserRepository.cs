using Fiap.Api.GestaoDeResiduos.Models;

namespace Fiap.Api.GestaoDeResiduos.Data.Repository
{
    public interface IUserRepository
    {
        IEnumerable<UserModel> GetAll();
        UserModel GetById(int id);
        void Add(UserModel user);
        void Update(UserModel user);
        void Delete(UserModel user);
        UserModel GetByUsernameAndPassword(string username, string password);
    }
}

using Fiap.Api.GestaoDeResiduos.Data.Repository;
using Fiap.Api.GestaoDeResiduos.Models;

namespace Fiap.Api.GestaoDeResiduos.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void AtualizarUsuario(UserModel user)
        {
            throw new NotImplementedException();
        }

        public UserModel BuscarPorUsernameAndPassword(string username, string password)
        {
            return userRepository.GetByUsernameAndPassword(username, password);
        }

        public UserModel BuscarUsuarioPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void CadastrarUsuario(UserModel user) => userRepository.Add(user);

        public void DeletarUsuario(UserModel user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserModel> ListarUsuarios() => userRepository.GetAll();

    }
}

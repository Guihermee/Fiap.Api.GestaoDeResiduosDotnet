using Fiap.Api.GestaoDeResiduos.Models;

namespace Fiap.Api.GestaoDeResiduos.Services
{
    public interface IUserService
    {
        IEnumerable<UserModel> ListarUsuarios();
        UserModel BuscarUsuarioPorId(int id);
        void CadastrarUsuario(UserModel user);
        void AtualizarUsuario(UserModel user);
        void DeletarUsuario(UserModel user);
        UserModel BuscarPorUsernameAndPassword(string username, string password);
    }
}

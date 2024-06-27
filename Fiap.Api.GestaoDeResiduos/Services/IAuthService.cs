using Fiap.Api.GestaoDeResiduos.Models;

namespace Fiap.Api.GestaoDeResiduos.Services
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);
    }
}

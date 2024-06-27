using Fiap.Api.GestaoDeResiduos.Data.Context;
using Fiap.Api.GestaoDeResiduos.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Api.GestaoDeResiduos.Services
{
    public class AuthService : IAuthService
    {

        private readonly UserService _userService;

        public AuthService(UserService userService)
        {
            this._userService = userService;
        }

        public UserModel Authenticate(string username, string password)
        {
            return _userService.BuscarPorUsernameAndPassword(username, password);
        }
    }
}

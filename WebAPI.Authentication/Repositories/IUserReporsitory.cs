using Microsoft.IdentityModel.Tokens;
using WebAPI.Authentication.Model.Domain;

namespace WebAPI.Authentication.Repositories
{
    public interface IUserReporsitory
    {
        Task<User> AuthenticateAsync (string username, string password);
    }
}

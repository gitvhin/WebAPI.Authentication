using WebAPI.Authentication.Model.Domain;

namespace WebAPI.Authentication.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}

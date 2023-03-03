using WebAPI.Authentication.Model.Domain;

namespace WebAPI.Authentication.Repositories
{
    public class StaticUserRepository : IUserReporsitory
    {
        private List<User> Users = new List<User>()
        {
            new User()
            {
                FirstName = "Read Only", LastName = "User", EmailAddress = "readonly@user.com",
                Id = Guid.NewGuid(), Username = "readonly@user", Password = "readonly@user",
                Roles = new List<string> { "reader" }
            },
            new User()
            {
                FirstName = "Read Write", LastName = "User", EmailAddress = "readwrite@user.com",
                Id = Guid.NewGuid(),Username = "readwrite@user", Password = "readwrite@user",
                Roles = new List<string> { "reader", "writer" }
            }
        };

        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) &&
             x.Password == password);

            return user;
        }
    }
}

using Monsters.Data.Entities.Account;

namespace Monsters.Repositories.Interfaces
{
    public interface IUserRepository : IBaseRepository
    {
        bool EmailIsUsed(string email);

        bool UserNameIsUsed(string userName);

        User GetUser(int id);

        User GetUser2(int id);

        User GetUser3(int id);

        User GetUserByUserName(string userName);
    }
}

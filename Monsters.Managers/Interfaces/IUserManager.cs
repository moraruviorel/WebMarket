using Monsters.Data.Entities.Account;

namespace Monsters.Managers.Interfaces
{
    public interface IUserManager
    {
        User LogIn(string userName, string password);
    }
}

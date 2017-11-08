using Monsters.Data.Entities.Account;
using Monsters.Managers.Interfaces;
using Monsters.Repositories.Interfaces;
using System.Security;

namespace Monsters.Managers
{
    public class UserManager : IUserManager
    {
        private IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(User user)
        {
            if (_userRepository.EmailIsUsed(user.Email)) throw new SecurityException("Email is used.");

            if (_userRepository.EmailIsUsed(user.UserName)) throw new SecurityException("UserName is used.");
        }

        public User LogIn(string userName, string password)
        {
            // check if user exists
            var user = _userRepository.GetUserByUserName(userName);
            if (user == null) throw new SecurityException("UserName or Password is incorrect.");

            // check if password is matched
            if (user.Password != password) throw new SecurityException("UserName or Password is incorrect.");

            // check if account is disabled
            if (!user.Enabled) throw new SecurityException("Your account is disabled.");

            return user;
        }
    }
}
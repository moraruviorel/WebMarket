using Dapper;
using Microsoft.EntityFrameworkCore;
using Monsters.Data.Entities.Account;
using Monsters.DataAccess.Interfaces;
using Monsters.Repositories.Interfaces;
using System.Linq;

namespace Monsters.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool EmailIsUsed(string email)
        {
            return _unitOfWork.MonstersDbContext.Users.Any(p => p.Email == email);
        }

        public bool UserNameIsUsed(string userName)
        {
            return _unitOfWork.MonstersDbContext.Users.Any(p => p.UserName == userName);
        }

        public User GetUser(int id)
        {
            return _unitOfWork.MonstersDbContext.Users
                .Include(p => p.UserAddress.Country)
                .Where(p => p.Id == id)
                .FirstOrDefault();
        }

        public User GetUser2(int id)
        {
            return _unitOfWork.DapperContext.SqlConnection.Query<User>(@"
                    SELECT * 
                    FROM Users
                    WHERE Id = @UserId", new { @UserId = id })
                    .FirstOrDefault();
        }

        public User GetUser3(int id)
        {
            var sqlQuerry = _unitOfWork.MonstersDbContext.Users
                .Include(p => p.UserAddress.Country)
                .Where(p => p.Id == id).AsQueryable();

            return null; // _unitOfWork.DapperContext.SqlConnection.Query<User>(sqlQuerry);
        }

        public User GetUserByUserName(string userName)
        {
            return _unitOfWork.MonstersDbContext.Users
                .Include(p => p.UserAddress.Country)
                .Where(p => p.UserName == userName)
                .Single();
        }
    }
}

using Monsters.DataAccess.Dapper;
using Monsters.DataAccess.EntityFramework;

namespace Monsters.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        DapperContext DapperContext { get; }

        MonstersDbContext MonstersDbContext { get; }

        void SaveChanges();

        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();
    }
}
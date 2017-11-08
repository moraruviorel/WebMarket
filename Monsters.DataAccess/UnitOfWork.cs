using Monsters.DataAccess.Dapper;
using Monsters.DataAccess.EntityFramework;
using Monsters.DataAccess.Interfaces;

namespace Monsters.DataAccess
{
    public class UnitOfWork: IUnitOfWork
    {
        public UnitOfWork()
        {
            DapperContext = new DapperContext();
            MonstersDbContext = new MonstersDbContext();
        }

        public DapperContext DapperContext { get; private set; }

        public MonstersDbContext MonstersDbContext { get; private set; }
        
        public void SaveChanges()
        {
            MonstersDbContext.SaveChanges();
        }

        public void BeginTransaction()
        {
            MonstersDbContext.BeginTransaction();
        }

        public void CommitTransaction()
        {
            MonstersDbContext.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            MonstersDbContext.RollBackTransaction();
        }
    }
}
using Monsters.Data.Entities.Base;
using Monsters.DataAccess.Interfaces;
using Monsters.Repositories.Interfaces;
using System;

namespace Monsters.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        protected IUnitOfWork _unitOfWork;

        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void Savechanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Insert<T>(T entity, int createdById) where T : BaseTrackingEntity
        {
            var now = DateTime.UtcNow;

            entity.Created = now;
            entity.Updated = now;

            entity.CreatedById = createdById;
            entity.UpdatedById = createdById;

            _unitOfWork.MonstersDbContext.Attach(entity);
        }
    }
}

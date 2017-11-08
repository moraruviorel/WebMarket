using Monsters.Data.Entities.Base;

namespace Monsters.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        void Savechanges();

        void Insert<T>(T entity, int createdById) where T : BaseTrackingEntity;
    }
}

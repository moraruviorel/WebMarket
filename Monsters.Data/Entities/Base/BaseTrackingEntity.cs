using Monsters.Data.Entities.Account;
using System;

namespace Monsters.Data.Entities.Base
{
    [Serializable]
    public class BaseTrackingEntity : BaseEntity
    {
        public BaseTrackingEntity()
        {
            Created = DateTime.UtcNow;
            Updated = DateTime.UtcNow;
        }

        public int CreatedById { get; set; }

        public int UpdatedById { get; set; }

        public User CreatedBy { get; set; }

        public User UpdatedBy { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
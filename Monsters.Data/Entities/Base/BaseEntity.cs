using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monsters.Data.Entities.Base
{
    [Serializable]
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Identifier = Guid.NewGuid();
        }

        [Key]
        public int Id { get; set; }

        [NotMapped]
        public Guid Identifier { get; set; }
    }
}
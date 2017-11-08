using Monsters.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Monsters.Data.Entities
{
    [Serializable]
    public class Country : BaseTrackingEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }
    }
}

using Monsters.Data.Entities.Base;
using Monsters.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monsters.Data.Entities.Account
{
    [Serializable]
    public class Permission : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public UserPermissions UserPermission { get { return (UserPermissions)Id; } }
    }
}
using Monsters.Data.Entities.Base;
using Monsters.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monsters.Data.Entities.Account
{
    [Serializable]
    [Table("Roles")]
    public class Role : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [NotMapped]
        public UserRoles UserRole { get { return (UserRoles)Id; } }
    }
}
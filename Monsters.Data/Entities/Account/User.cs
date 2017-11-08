using Monsters.Data.Entities.Base;
using Monsters.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Monsters.Data.Entities.Account
{
    [Serializable]
    public class User : BaseTrackingEntity
    {
        public int RoleId { get; set; }
        public int UserAddressId { get; set; }

        public bool Enabled { get; set; }

        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        public Role Role { get; set; }

        [NotMapped]
        public UserRoles UserRole
        {
            set { RoleId = (int)value; }
            get { return (UserRoles)Id; }
        }
        
        public UserAddress UserAddress { get; set; }

        //public List<Permission> Permissions { get; set; }
    }
}
using Monsters.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Monsters.Data.Entities.Account
{
    [Serializable]
    public class UserAddress : BaseTrackingEntity
    {
        public int CountryId { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Town { get; set; }

        [Required]
        [MaxLength(50)]
        public string Address { get; set; }

        [Required]
        [MaxLength(50)]
        public string PostCode { get; set; }

        public Country Country { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class SaveUserProfileResource
    {
        [Required]
        public int UserId { get; set; }
        [MaxLength(40)]
        public string FirstName { get; set; }
        [MaxLength(40)]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public string Sex { get; set; }
        public DateTime DateOfRegistry { get; set; } = DateTime.Now;
        [Required]
        [MaxLength(40)]
        public string Address { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [MaxLength(40)]
        public string CorporationName { get; set; }
        [Required]
        public string UserType { get; set; }
        public string ImageUrl { get; set; }
        public int DistrictId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ESex Sex { get; set; }
        public DateTime DateOfRegistry { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string CorporationName { get; set; }
        public EUserType UserType { get; set; }
        public District District { get; set; }
        public int DistrictId { get; set; }
        public string ImageUrl { get; set; }

    }
}

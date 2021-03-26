using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Resources
{
    public class UserProfileResource
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
        public DateTime DateOfRegistry { get; set; }
        public string Address { get; set; }
        public int PhoneNumber { get; set; }
        public string CorporationName { get; set; }
        public string UserType { get; set; }
        public int DistrictId { get; set; }
        public string ImageUrl { get; set; }
    }
}

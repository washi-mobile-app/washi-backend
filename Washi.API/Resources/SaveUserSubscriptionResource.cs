using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class SaveUserSubscriptionResource
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int SubscriptionId { get; set; }
        public DateTime InitialDate { get; set; } = DateTime.Now;
        public DateTime EndingDate { get; set; }
    }
}

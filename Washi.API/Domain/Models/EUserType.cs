using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public enum EUserType
    {
        [Description("Washer")] Washer = 1,
        [Description("Laundry")] Laundry = 2
    }
}
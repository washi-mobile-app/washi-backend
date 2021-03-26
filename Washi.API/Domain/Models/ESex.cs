using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public enum ESex
    {
        [Description("Male")] Male = 1,
        [Description("Female")] Female = 2
    }
}
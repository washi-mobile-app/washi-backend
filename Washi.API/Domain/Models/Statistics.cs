﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class Statistic
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool HasOrders { get; set; }
    }
}

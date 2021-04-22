using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class DetergentResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int UserId { get; set; }
    }
}

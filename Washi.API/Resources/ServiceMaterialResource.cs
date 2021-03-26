using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Resources
{
    public class ServiceMaterialResource
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public int MaterialId { get; set; }
    }
}

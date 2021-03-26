using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Washi.API.Domain.Models
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ServiceMaterial> ServiceMaterials { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class DepartmentResponse: BaseResponse<Department>
    {
        public DepartmentResponse(string message) : base(message) { }
        public DepartmentResponse(Department department) : base(department) { }
    }
}

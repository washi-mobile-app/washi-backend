using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Washi.API.Domain.Models;

namespace Washi.API.Domain.Services.Communications
{
    public class StatisticResponse: BaseResponse<Statistic>
    {
        public StatisticResponse(string message) : base(message) { }
        public StatisticResponse(Statistic statistic) : base(statistic) { }
    }
}

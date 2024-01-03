using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO.Teams
{
    public class TeamSummaryDto : ISelectValue
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

    }
}

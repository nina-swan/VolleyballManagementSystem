using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO
{
    public class PositionDto


    {
        public int Id
        { get; set; }

        public string Name { get; set; } = null!;

        public static PositionDto GeneratePositionDTO(VolleyballDomain.Shared.Models.Position position)
        {
            return new PositionDto()
            {
                Id = position.PositionId,
                Name = position.Name
            };
        }
    }
}

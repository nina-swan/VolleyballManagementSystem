using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO
{
    public class PositionDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public static implicit operator Position(PositionDto positionDto)
        {
            return new Position
            {
                Id = positionDto.Id,
                Name = positionDto.Name
            };
        }
    }
}

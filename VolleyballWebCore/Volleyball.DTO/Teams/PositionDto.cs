using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO.Teams
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

        public static explicit operator PositionDto(Position position)
        {
            return new PositionDto
            {
                Id = position.Id,
                Name = position.Name
            };
        }
    }
}

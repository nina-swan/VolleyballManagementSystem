using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO;
using VolleyballDomain.Shared.Models;

namespace Volleyball.DTO
{
    public partial class PlayerDTO
    {
        public int PlayerId { get; set; }

        [StringLength(255)]
        public string Name { get; set; } = null!;

        [StringLength(255)]
        public string Surname { get; set; } = null!;

        [StringLength(255)]
        public string? Email { get; set; }


        [StringLength(255)]
        public string? City { get; set; }

        public bool Sex { get; set; }

        [StringLength(255)]
        public string? PhoneNumber { get; set; }

        public PositionDto Position { get; set; }

        public virtual int? TeamOwnerId { get; set; }

        public virtual ICollection<int> TeamsPlayerIds { get; set; } = new List<int>();

        // function to generate PlayerDTO from Player
        public static PlayerDTO GeneratePlayerDTO(Player player)
        {
            return new PlayerDTO()
            {
                PlayerId = player.PlayerId,
                Name = player.Name,
                Surname = player.Surname,
                Email = player.Email,
                City = player.City,
                PhoneNumber = player.PhoneNumber,
                Position = new PositionDto()
                {
                    Name = player.Position.Name,
                    Id = player.Position.PositionId
                },
                TeamOwnerId = player.TeamOwner?.TeamId,
                TeamsPlayerIds = player.TeamsPlayer.Select(x => x.TeamId).ToList()
            };
        }

        //function to generate Player from PlayerDTO
        public static Player GeneratePlayer(NewPlayerDTO playerDTO)
        {
            return new Player()
            {
                Name = playerDTO.Name,
                Surname = playerDTO.Surname,
                Email = playerDTO.Email,
                City = playerDTO.City,
                PhoneNumber = playerDTO.PhoneNumber,
                PositionId = playerDTO.PositionId 
            };
        }   
    }

}

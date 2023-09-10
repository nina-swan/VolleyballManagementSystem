﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volleyball.DTO
{
    public class TeamDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public DateTime CreationDate { get; set; }

        public byte[]? Image { get; set; }

        public LeagueDto? League { get; set; }

        public UserProfileDto Captain { get; set; } = null!;

        public List<UserProfileDto> Players { get; set; } = null!;

        public string Email { get; set; } = null!;

        public byte[]? Logo { get; set; }

        public byte[]? Photo { get; set; }

        public string Phone { get; set; } = null!;

        public string? TeamDescription { get; set; }

        public string? Website { get; set; }

        public int? PointCorrection { get; set; }
    }
}
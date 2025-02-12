﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volleyball.DTO.Teams;
using Volleyball.Infrastructure.Database.Models;

namespace Volleyball.DTO.Matches
{
    public class NewMatchDto
    {
        [Display(Name = "Data")]
        public DateTime Schedule { get; set; } = DateTime.Now;

        [Display(Name = "Sezon")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz sezon")]
        public int SeasonId { get; set; }

        [Display(Name = "Liga")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz ligę")]
        public int LeagueId { get; set; }

        [Display(Name = "Miejsce")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz miejsce")]
        public int VenueId { get; set; }

        [Display(Name = "Sektor")]
        public int Sector { get; set; }

        [Display(Name = "Runda")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz rundę")]
        public int RoundId { get; set; }

        [Display(Name = "Sędzia")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz sędziego")]
        public int RefereeId { get; set; }

        [Display(Name = "Dodatkowe informacje")]
        public string? MatchInfo { get; set; }

        [Display(Name = "Drużyna gospodarzy")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz drużynę gospodarzy")]
        [Required(ErrorMessage = "Wybierz drużynę gospodarzy")]
        public int HomeTeamId { get; set; }

        [Display(Name = "Drużyna gości")]
        [Range(1, int.MaxValue, ErrorMessage = "Wybierz drużynę gości")]
        public int GuestTeamId { get; set; }

        public static explicit operator Match(NewMatchDto newMatchDto)
        {
            return new Match
            {
                Schedule = newMatchDto.Schedule,
                VenueId = newMatchDto.VenueId,
                LeagueId = newMatchDto.LeagueId,
                Sector = (byte)newMatchDto.Sector,
                RoundId = newMatchDto.RoundId,
                RefereeId = newMatchDto.RefereeId,
                MatchInfo = newMatchDto.MatchInfo,
                HomeTeamId = newMatchDto.HomeTeamId,
                GuestTeamId = newMatchDto.GuestTeamId,
                MvpId = null,
            };
        }
    }
}

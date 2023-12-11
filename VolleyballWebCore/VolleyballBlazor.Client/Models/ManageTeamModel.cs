using Volleyball.DTO.Teams;
using VolleyballBlazor.Client.Shared;
using VolleyballBlazor.Client.Shared.FormUtils;

namespace VolleyballBlazor.Client.Models
{
    public class ManageTeamModel : ManageTeamDto
    {
        [ValidateEachItem]
        [ExcludeFromForm]
        public override List<TeamPlayerDto> Players { get; set; } = new List<TeamPlayerDto>();

        [ExcludeFromForm]
        public override List<TeamPlayerDto> NewPlayers { get; set; } = new List<TeamPlayerDto>();

        [ExcludeFromForm]
        public override List<TeamPlayerDto> RemovedPlayers { get; set; } = new List<TeamPlayerDto>();

        public ManageTeamModel(ManageTeamDto manageTeam)
        {
            this.Email = manageTeam.Email;
            this.Logo = manageTeam.Logo;
            this.Photo = manageTeam.Photo;
            this.Phone = manageTeam.Phone;
            this.Players = manageTeam.Players;
            this.TeamDescription = manageTeam.TeamDescription;
            this.Website = manageTeam.Website;
        }

        public ManageTeamModel()
        {
        }
    }
}

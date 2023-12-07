using Volleyball.DTO.Teams;
using VolleyballBlazor.Client.Shared;
using VolleyballBlazor.Client.Shared.FormUtils;

namespace VolleyballBlazor.Client.Models
{
    public class NewTeam : NewTeamDto
    {
        [ValidateEachItem]
        [ExcludeFromForm]
        public override List<TeamPlayerDto> Players { get; set; } = new List<TeamPlayerDto>();
    }
}

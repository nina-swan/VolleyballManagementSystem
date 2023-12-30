using Volleyball.DTO.Matches;
using VolleyballBlazor.Client.Shared.FormUtils;

namespace VolleyballBlazor.Client.Models
{
    public class NewMatchModel : NewMatchDto
    {
        [ExcludeFromForm]
        public List<string> VenueList { get; set; } = new List<string>() { "asd" };
    }
}

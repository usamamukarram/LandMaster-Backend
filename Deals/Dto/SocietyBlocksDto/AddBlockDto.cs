using System.Text.Json.Serialization;

namespace Deals.Dto.SocietyBlocksDto
{
    public class AddBlockDto
    {
        public string Name { get; set; }
        [JsonIgnore]
        public Deals.Models.Society ? society { get; set; }
        public int societyId { get; set; }
    }
}

using System.Text.Json.Serialization;

namespace Deals.Dto.SocietyBlocksDto
{
    public class UpdateBlockDto
    {
        public int BlockID { get; set; }
        public string Name { get; set; }
        public bool BlockStatus { get; set; }
        [JsonIgnore]
        public Deals.Models.Society? society { get; set; }
        public int societyId { get; set; }
    }
}

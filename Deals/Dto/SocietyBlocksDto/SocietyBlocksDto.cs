using Deals.Models;
namespace Deals.Dto.SocietyBlocksDto

{
    public class SocietyBlocksDto
    {
        public int BlockID { get; set; }
        public string Name { get; set; }
        public bool BlockStatus { get; set; }
        public  Deals.Models.Society ? society { get; set; }
        public int societyId { get; set; }
    }
}

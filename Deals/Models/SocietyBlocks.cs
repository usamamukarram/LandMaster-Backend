using System.ComponentModel.DataAnnotations;

namespace Deals.Models
{
    public class SocietyBlocks
    {
        [Key]
        public int BlockId { get; set; }
        public string Name { get; set; }
        public bool BlockStatus { get; set; } = false;

        public Society society { get; set; }
    }
}

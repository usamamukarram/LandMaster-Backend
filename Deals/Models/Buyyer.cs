using System.ComponentModel.DataAnnotations;

namespace Deals.Models
{
    public class Buyyer
    {
        public int Id { get; set; }
        public string BuyerName { get; set; } = string.Empty;
        [Phone]
        public string Contact_number { get; set; } = string.Empty;
        public string Budget { get; set; } = string.Empty;
        public PlotSize PlotSize { get; set; }
        public User User { get; set; }

        public SocietyBlocks SocietyBlocks { get; set; }
    }
}

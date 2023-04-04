using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Deals.Models
{
    public class Roles
    {

        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; } 
       
       //public  User User { get; set; }
    }
}

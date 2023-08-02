using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Admin
    {
        [StringLength(20)]
        public string? UserId { get; set; }

        [StringLength(20)]
        public string? Password { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class Donor
    {
        [StringLength(50)]
        public string? FirstName { get; set; }

        [StringLength(50)]
        public string? LastName { get; set; }

        [StringLength(50)]
        public string? Password { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [StringLength(100)]
        public string? Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? ContactNo { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? EmailId { get; set; }

        [StringLength(50)]
        public string? Gender { get; set; }

        [StringLength(50)]
        public string? BloodGroup { get; set; }

        [StringLength(50)]
        [Required]
        public string DonorId { get; set; }
    }
}

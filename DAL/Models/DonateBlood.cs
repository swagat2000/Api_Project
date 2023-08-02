using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class DonateBlood
    {
        [StringLength(10)]
        
        public string? DonorId { get; set; }

        [StringLength(30)]
        public string? FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [StringLength(50)]
        public string? City { get; set; }

        [StringLength(15)]
        public string? Gender { get; set; }

        [StringLength(10)]
        public string? Blood_Group { get; set; }

        [StringLength(6)]
        public string? Weight { get; set;}

        [DataType(DataType.Date)]
        public DateTime Date_Of_Last_Donation { get; set; }

        [StringLength(50)]
        public string? How_Many_Times { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Phone_Number { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string? EmailId { get; set; }

        [StringLength(50)]
        public string? Status { get; set; }
    }
}

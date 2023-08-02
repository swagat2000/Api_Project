using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class RequestBlood
    {
        [StringLength(10)]
        
        public string RequestorId { get; set; }

        [StringLength(50)]
        public string Patient_Name { get; set; }

        [StringLength(5)]
        public string Required_Blood_Group { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string DoctorName { get; set; }

        [StringLength(100)]
        public string Hospital_Name_Address { get; set; }

        [DataType(DataType.Date, ErrorMessage ="Enter Valid Date Format")]
        public DateTime Blood_required_Date { get; set; }

        [StringLength(50)]
        public string Contact_Name { get; set; }

        [StringLength(50)]
        public string Contact_Number { get; set;}

        [DataType(DataType.EmailAddress,ErrorMessage ="Enter in valid Email Format")]
        [EmailAddress]
        public string Contact_Email_Id { get; set;}

        [StringLength(100)]
        public string Message { get; set;}
    }
}

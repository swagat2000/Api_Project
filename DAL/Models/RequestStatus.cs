using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models
{
    public class RequestStatus
    {
        [StringLength(10)]
        public string RequestorId { get; set; }

        [StringLength(30)]
        public string PatientId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Time_Of_The_Day { get; set;}

        [StringLength(50)]
        public string Blood_Glucose_Level { get; set; }

        [StringLength(50)]
        public string Notes { get; set; }
    }
}

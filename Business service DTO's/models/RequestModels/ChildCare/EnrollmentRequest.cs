using System.ComponentModel.DataAnnotations;

#nullable disable

namespace businessServicess.models.RequestModels.ChildCare
{
    public class EnrollmentRequest
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Admission Id Required")]
        public int childID { get; set; }
        [Required(ErrorMessage = "Child Id Required")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "Parent Id Required")]
        [enrollmentstarting(ErrorMessage = "Enrollment Starting Date must be between {1:dd/MM/yyyy} and {2:dd/MM/yyyy}")]
        public DateTime EnrollmentStartingDate { get; set; }
        [Required]
        [enrollmententing(ErrorMessage = "Enrollment Enting Date minimum  start with {1:d/MM/yyyy} and {2:d/MM/yyyy}")]
        public DateTime EnrollmentEndinggDate { get; set; }
        [Required]
        public string Classname { get; set; }
        [Required]
        public string Slotname { get; set; }
        [Required]
        public string CreateBy { get; set; }
        public string AdmissionStatus { get; set; }

    }
    public class enrollmentstarting : RangeAttribute
    {
        public enrollmentstarting()
            : base(typeof(DateTime), DateTime.Now.ToString(), DateTime.Now.AddYears(+1).ToString()) { }
    }
    public class enrollmententing : RangeAttribute
    {
        public enrollmententing()
            : base(typeof(DateTime), DateTime.Now.AddDays(+1).ToString(), DateTime.Now.AddYears(+1).ToString()) { }
    }

}


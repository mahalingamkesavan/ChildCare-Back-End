
#nullable disable
using System.ComponentModel.DataAnnotations;

namespace businessServicess.models.RequestModels.ChildCare
{
    public class ChildEnrollment
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "admission Id Required")]
        public int childID { get; set; }
        [Required(ErrorMessage = "Child Id Required")]
        public int parentId { get; set; }
        [Required(ErrorMessage = "Parent Id Required")]
        [enrollmentstarting(ErrorMessage = "Enrollment Starting Date must be between {1:d/MM/yyyy} and {2:d/MM/yyyy}")]
        // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EnrollmentStartingDate { get; set; }
        [Required]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "yyyy-MM-dd")]
        [enrollmententing(ErrorMessage = "Enrollment Enting Date minimum  start with {1:d/MM/yyyy} and {2:d/MM/yyyy}")]
        public DateTime EnrollmentEndinggDate { get; set; }
        [Required]
        public string Classname { get; set; }
        [Required]
        public string Slotname { get; set; }
        public string CreateBy { get; set; }
        public string CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }
        public string AdmissionStatus { get; set; }
        public string Admission_Approveby { get; set; }


    }
}

#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace businessServicess.models.RequestModels.ChildCare
{
    public class Child : CommonFields
    {
        [Key]
        [Required(ErrorMessage = "Id Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Parent id required")]
        public int parentID { get; set; }

        [Required(ErrorMessage = "Gander required")]
        [StringLength(10)]
        public string Gender { get; set; }
        [DateOfBirthRange(ErrorMessage = "BirthDate must be between {1:M/d/yyyy} and {2:M/d/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(245)]
        public string UserImage { get; set; }
    }

}

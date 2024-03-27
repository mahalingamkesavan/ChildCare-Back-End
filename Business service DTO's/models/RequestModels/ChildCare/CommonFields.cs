#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace businessServicess.models.RequestModels.ChildCare
{
    public class CommonFields
    {
        [Required(ErrorMessage = "First name Required")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "First Name Maximum 50 character's only ")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = " First Name Only allow letters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name Required")]
        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "Last Name Maximum 50 character's only")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last Name Only allow latters")]
        public string LastName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "Status Maximum 50 character's only ")]
        public string Status { get; set; } = "Active";
    }
}

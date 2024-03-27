
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace businessServicess.models.RequestModels.ChildCare
{
    public class Parent : CommonFields
    {

        [Column(name: "ParentId")]
        [Required(ErrorMessage = " Id Required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "PhoneNumber is Required,")]
        [Column(TypeName = "Varchar")]
        [StringLength(10, ErrorMessage = "PhoneNumber Length Maximum 10 digits")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [Column(TypeName = "Varchar")]
        [StringLength(70, ErrorMessage = "Email Length Maximum 70 digits")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Address is Required")]
        [Column(TypeName = "Varchar")]
        [StringLength(70, ErrorMessage = "Address Length Maximum 100 characters")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Choose the City,City is Required")]
        [Column(TypeName = "Varchar")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Choose the State,City is Required")]
        [Column(TypeName = "Varchar")]
        public string? State { get; set; }

        [Required(ErrorMessage = "Enter Your Pincode")]
        [Column(TypeName = "Varchar")]
        [StringLength(15, ErrorMessage = "The Pincode Maximum lenth 15")]
        public string? Pincode { get; set; }

        [Required(ErrorMessage = "Enter Your loginUser Name")]
        [Column(TypeName = "Varchar")]
        public string? loginname { get; set; }

        [Column(TypeName = "Varchar")]
        public string? UserImage { get; set; }
    }

}

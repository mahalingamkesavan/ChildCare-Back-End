
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace businessServicess.models.RequestModels.ChildCare
{
    public class ChildRequest : CommonFields
    {
        [Required(ErrorMessage = "Parent id required")]
        public int parentID { get; set; }
        [Required(ErrorMessage = "Gander required")]
        [StringLength(10)]
        public string Gender { get; set; }
        [DateOfBirthRange(ErrorMessage = "BirthDate must be between {1:d/MM/yyyy} and {2:d/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string UserImage { get; set; }
        public IFormFile UserImageUrl { get; set; } = null;

    }
    public class DateOfBirthRange : RangeAttribute
    {
        public DateOfBirthRange()
            : base(typeof(DateTime), DateTime.Now.AddYears(-5).ToShortDateString(), DateTime.Now.AddYears(-1).ToShortDateString()) { }
    }
}

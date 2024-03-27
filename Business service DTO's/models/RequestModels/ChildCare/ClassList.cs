using System.ComponentModel.DataAnnotations;

namespace businessServicess.models.RequestModels.ChildCare
{
    public class ClassList
    {
        [Key]
        public int ClassId { get; set; }
        [Required(ErrorMessage = "the class Name required")]
        [StringLength(100)]
        public string? ClassName { get; set; }

    }
}

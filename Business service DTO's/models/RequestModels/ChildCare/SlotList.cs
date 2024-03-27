using System.ComponentModel.DataAnnotations;

namespace businessServicess.models.RequestModels.ChildCare
{
    public class SlotList
    {
        [Key]
        public int SlotId { get; set; }

        [Required(ErrorMessage = "the Slot Name required")]
        [StringLength(100)]
        public string? SlotName { get; set; }
    }
}

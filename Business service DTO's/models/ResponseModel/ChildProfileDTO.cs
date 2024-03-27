namespace businessServicess.models.ResponseModel
{
    public class ChildProfileDTO
    {
        public int ChildId { get; set; }
        public string? ChildFirstName { get; set; }
        public string? ChildLastName { get; set; }
        public string? Gender { get; set; }
        public DateTime DOB { get; set; }
        public string? Status { get; set; }
        public string? ParentFirstName { get; set; }
        public string? ParentLastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? ClassStartingDate { get; set; }
        public DateTime? ClassEndingDate { get; set; }

    }
}

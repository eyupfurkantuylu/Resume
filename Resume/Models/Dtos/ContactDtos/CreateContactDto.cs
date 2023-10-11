namespace Resume.Models.Dtos.ContactDtos
{

    public class CreateContactDto
    {
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendeDate { get; set; }
        public bool Status { get; set; }
    }

}
namespace Resume.Models.Dtos.AdminDtos.ContactDtos
{

    public class ContactDetailDto
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime SendeDate { get; set; }
        public bool Status { get; set; }
    }

}
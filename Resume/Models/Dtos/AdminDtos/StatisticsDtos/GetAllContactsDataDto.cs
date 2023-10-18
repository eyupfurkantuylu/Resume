namespace Resume.Models.Dtos.AdminDtos.StatisticsDtos
{

    public class GetAllContactsDataDto
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public DateTime SendDate { get; set; }
        public bool Status { get; set; }
        
    }

}
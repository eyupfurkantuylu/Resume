namespace Resume.Models.Dtos.AdminDtos.ExperienceDtos
{

    public class UpdateAdminExperienceDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string ExperienceDate { get; set; }
    }

}
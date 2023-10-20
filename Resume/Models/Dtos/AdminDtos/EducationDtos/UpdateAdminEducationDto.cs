namespace Resume.Models.Dtos.AdminDtos.EducationDtos
{

    public class UpdateAdminEducationDto
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public string GPA { get; set; }
        public string EducationDate { get; set; }
    }

}
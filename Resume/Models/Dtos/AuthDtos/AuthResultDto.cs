namespace Resume.Models.Dtos.AuthDtos
{

    public class AuthResultDto
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public int? ID { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

}
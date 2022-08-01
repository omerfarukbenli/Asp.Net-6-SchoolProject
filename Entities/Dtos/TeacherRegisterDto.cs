using Microsoft.AspNetCore.Http;

namespace Entities.Dtos
{
    public class TeacherRegisterDto
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? IdentityNumber { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        public IFormFile? Image { get; set; }
    }
}

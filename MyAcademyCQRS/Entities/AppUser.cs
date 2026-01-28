using Microsoft.AspNetCore.Identity;

namespace MyAcademyCQRS.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

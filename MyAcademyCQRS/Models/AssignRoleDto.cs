namespace MyAcademyCQRS.Models
{
    public class AssignRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExists { get; set; }
    }
}

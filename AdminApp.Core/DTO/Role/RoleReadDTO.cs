using AdminApp.Core.DTO.User;

namespace AdminApp.Core.DTO.Role
{
    public class RoleReadDTO
    {
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<UserReadDTO> Users { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace AdminApp.Core.Entities
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public virtual List<User> Users { get; set; }
    }
}

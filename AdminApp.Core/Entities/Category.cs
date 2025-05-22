using System.ComponentModel.DataAnnotations;

namespace AdminApp.Core.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public virtual List<Item> Items { get; set; }
    }
}

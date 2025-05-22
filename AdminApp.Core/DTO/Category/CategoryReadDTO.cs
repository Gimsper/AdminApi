using AdminApp.Core.DTO.Item;

namespace AdminApp.Core.DTO.Category
{
    public class CategoryReadDTO
    {
        public int CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<ItemReadDTO> Items { get; set; }
    }
}

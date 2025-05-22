namespace AdminApp.Core.DTO.Item
{
    public class ItemUpdateDTO
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}

namespace Case1.Core.Entities.Dtos
{
    public class CartDto:IDto
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int? ProductId { get; set; }
        public int? ProductAmount { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public int? ProductCategoryId { get; set; }
        public string? ProductPicture { get; set; }




    }
}

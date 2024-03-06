using Case1.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Case1.Core.Entities.Concrete
{
    public class Product:IEntity
    {
        [Key]
        public int ProductId { get; set; }  
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public string? ProductDescription { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? ProductAmount { get; set;}
        public string? ProductPicture { get; set; }




    }
}

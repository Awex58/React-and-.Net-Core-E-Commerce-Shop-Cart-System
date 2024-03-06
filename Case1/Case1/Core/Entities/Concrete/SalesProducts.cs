using Case1.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Case1.Core.Entities.Concrete
{
    public class SalesProducts : IEntity
    {
        [Key]
        public int SaleId { get; set; }
        public string? SaleProductName { get; set; }
        public decimal? SalePrice { get; set; }
        public int? SaleAmount { get; set; }
        public int? CategoryId { get; set; }

        public DateTime SaleTime { get; set; } = DateTime.Now;
        public int SaleUserId { get; set; }
        public string? SaleAddress { get; set; }


    }
}

using Case1.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Case1.Core.Entities.Concrete
{
    public class Cart:IEntity
    {
        [Key]
        public int CartId { get; set; }
        public int? UserId { get; set;}
        public int? ProductId { get; set;}
        public int? ProductAmount { get; set;}
    }
}

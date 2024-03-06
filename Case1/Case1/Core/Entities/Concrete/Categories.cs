using Case1.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Case1.Core.Entities.Concrete
{
    public class Categories : IEntity
    {
        [Key]
        public int CategoryId {  get; set; }
        public string? CategoryName { get; set; }
    }
}

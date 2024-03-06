using Case1.Core.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Case1.Core.Entities.Concrete
{
    public class User: IEntity
    {

        [Key]
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
    }
}

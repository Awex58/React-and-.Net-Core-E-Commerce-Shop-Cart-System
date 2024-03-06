namespace Case1.Core.Entities.Dtos
{
    public class UserForLoginDto:IDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}

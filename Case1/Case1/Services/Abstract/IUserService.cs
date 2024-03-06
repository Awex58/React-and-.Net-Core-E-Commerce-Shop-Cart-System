using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Core.Entities.Results;
using System.Diagnostics;

namespace Case1.Services.Abstract
{
    public interface IUserService
    {
        IResultt Login(UserForLoginDto userdto);
        IResultt Add(User user);
        IResultt Delete(User user);
        IResultt Update(User user);
        
    }
}

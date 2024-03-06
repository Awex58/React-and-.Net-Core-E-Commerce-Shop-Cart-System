using Case1.Core.DataAccess.EntityFrameworkDal.Abstract;
using Case1.Core.DataAccess.EntityFrameworkDal.Concrete;
using Case1.Core.Entities.Concrete;
using Case1.Core.Entities.Dtos;
using Case1.Core.Entities.Results;
using Case1.Services.Abstract;
using System.Diagnostics;

namespace Case1.Services.Concrete
{
    public class UserService : IUserService
    {

        private IUserDal _userDal;


        public UserService(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResultt Login(UserForLoginDto userdto)
        {
           var user = _userDal.Get(u => u.UserName == userdto.UserName && u.UserPassword == userdto.Password); // user varsa getirir

            if (user != null)
            {
                return new Result(true,user.UserId); // token olsaydı token yollardık
            }

            return new ErrorResult("Kullanıcı veya Şifre yanlış!"); 
        }
       

        public IResultt Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("Kişi Başarıyla Eklendi!");
        }

        public IResultt Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("Kişi Başarıyla Silindi!");
        }

        public IResultt Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("Kişi Başarıyla Güncellendi!");
        }



    }
}

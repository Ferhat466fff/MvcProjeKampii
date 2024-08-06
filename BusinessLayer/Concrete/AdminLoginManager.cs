using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminDal _adminDal;

        public AdminLoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetAdmin(string username, string password)//Admin Giriş yapacak(username ve şifresiyle)
        {
            return _adminDal.Get(x => x.UserName==username && x.AdminPassword==password);
        }
    }
}

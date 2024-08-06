using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminLoginService
    {
        Admin GetAdmin(string username, string password);//Admin Giriş yapacak(username ve şifresiyle)

    }
}

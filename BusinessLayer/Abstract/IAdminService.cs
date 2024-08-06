using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{//Burada interface(service) methodu tanımla.manager kısmında içini doldur.
    public interface IAdminService 
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin);
        Admin GetByID(int id);//Id göre alma.
        void AdminDelete(Admin admin);
        void UpdateAdmin(Admin admin);

    }
}

using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{//Burada interface(service) methodu tanımla.manager kısmında içini doldur.
    public interface IAboutService
    {
        List<About> GetList();
        void AboutAdd(About about);
        About GetByID(int id);//Id göre alma.
        void AboutDelete(About about);
        void UpdateAbout(About about);
    }
}

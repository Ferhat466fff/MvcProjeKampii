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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AboutAdd(About about)
        {
           _aboutDal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            _aboutDal.Delete(about);
        }

        public About GetByID(int id)
        {
            return _aboutDal.Get(x => x.AboutId==id);
        }

        public List<About> GetList()
        {
            return _aboutDal.List();
        }

        public void ToggleActiveStatus(int id)
        {
           var values =_aboutDal.Get(x => x.AboutId == id);
            if(values != null)
            {
                if(values.IsActive==true)
                {
                    values.IsActive = false;
                }
                else
                {
                    values.IsActive = true;
                }
            }
            _aboutDal.Update(values);
        }

        public void UpdateAbout(About about)
        {
          _aboutDal.Update(about);
        }
    }
}

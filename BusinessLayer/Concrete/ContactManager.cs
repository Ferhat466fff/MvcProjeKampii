using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void CategoryAdd(Contact contact)
        {
          _contactDal.Insert(contact);
        }

        public void CategoryDelete(Contact contact)
        {
           _contactDal.Delete(contact);
        }

        public Contact GetByID(int id)
        {
           return _contactDal.Get(x => x.ContactId== id);
        }

        public int GetContactCount()//İletişim sayfasındaki kişi sayısı methodu.
        {
            return _contactDal.List().Count();
        }

        public List<Contact> GetList()
        {
           return _contactDal.List();
        }

        public void ToggleReadStatus(int id)
        {
            var values = _contactDal.Get(x => x.ContactId== id);
            if(values != null)
            {
                if(values.IsRead==true)
                {
                    values.IsRead = false;
                }
                else
                {
                    values.IsRead = true;
                }
                _contactDal.Update(values);
            }
        }
    
        public void UpdateCategory(Contact contact)
        {
          _contactDal.Update(contact);
        }
    }
}

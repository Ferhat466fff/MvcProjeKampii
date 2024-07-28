using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        void CategoryAdd(Contact contact);
        Contact GetByID(int id);//Id göre alma.
        void CategoryDelete(Contact contact);
        void UpdateCategory(Contact contact);
        int GetContactCount();
    }
}

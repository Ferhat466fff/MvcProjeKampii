using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo=new GenericRepository<Category>();

        public List<Category> GetAll()//Hepsini getirme methodu
        {
            return repo.List();
        }
        public void CategoryAddBL(Category p)
        {
            if(p.CategoryName==""|| p.CategoryName.Length<=3 || p.CategoryDescription==""||p.CategoryName.Length>=51)//bunlar sağlanıyorsa hata mesajı verecek.
            {
                //Hata Mesajı
            }
            else//sorunsuz çalışırsa ekleme işlemi yapcak.
            {
                repo.Insert(p);
            }
        }

    }
}

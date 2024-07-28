using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{//Burada Methodun İçini Doldur.
    public class CategoryManager : ICategoryService
    {

        ICategoryDal _categoryDal;
        IHeadingDal _headingDal;

        public CategoryManager(ICategoryDal categoryDal, IHeadingDal headingDal)
        {
            _categoryDal = categoryDal;
            _headingDal = headingDal;
        }

        //Kategori ekleme
        public void CategoryAdd(Category category)
        {
            _categoryDal.Insert(category);
            
        }
        //Kategori Silme
        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public int fark()//Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark

        {
            var evet= _categoryDal.List( x=> x.CategoryStatus==true).Count();
           var hayır= _categoryDal.List( x=> x.CategoryStatus==false).Count();
           int deger = evet - hayır;
            return deger;
        }

        public Category GetByID(int id)//Idler eşitse al.
        {
            return _categoryDal.Get(x => x.CategoryId==id);
        }

        public string GetCategoryWithMostHeadings()//En fazla başlığa sahip kategori adı

        {
            var categories = _categoryDal.List();//Kategori Listesi
            var headings = _headingDal.List();////Başlık Listesi

            var values = categories
                .Select(category => new
                {
                    CategoryName = category.CategoryName,
                    HeadingCount = headings.Count(heading => heading.CategoryId == category.CategoryId)
                })
                .OrderByDescending(x => x.HeadingCount)
                .FirstOrDefault();

            return values?.CategoryName ?? "No Category";
        }

        //Kategorileri Listeleme
        public List<Category> GetList()
        {
            return _categoryDal.List();
        }

        public int SumCategory()//Toplam Kategori Sayısı
        {
            return _categoryDal.List().Count();
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}

using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{//Burada interface(service) methodu tanımla.manager kısmında içini doldur.
    public interface ICategoryService
    {
        List<Category> GetList();
        void CategoryAdd (Category category);
        Category GetByID(int id);//Id göre alma.
        void CategoryDelete(Category category);
        void UpdateCategory(Category category);
        int SumCategory();//Toplam Kategori Sayısı
        int fark();//Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
        string GetCategoryWithMostHeadings();//En fazla başlığa sahip kategori adı

    }
}

using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class istatislikController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal(), new EFHeadingDal());
        WriterManager wm =new WriterManager(new EFWriterDal());
       
        public ActionResult Index()
        {
            TempData["SumCategory"] = cm.SumCategory();// Toplam Kategori Sayısı        
            TempData["AWriter"] = wm.AWriter();// İsminde A harfi Geçen Yazar Sayısı.      
            TempData["fark"] = cm.fark();//Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            TempData["CategoryWithMostHeadings"] = cm.GetCategoryWithMostHeadings();// En fazla başlığa sahip kategori adı

            return View();
        }
    }
}
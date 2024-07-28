using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
   
    public class AdminCategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EFCategoryDal(), new EFHeadingDal());//CategoryManager(crud işlemleri) efcategory kullanıyoruz.
        [Authorize]//Erişim İzni yok.
        //Kategori Listeleme
        public ActionResult Index()
        {
            var values = cm.GetList();
            return View(values);
        }

        //Kategori ekleme
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            CategoryValidator category = new CategoryValidator(); //Burası ValidationRules içerisinde hata mesajları kısmı.
            ValidationResult result = category.Validate(p);//Kategoriye göre hata mesajlarını verecek.ValidationResult(fluent olanını seçmen gerek ctrl . yapınca)
            if (result.IsValid)//Sonuç geçerliyse
            {
                cm.CategoryAdd(p);//ekleme yap.cm-->CategoryManager kategori ekleme nesnesi.
                return RedirectToAction("Index");
            }
            else//değilse
            {
                foreach (var item in result.Errors)//hataları göster 
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//propert-->veritabanındaki stun adları kategoriname,categorydescription..

                }
            }
            return View();
        }


        //Kategori Sİlme
        public ActionResult DeleteCategory(int id)
        {
            var values = cm.GetByID(id);
            cm.CategoryDelete(values);
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var values = cm.GetByID(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            CategoryValidator category2 = new CategoryValidator();
            ValidationResult result = category2.Validate(category);
            if (result.IsValid)
            {
                cm.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)//hataları göster 
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//propert-->veritabanındaki stun adları kategoriname,categorydescription..

                }
            }
            return View();
         
        }






    }
}
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
    public class AdminHeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal(), new EFHeadingDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        //Başlık Listeleme
        public ActionResult Index()
        {
            
            var values = hm.GetList();
            return View(values);
        }


        //Başlık Ekleme

        // DropDownList ile kategorileri ve yazar seçtirme
        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> category = (from x in cm.GetList()
                                           select new SelectListItem
                                           {
                                               Value = x.CategoryId.ToString(),
                                               Text = x.CategoryName
                                           }).ToList();
            //en başta kategori seçiniz alanı gelsi ama kullancıı kategori seçiniiz seçemesin(disabled)
            category.Insert(0, new SelectListItem { Text = "Kategori Seçiniz", Value = "", Disabled = true, Selected = true });
            ViewBag.tasi = category;

            List<SelectListItem> writer = (from x in wm.GetList()
                                             select new SelectListItem
                                             {
                                                 Value = x.WriterId.ToString(),
                                                 Text = x.WriterName
                                             }).ToList();
            //en başta kategori seçiniz alanı gelsi ama kullancıı kategori seçiniiz seçemesin(disabled)
            writer.Insert(0, new SelectListItem { Text = "Yazar Seçiniz", Value = "", Disabled = true, Selected = true });
            ViewBag.tasi2 = writer;




            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());//Bugunun tarihini vercek
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        //Başlık Güncelleme
        [HttpGet]
        public ActionResult UpdateHeading(int id)
        {
            List<SelectListItem> category=(from x in cm.GetList()select new SelectListItem
            {
                Value=x.CategoryId.ToString(),
                Text=x.CategoryName
            }).ToList();
            //en başta kategori seçiniz alanı gelsi ama kullancıı kategori seçiniiz seçemesin(disabled)
            category.Insert(0, new SelectListItem { Text = "Kategori Seçiniz", Value = "", Disabled = true, Selected = true });
            ViewBag.tasi = category;

            var HeadingValue = hm.GetById(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalues = hm.GetById(id);
            if (headingvalues.HeadingStatus == true)//durum true ise butona basınca flase yapsın
            {
                headingvalues.HeadingStatus = false;
                hm.HeadingDelete(headingvalues);
            }
            else//değilse tam tersi
            {
                headingvalues.HeadingStatus = true;
                hm.HeadingDelete(headingvalues);
            }
            return RedirectToAction("Index");
        }








    }
}
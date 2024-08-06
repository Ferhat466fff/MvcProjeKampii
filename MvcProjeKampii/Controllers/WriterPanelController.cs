using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using System.IO;

namespace MvcProjeKampii.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal(), new EFHeadingDal());
        WriterManager wm =new WriterManager(new EFWriterDal());
        Context c = new Context();//Tüm Entitiyler.


        //Profilim Güncelleme
        [HttpGet]
        public ActionResult WriterProfile(int id=4)
        {
            string p = (string)Session["WriterMail"];//Yazarın Mailini Sessiona Atadık.
            id = c.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterId).FirstOrDefault();
            //Sessiondaki WriterMail ile Veritabanındaki WriterMail birbirine eşit olanların ID'sinin ilk değeerini al.
            var values =wm.GetById(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer p, HttpPostedFileBase WriterImage)
        {
            WriterValidator writer = new WriterValidator();
            ValidationResult result = writer.Validate(p);
            if (result.IsValid)
            {
                if (WriterImage != null && WriterImage.ContentLength > 0)
                {
                    // Dosya yolunu belirle ve dosyayı kaydet
                    string path = Path.Combine(Server.MapPath("~/Images/"), Path.GetFileName(WriterImage.FileName));
                    WriterImage.SaveAs(path);
                    p.WriterImage = "/Images/" + WriterImage.FileName; // Veritabanına kaydedilecek yol
                }

                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(p);
        }

        //[HttpPost]
        //public ActionResult WriterProfile(Writer p)
        //{
        //    WriterValidator writer = new WriterValidator();
        //    ValidationResult result = writer.Validate(p);
        //    if (result.IsValid)
        //    {
        //        wm.WriterUpdate(p);
        //        return RedirectToAction("AllHeading");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors)
        //        {
        //            ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
        //        }
        //    }
        //    return View();
        //}

        //Tüm Başlıkları Listeleme
        public ActionResult AllHeading(int p=1)
        {

            var values = hm.GetList().ToPagedList(p,4);//Sayfa 1 den başlayacak 4 erli sıralanacak.
            return View(values);
        }

        //Yazara Ait Başlıklar Başlıklarım
        public ActionResult MyHeading(string p)
        {




            p = (string)Session["WriterMail"];//Yazarın Mailini Sessiona Atadık.
            var WriterId = c.Writers.Where(x => x.WriterMail == p).Select(x => x.WriterId).FirstOrDefault();
            //Sessiondaki WriterMail ile Veritabanındaki WriterMail birbirine eşit olanların ID'sinin ilk değeerini al.
            var values = hm.GetByWriterList(WriterId);//GetByWriterList(Yazarın Id Alan Methot)
            return View(values);
        }

        //Yeni Başlık Ekleme
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
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {

            string values = (string)Session["WriterMail"];//Yazarın Mailini Sessiona Atadık.
            var WriterId = c.Writers.Where(x => x.WriterMail == values).Select(x => x.WriterId).FirstOrDefault();
            //Sessiondaki WriterMail ile Veritabanındaki WriterMail birbirine eşit olanların ID'sinin ilk değeerini al.
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());//Bugunun tarihini vercek
            p.WriterId = WriterId;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }



        //Başlık Güncelleme
        [HttpGet]
        public ActionResult UpdateHeading(int id)
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

            var HeadingValue = hm.GetById(id);
            return View(HeadingValue);
        }
        [HttpPost]
        public ActionResult UpdateHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }


        //Başlık Pasif-Aktif İşlemi
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
            return RedirectToAction("MyHeading");
        }



    }
}
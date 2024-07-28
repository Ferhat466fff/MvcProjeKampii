using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
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
    public class AdminWriterController : Controller
    {
        WriterManager wr = new WriterManager(new EFWriterDal());


        //Yazar Listeleme
        public ActionResult Index()
        {
            var values = wr.GetList();
            return View(values);
        }

        //Yazar EKLENMESİ

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            WriterValidator writer = new WriterValidator();//burayı buisnes-validationrules içerisinde açtık.
            ValidationResult result = writer.Validate(p);//yazaragöre hata mesajlarını verecek.ValidationResult(fluent olanını seçmen gerek ctrl . yapınca)
            if (result.IsValid)
            {
                wr.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);//propert-->veritabanındaki stun adları kategoriname,categorydescription..
                }
            }
            return View();
        }

        //Kategori Güncelleme
        [HttpGet]
        public ActionResult UpdateWriter(int id)
        {
            var values = wr.GetById(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateWriter(Writer p)
        {
            WriterValidator writer = new WriterValidator();
            ValidationResult result = writer.Validate(p);
            if(result.IsValid)
            {
                wr.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }











    }
}
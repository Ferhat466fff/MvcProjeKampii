using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{

    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        Context c = new Context();


        //Başlığın Id göre içeriğini(Yazarın yazılarını getirme) getirme
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];//Yazarın Mailini Sessiona Atadık.
            var WriterId = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterId).FirstOrDefault();
            //Sessiondaki WriterMail ile Veritabanındaki WriterMail birbirine eşit olanların ID'sinin ilk değeerini al.
            var values = cm.GetListByWriter(WriterId);//GetByWriterList(Yazarın Id Alan Methot)
            return View(values);
        }

        //Yeni İçerik Ekleme
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d=id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["WriterMail"];//Yazarın Mailini Sessiona Atadık.
            var WriterId = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterId).FirstOrDefault();
            //Sessiondaki WriterMail ile Veritabanındaki WriterMail birbirine eşit olanların ID'sinin ilk değeerini al.
            p.ContentDate=DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterId=WriterId;
            p.ContentStatus=true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }


        //
        public ActionResult ToDoList()
        {
            return View();
        }


    }
}
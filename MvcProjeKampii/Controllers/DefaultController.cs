using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    [AllowAnonymous]//-->Bu Sayade herkes braya erieşebilecek.
    public class DefaultController : Controller
    {
        HeadingManager hm = new HeadingManager(new EFHeadingDal());
        ContentManager cm = new ContentManager(new EFContentDal());
        public ActionResult Headings()//-->Burası Layout(TümBaşlıklaarı Listeledik)
        {
            var values = hm.GetList();
            return View(values);
        }

        public PartialViewResult Index(int id=0)
        {
            var values =cm.GetListByHeadingId(id);
            return PartialView(values);
        }
    }
}
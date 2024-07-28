using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class AdminContentController : Controller
    {
        ContentManager cm = new ContentManager(new EFContentDal());
        
        public ActionResult Index()
        {
            return View();
        }

        //Başlığın Id göre içeriğini getirme
        public ActionResult ContentByHeadingg(int id)
        {
            var contentvalues = cm.GetListByHeadingId(id);
            return View(contentvalues);
        }
    }
}
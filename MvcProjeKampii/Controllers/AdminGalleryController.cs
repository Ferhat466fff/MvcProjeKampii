using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampii.Controllers
{
    public class AdminGalleryController : Controller
    {
        ImageFileManager im = new ImageFileManager(new EFImageFileDal());

        public ActionResult Index()
        {
            var values = im.GetList();
            return View(values);
        }
    }
}
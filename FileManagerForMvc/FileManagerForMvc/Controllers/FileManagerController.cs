using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileManagerForMvc.ViewModel;

namespace FileManagerForMvc.Controllers
{
    public class FileManagerController : Controller
    {
        //
        // GET: /FileManager/
        private const string PathUploadFile = "/FileUploder/";

        public ActionResult Index()
        {
            List<ImageGalleryvm> p;
            if (GetFiles(out p)) return null;

            if (Request.IsAjaxRequest())
            {
                return PartialView(p);
            }
            return View(p);
        }

        public ActionResult ProvideData()
        {
            List<ImageGalleryvm> p;
            if (GetFiles(out p)) return null;
            if (Request.IsAjaxRequest())
            {
                return PartialView(p);
            }
            return View(p);
            //return Json(p, JsonRequestBehavior.AllowGet);

            //return View(p);
        }

        private bool GetFiles(out List<ImageGalleryvm> p)
        {
            p = null;
            var dir = Server.MapPath(PathUploadFile);
            if (!Directory.Exists(dir))
            {
                return true;
            }
            //http://stackoverflow.com/questions/7487007/how-can-i-enumerate-through-a-folder-to-get-all-file-names-in-an-asp-net-mvc-web
            //http://stackoverflow.com/questions/163162/can-you-call-directory-getfiles-with-multiple-filters
            var files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                .Where(s => s.EndsWith(".png") || s.EndsWith(".jpg"));

            p = files.Select(file => new ImageGalleryvm
            {
                Url = PathUploadFile + Path.GetFileName(file),
                Thumb = PathUploadFile + Path.GetFileName(file)
            }).ToList();
            return false;
        }

        [HttpPost]
        public ActionResult DeleteFile(List<string> models)
        {
            //var r = models.Split(',');
            try
            {
                //string fullPath = Request.MapPath(PathUploadFile);
                //var files = Directory.GetFiles(fullPath, "*.jpg", SearchOption.AllDirectories);

                //foreach (var item in files)
                //{
                //    System.IO.File.Delete(item);
                //}

                foreach (var item in models)
                {
                    System.IO.File.Delete(item);
                }

                return Json(new { status = true, message = "عملیات با موفقیت انجام شد" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new { status = false, message = "عملیات با خطا مواجه شد" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    public class UploadController : Controller
    {
        [HttpGet]
        public ActionResult SaveImages()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveImages(HttpPostedFileBase UploadedImage)
        {
            if (UploadedImage.ContentLength > 0)
            {
                string ImageFileName = Path.GetFileName(UploadedImage.FileName);
                string FolderPath = Path.Combine(Server.MapPath("~/UploadedImages"), ImageFileName);
                UploadedImage.SaveAs(FolderPath);

            }
            ViewBag.Message = "Image File Uploaded Successfully";
            return View();
        }

    }
}

using demo.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace demo.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Home
        PdfUploadDBEntities db = new PdfUploadDBEntities();
        [HttpGet]
        public ActionResult Upload(string ey)
        {
            string[] dizi;
            if (ey!=null)
            {
                dizi = ey.Split(',');
            }
           
            ViewBag.table = db.DuyuruFileUrls.OrderByDescending(x => x.CreateDate).ToList();
            return View();

        }

            public string SaveToPhysicalLocation(HttpPostedFileBase file)
        {
            
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data"), fileName);
               
                file.SaveAs(path);
                return path;
            }
              return string.Empty;
          

        }


        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file,deneme deneme)
        {
       
            using (PdfUploadDBEntities entity = new PdfUploadDBEntities())
                {
             
                var duyuruFileUrl = new DuyuruFileUrl()
                {
                    Url = "http://intranet.halkyatirim.com.tr/belgeler/" + Path.GetFileName(file.FileName),
                    UserID = 8257,
                    FileName = Path.GetFileName(file.FileName),
                    CreateDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")),
                    UserName = "Admin",
                    Title = deneme.Title,
                    File = SaveToPhysicalLocation(deneme.File),
                    

            };
                    entity.DuyuruFileUrls.Add(duyuruFileUrl);
                    entity.SaveChanges();
                 
                }
            ViewBag.table = db.DuyuruFileUrls.OrderByDescending(x => x.CreateDate).ToList();
            return View(deneme);
            
           
        }


        /// <summary>
        ///  Save Posted File in Physical path and return saved path to store in a database
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>


    }
}

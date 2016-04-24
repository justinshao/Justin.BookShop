using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Justin.BookShop.FileServer.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult UploadBookImage()
        {
            HttpPostedFileBase picture = Request.Files[0];
            string dir = Request.MapPath("~/Content/images/book/");
            string ext = System.IO.Path.GetExtension(picture.FileName);
            string name = Guid.NewGuid().ToString() + DateTime.Now.ToString("_yyyyMMdd-hhmmss") + ext;
            string path = string.Format(@"{0}{1}", dir, name);
            picture.SaveAs(path);

            //return Content("http://" + Request.Url.Host + ":" + Request.Url.Port + "/Content/images/book/" + name);
            return Content(name);
        }
    }
}

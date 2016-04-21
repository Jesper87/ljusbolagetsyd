using System.Web.Mvc;
using Ljusbolagetsyd.Data;
using Ljusbolagetsyd.Data.Services;
using Ljusbolagetsyd.Models;

namespace Ljusbolagetsyd.Controllers
{
   public class HomeController : Controller
   {
      public ActionResult Index()
      {
         return View();
      }

      public ActionResult About()
      {
         return View();
      }

      public ActionResult Contact()
      {
         return View("Contact", new ContactFormViewModel());
      }

      public ActionResult Gallery()
      {

         var path3 = Server.MapPath("~/Content/Images/Gallery");

         var service = new ImageService();
         var images = service.GetImagesFromContentFolder(path3);
         foreach (var galleryImage in images)
         {
            var str = galleryImage.ImageUrl.Split('\\');
            var last = str[str.Length - 1];
            galleryImage.ImageUrl = "/Content/Images/Gallery/" + last;
         }
         return View(images);
      }

      public ActionResult Equipment()
      {
         return View();
      }

      public ActionResult Services()
      {
         return View();
      }

      [ValidateAntiForgeryToken]
      [HttpPost]
      public ActionResult ContactForm(ContactFormViewModel model)
      {
         if (ModelState.IsValid)
         {
            var isSent = EmailService.SendNewEmail(model);
            ModelState.Clear();
            return View("Contact", new ContactFormViewModel { Succes = isSent });

         }
         return View("Contact");
      }

   }
}
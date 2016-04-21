using System.Web.Mvc;
using Ljusbolagetsyd.Data;
using Ljusbolagetsyd.Data.Services;
using Ljusbolagetsyd.Models;

namespace Ljusbolagetsyd.Controllers
{
   public class HomeController : Controller
   {
      private readonly ImageService _imageService = new ImageService();
      private const string GalleryFolderPath = "~/Content/Images/Gallery";

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
         var galleryFolderPath = Server.MapPath(GalleryFolderPath);
         var images = _imageService.GetImagesFromGalleryFolder(galleryFolderPath);
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
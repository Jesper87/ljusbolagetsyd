using System.Web.Mvc;
using Ljusbolagetsyd.Data;

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
         return View();
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
   }
}
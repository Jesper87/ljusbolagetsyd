using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Ljusbolagetsyd.Data.Dto;

namespace Ljusbolagetsyd.Data
{
   public class ImageService
   {
      public List<GalleryImage> GetImagesFromGalleryFolder(string galleryFolderPath)
      {
         var images = new List<GalleryImage>();

         if (Directory.Exists(galleryFolderPath))
         {
            try
            {
               var fileEntries = Directory.GetFiles(galleryFolderPath);
               images.AddRange(fileEntries.Select(fileEntry => new GalleryImage { ImageUrl = fileEntry }));
            }
            catch (Exception)
            {
               return images;
            }
         }

         SetImageUrl(images);
         return images;
      }

      private static void SetImageUrl(IEnumerable<GalleryImage> images)
      {
         foreach (var galleryImage in images)
         {
            var str = galleryImage.ImageUrl.Split('\\');
            var last = str[str.Length - 1];
            galleryImage.ImageUrl = "/Content/Images/Gallery/" + last;
         }
      }
   }
}
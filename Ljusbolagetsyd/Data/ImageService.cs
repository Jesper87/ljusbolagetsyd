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
    public List<GalleryImage> GetImagesFromContentFolder(string path)
    {
      
      var images = new List<GalleryImage>();

      if(Directory.Exists(path))
      {
      var fileEntries = Directory.GetFiles(path);
        foreach (var fileEntry in fileEntries)
        {
          var image = new GalleryImage();
          image.ImageUrl = fileEntry;
          images.Add(image);
        }
      }
      return images;
    }
  }
}
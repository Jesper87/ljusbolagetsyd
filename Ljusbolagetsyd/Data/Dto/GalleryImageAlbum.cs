using System.Collections.Generic;

namespace Ljusbolagetsyd.Data.Dto
{
	public class GalleryImageAlbum
	{
		public string AlbumName { get; set; }
		public List<GalleryImage> Images { get; set; }
	}
}
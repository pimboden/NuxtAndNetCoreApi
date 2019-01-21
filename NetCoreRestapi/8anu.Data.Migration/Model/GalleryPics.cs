using System;

namespace _8anu.Data.Migration.Model
{
    public partial class GalleryPics
    {
        public int GalleryId { get; set; }
        public string GalleryPic { get; set; }
        public string GalleryPicResz { get; set; }
        public string GalleryPicThmn { get; set; }
        public string GalleryPicDesc { get; set; }
        public DateTime GalleryDate { get; set; }
        public int GalleryPathId { get; set; }
        public int GalleryCatyId { get; set; }
        public int UserId { get; set; }
        public string GalleryPicConvertedName { get; set; }
        public string GalleryPicPhotografer { get; set; }
        public int GalleryPicHeight { get; set; }
        public int GalleryPicWidth { get; set; }
        public uint GalleryPicSelected { get; set; }
        public DateTime GalleryPicSelectedDate { get; set; }
        public int CragId { get; set; }
    }
}

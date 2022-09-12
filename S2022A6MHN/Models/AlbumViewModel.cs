using S2022A6MHN.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A6MHN.Models
{
    public class AlbumAddFormViewModel
    {
        public AlbumAddFormViewModel()
        {
            ReleaseDate = DateTime.Now;
        }

        [Required, StringLength(100)]
        [Display(Name = "Album name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Album's primary genre")]
        public int GenreId { get; set; }

        public SelectList GenreList { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(500)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "URL to album image (cover art)")]
        public string UrlAlbum { get; set; }

        public string ArtistName { get; set; }

        public int ArtistId { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Album background")]
        public string Background { get; set; }
    }

    public class AlbumAddViewModel
    {
        public AlbumAddViewModel()
        {
            ReleaseDate = DateTime.Now;
        }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Range(1, Int32.MaxValue)]
        public int GenreId { get; set; }

        public int ArtistId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(500)]
        [DataType(DataType.ImageUrl)]
        public string UrlAlbum { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Album background")]
        public string Background { get; set; }
    }

    public class AlbumBaseViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        [Display(Name = "Album name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        [Required, StringLength(500)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Album cover art")]
        public string UrlAlbum { get; set; }

        [Required]
        [Display(Name = "Album's primary genre")]
        public string Genre { get; set; }
    }

    public class AlbumWithDetailViewModel : AlbumBaseViewModel
    {
        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Album background")]
        public string Background{ get; set; }
    }
}
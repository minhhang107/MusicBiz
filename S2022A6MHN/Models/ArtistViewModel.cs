using S2022A6MHN.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A6MHN.Models
{
    public class ArtistAddFormViewModel
    {
        public ArtistAddFormViewModel()
        {
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }

        [Required, StringLength(200)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }

        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth date, or start date")]
        public DateTime BirthOrStartDate { get; set; }

        [Required, StringLength(500)]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "URL to artist photo")]
        public string UrlArtist { get; set; }

        [Required]
        [Display(Name = "Artist's primary genre")]
        public int GenreId { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Artist Portrayal")]
        public string Portrayal { get; set; }

        public SelectList GenreList { get; set; }
    }

    public class ArtistAddViewModel
    {
        public ArtistAddViewModel()
        {
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }

        [Required, StringLength(200)]
        public string Name { get; set; }

        public string BirthName { get; set; }

        [Required]
        public DateTime BirthOrStartDate { get; set; }

        [Required, StringLength(500)]
        public string UrlArtist { get; set; }

        [Required]
        public int GenreId { get; set; }

        [StringLength(10000)]
        [DataType(DataType.MultilineText)]
        public string Portrayal { get; set; }
    }

    public class ArtistBaseViewModel
    {
        public ArtistBaseViewModel()
        {
            BirthOrStartDate = DateTime.Now.AddYears(-20);
        }

        [Key]
        public int Id { get; set; }

        [Required, StringLength(500)]
        [Display(Name = "Artist photo")]
        public string UrlArtist { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Artist name or stage name")]
        public string Name { get; set; }

        [Display(Name = "If applicable, artist's birth name")]
        public string BirthName { get; set; }

        [Required]
        [Display(Name = "Birth date, or start date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime BirthOrStartDate { get; set; }

        [Display(Name = "Artist's primary genre")]
        public string Genre { get; set; }
    }

    public class ArtistWithDetailViewModel : ArtistBaseViewModel
    {
        [StringLength(10000)]
        public string Portrayal { get; set; }
    }

    public class ArtistWithMediaInfoViewModel : ArtistWithDetailViewModel
    {
        public ArtistWithMediaInfoViewModel()
        {
            MediaItems = new List<MediaItem>();
        }

        public IEnumerable<MediaItem> MediaItems
        { get; set; }
    }
}
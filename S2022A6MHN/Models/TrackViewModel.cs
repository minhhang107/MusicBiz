using S2022A6MHN.EntityModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A6MHN.Models
{
    public class TrackAddFormViewModel
    {
        [Required]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [Display(Name = "Composer names (comma-separated")]
        public string Composers { get; set; }

        [Display(Name = "Track genre")]
        public int GenreId { get; set; }

        public SelectList GenreList { get; set; }

        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }

        public string AlbumName { get; set; }

        [Required]
        [Display(Name = "Sample clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }

    public class TrackAddViewModel
    {
        [Required]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [Display(Name = "Composer names (comma-separated)")]
        public string Composers { get; set; }

        [Range(1, Int32.MaxValue)]
        public int GenreId { get; set; }

        [Range(1, Int32.MaxValue)]
        public int AlbumId { get; set; }

        [Required]
        public HttpPostedFileBase AudioUpload { get; set; }
    }

    public class TrackBaseViewModel
    {
        public TrackBaseViewModel()
        {
            Albums = new List<Album>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Track name")]
        public string Name { get; set; }

        [Display(Name = "Composer names")]
        public string Composers { get; set; }

        [Display(Name = "Track genre")]
        public string Genre { get; set; }

        public IEnumerable<Album> Albums { get; set; }
    }

    public class TrackWithDetailViewModel : TrackBaseViewModel
    {
        [Display(Name = "Sample clip")]
        public string AudioUrl
        {
            get
            {
                return $"/clip/{Id}";
            }
        }
    }

    public class TrackEditFormViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Required]
        [Display(Name = "Clip")]
        [DataType(DataType.Upload)]
        public string AudioUpload { get; set; }
    }

    public class TrackEditViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public HttpPostedFileBase AudioUpload { get; set; }
    }

    public class TrackAudioViewModel
    {
        public int Id { get; set; }

        public string AudioContentType { get; set; }
        public byte[] Audio { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2022A6MHN.Models
{
    public class MediaItemAddFormViewModel{
        public int ArtistId { get; set; }

        public string ArtistName { get; set; }

        [StringLength(500)]
        [Display(Name = "Description")]
        public string Caption { get; set; }

        [Required]
        [Display(Name = "Media item")]
        [DataType(DataType.Upload)]
        public string MediaUpload { get; set; }
    }

    public class MediaItemAddViewModel
    {
        public int ArtistId { get; set; }

        [StringLength(500)]
        [Display(Name = "Description")]
        public string Caption { get; set; }

        [Required]
        public HttpPostedFileBase MediaUpload { get; set; }
    }

    public class MediaItemBaseViewModel
    {
        [Key]
        public int Id { get; set; }

        [StringLength(500)]
        public string Caption { get; set; }
        public byte[] Content { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }
        public string StringId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class MediaItemContentViewModel
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }
    }
}
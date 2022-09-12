using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace S2022A6MHN.EntityModels
{
    public class MediaItem
    {
        public MediaItem()
        {
            Timestamp = DateTime.Now;

            // StringId generator
            // Code is from Mads Kristensen
            // http://madskristensen.net/post/generate-unique-strings-and-numbers-in-c

            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            StringId = string.Format("{0:x}", i - DateTime.Now.Ticks);
        }

        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Caption { get; set; }

        public byte[] Content { get; set; }

        [StringLength(200)]
        public string ContentType { get; set; }

        [Required, StringLength(100)]
        public string StringId { get; set; }

        public DateTime Timestamp { get; set; }

        [Required]
        public Artist Artist { get; set; }
    }
}
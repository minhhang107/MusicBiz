using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A6MHN.Controllers
{
    public class MediaItemsController : Controller
    {
        private Manager m = new Manager();
        // GET: MediaItem
        public ActionResult Index()
        {
            return View("Index", "Home");
        }

        // GET: Photo/5
        // TODO 12 - Dedicated photo delivery method, uses attribute routing
        [Route("media/{stringId}")]
        public ActionResult Details(string stringId = "")
        {
            // Attempt to get the matching object
            var mediaItem = m.ArtistMediaItemGetById(stringId);

            if (mediaItem == null)
                return HttpNotFound();

            return File(mediaItem.Content, mediaItem.ContentType);
        }

        // GET: Photo/5/Download
        // TODO 13 - Dedicated photo DOWNLOAD method, uses attribute routing
        [Route("media/{stringId}/download")]
        public ActionResult DetailsDownload(string stringId = "")
        {
            // Attempt to get the matching object
            var mediaItem = m.ArtistMediaItemGetById(stringId);

            if (mediaItem == null)
                return HttpNotFound();

            // Get file extension, assumes the web server is Microsoft IIS based
            // Must get the extension from the Registry (which is a key-value storage structure for configuration settings, for the Windows operating system and apps that opt to use the Registry)

            // Working variables
            string extension;
            RegistryKey key;
            object value;

            // Open the Registry, attempt to locate the key
            key = Registry.ClassesRoot.OpenSubKey(@"MIME\Database\Content Type\" + mediaItem.ContentType, false);
            // Attempt to read the value of the key
            value = (key == null) ? null : key.GetValue("Extension", null);
            // Build/create the file extension string
            extension = (value == null) ? string.Empty : value.ToString();

            // Create a new Content-Disposition header
            var cd = new System.Net.Mime.ContentDisposition
            {
                // Assemble the file name + extension
                FileName = $"{stringId}{extension}",
                // Force the media item to be saved (not viewed)
                Inline = false
            };
            // Add the header to the response
            Response.AppendHeader("Content-Disposition", cd.ToString());

            return File(mediaItem.Content, mediaItem.ContentType);
        }
    }
}

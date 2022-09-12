using S2022A6MHN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A6MHN.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        private Manager m = new Manager();
        // GET: Artists
        public ActionResult Index()
        {
            return View(m.ArtistGetAll());
        }

        // GET: Artists/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.ArtistGetById(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();

            return View(obj);
        }

        // GET: Artists/Create
        [Authorize(Roles = "Executive")]
        public ActionResult Create()
        {
            var form = new ArtistAddFormViewModel();
            form.GenreList = new SelectList(
                items: m.GenreGetAll(),
                dataValueField: "Id",
                dataTextField: "Name");
            return View(form);
        }

        // POST: Artists/Create
        [HttpPost, ValidateInput(false)]
        [Authorize(Roles = "Executive")]
        public ActionResult Create(ArtistAddViewModel newArtist)
        {
            if (!ModelState.IsValid)
            {
                return View(newArtist);
            }

            var addedArtist = m.ArtistAdd(newArtist);
            if (addedArtist == null)
                return View(newArtist);

            return RedirectToAction("Details", new { id = addedArtist.Id });
        }

        // GET: Artists/5/AddAlbum
        [Authorize(Roles = "Coordinator"), Route("Artists/{id}/AddAlbum")]
        public ActionResult AddAlbum(int? id)
        {
            var artist = m.ArtistGetById(id.GetValueOrDefault());
            if (artist == null)
                return HttpNotFound();

            var form = new AlbumAddFormViewModel();

            form.ArtistName = artist.Name;
            form.ArtistId = artist.Id;
            form.GenreList = new SelectList(
                items: m.GenreGetAll(),
                dataTextField: "Name",
                dataValueField: "Id");

            return View(form);
        }

        // POST: Artists/5/AddAlbum
        [HttpPost, ValidateInput(false)]
        [Authorize(Roles = "Coordinator"), Route("Artists/{id}/AddAlbum")]
        public ActionResult AddAlbum(AlbumAddViewModel newAlbum)
        {
            if (!ModelState.IsValid)
                return View(newAlbum);

            var addedAlbum = m.AlbumAdd(newAlbum);
            if (addedAlbum == null)
                return View(newAlbum);
            return RedirectToAction("Details", "Albums", new { id = addedAlbum.Id });
        }

        // GET: Artists/5/AddAlbum
        [Authorize(Roles = "Executive"), Route("Artists/{id}/AddMediaItem")]
        public ActionResult AddMedia(int? id)
        {
            var artist = m.ArtistGetById(id.GetValueOrDefault());
            if (artist == null)
                return HttpNotFound();

            var form = new MediaItemAddFormViewModel();
            form.ArtistId = artist.Id;
            form.ArtistName = artist.Name;

            return View(form);
        }

        // POST: Artists/5/AddAlbum
        [HttpPost, ValidateInput(false)]
        [Authorize(Roles = "Executive"), Route("Artists/{id}/AddMediaItem")]
        public ActionResult AddMediaItem(MediaItemAddViewModel newItem)
        {
            if (!ModelState.IsValid)
                return View(newItem);

            var addedItem = m.MediaItemAdd(newItem);
            if (addedItem== null)
                return View(newItem);
            return RedirectToAction("Details", "Artists", new { id = newItem.ArtistId });
        }
    }
}

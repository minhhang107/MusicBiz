using S2022A6MHN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A6MHN.Controllers
{
    [Authorize]
    public class AlbumsController : Controller
    {
        private Manager m = new Manager();
        // GET: Albums
        public ActionResult Index()
        {
            return View(m.AlbumGetAll());
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.AlbumGetById(id.GetValueOrDefault());

            if (obj == null)
                return HttpNotFound();

            return View(obj);
        }

        // GET: Albums/5/AddTrack
        [Authorize(Roles = "Clerk"), Route("Albums/{id}/AddTrack")]
        public ActionResult AddTrack(int? id)
        {
            var album = m.AlbumGetById(id.GetValueOrDefault());
            if (album == null)
                return HttpNotFound();

            var form = new TrackAddFormViewModel();
            form.AlbumName = album.Name;
            form.AlbumId = album.Id;
            form.GenreList = new SelectList(
                items: m.GenreGetAll(),
                dataTextField: "Name",
                dataValueField: "Id");

            return View(form);
        }

        // POST: Albums/5/AddTrack
        [HttpPost]
        [Authorize(Roles = "Clerk"), Route("Albums/{id}/AddTrack")]
        public ActionResult AddTrack(TrackAddViewModel newTrack)
        {
            if (!ModelState.IsValid)
                return View(newTrack);

            var addedTrack = m.TrackAdd(newTrack);
            if (addedTrack == null)
                return View(newTrack);

            return RedirectToAction("Details", "Tracks", new { id = addedTrack.Id });
        }
    }
}

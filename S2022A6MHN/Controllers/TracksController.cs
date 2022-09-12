using S2022A6MHN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace S2022A6MHN.Controllers
{
    //[Authorize]
    public class TracksController : Controller
    {
        private Manager m = new Manager();
        // GET: Tracks
        public ActionResult Index()
        {
            return View(m.TrackGetAll());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            var obj = m.TrackGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();
            return View(obj);
        }

        // GET: Clip/5
        [Route("Clip/{id}")]
        public ActionResult Clip(int? id)
        {
            var obj = m.TrackAudioGetById(id.GetValueOrDefault());
            if (obj == null)
                return HttpNotFound();

            if (obj.AudioContentType == null)
                return Content("Audio not available");
            return File(obj.Audio, obj.AudioContentType);
        }

        // GET: Tracks/Edit/5
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id)
        {
            var track = m.TrackGetById(id.GetValueOrDefault());
            if (track == null)
                return HttpNotFound();

            var obj = m.mapper.Map<TrackWithDetailViewModel, TrackEditFormViewModel>(track);
            return View(obj);
        }

        // POST: Tracks/Edit/5
        [HttpPost]
        [Authorize(Roles = "Clerk")]
        public ActionResult Edit(int? id, TrackEditViewModel trackToEdit)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Edit", new { id = trackToEdit.Id });

            if (id.GetValueOrDefault() != trackToEdit.Id)
                return RedirectToAction("Index");

            var edittedItem = m.TrackEdit(trackToEdit);

            if (edittedItem == null)
                return RedirectToAction("Edit", new { id = trackToEdit.Id });

            return RedirectToAction("Details", new { id = trackToEdit.Id });
        }
        
       // GET: Tracks/Delete/5
       [Authorize(Roles = "Clerk")]
        public ActionResult Delete(int? id)
        {
            var track = m.TrackGetById(id.GetValueOrDefault());
            if (track == null)
                return RedirectToAction("Index");
            return View(track);
        }

        // POST: Tracks/Delete/5
        [Authorize(Roles = "Clerk")]
        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            try
            {
                var result = m.TrackDelete(id.GetValueOrDefault());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

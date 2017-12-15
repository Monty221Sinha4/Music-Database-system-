using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicWorld.com;

namespace MusicWorld.com.Controllers.Admin
{
    public class TrackListsController : Controller
    {
        private MusicLibaryDB db = new MusicLibaryDB();

        // GET: TrackLists
        public ActionResult Index()
        {
            var trackLists = db.TrackLists.Include(t => t.Album).Include(t => t.Artist).Include(t => t.Genre);
            return View(trackLists.ToList());
        }

        // GET: TrackLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackList trackList = db.TrackLists.Find(id);
            if (trackList == null)
            {
                return HttpNotFound();
            }
            return View(trackList);
        }

        // GET: TrackLists/Create
        public ActionResult Create()
        {
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Name");
            ViewBag.ArtistID = new SelectList(db.Artists1, "ArtistID", "Artist");
            ViewBag.GenreID = new SelectList(db.Genres1, "GenreID", "Genre");
            return View();
        }

        // POST: TrackLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AlbumID,ArtistID,Track,GenreID")] TrackList trackList)
        {
            if (ModelState.IsValid)
            {
                db.TrackLists.Add(trackList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Name", trackList.AlbumID);
            ViewBag.ArtistID = new SelectList(db.Artists1, "ArtistID", "Artist", trackList.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres1, "GenreID", "Genre", trackList.GenreID);
            return View(trackList);
        }

        // GET: TrackLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackList trackList = db.TrackLists.Find(id);
            if (trackList == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Name", trackList.AlbumID);
            ViewBag.ArtistID = new SelectList(db.Artists1, "ArtistID", "Artist", trackList.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres1, "GenreID", "Genre", trackList.GenreID);
            return View(trackList);
        }

        // POST: TrackLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AlbumID,ArtistID,Track,GenreID")] TrackList trackList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumID = new SelectList(db.Albums, "ID", "Name", trackList.AlbumID);
            ViewBag.ArtistID = new SelectList(db.Artists1, "ArtistID", "Artist", trackList.ArtistID);
            ViewBag.GenreID = new SelectList(db.Genres1, "GenreID", "Genre", trackList.GenreID);
            return View(trackList);
        }

        // GET: TrackLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackList trackList = db.TrackLists.Find(id);
            if (trackList == null)
            {
                return HttpNotFound();
            }
            return View(trackList);
        }

        // POST: TrackLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrackList trackList = db.TrackLists.Find(id);
            db.TrackLists.Remove(trackList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace CdOrganizer.Controllers
{
  public class ArtistsController : Controller
  {
    private readonly CdOrganizerContext _db;
    public ArtistsController(CdOrganizerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Artist> model = _db.Artists.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Artist artist)
    {
      _db.Artists.Add(artist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisArtist = _db.Artists
      .Include(thisArtist => thisArtist.JoinEntities)
      .ThenInclude(join => join.Genre)
      .FirstOrDefault(thisArtist => thisArtist.ArtistId == id);
      return View(thisArtist);
    }

    public ActionResult Edit(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(Artist => Artist.ArtistId == id);
      return View(thisArtist);
    }

    [HttpPost]
    public ActionResult Edit(Artist artist)
    {
      _db.Entry(artist).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      return View(thisArtist);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisArtist = _db.Artists.FirstOrDefault(artist => artist.ArtistId == id);
      _db.Artists.Remove(thisArtist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
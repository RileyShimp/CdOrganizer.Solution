using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using CdOrganizer.Models;
using System.Collections.Generic;
using System.Linq;

namespace CdOrganizer.Controllers
{
  public class GenresController : Controller
  {
    private readonly CdOrganizerContext _db;

    public GenresController(CdOrganizerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Genre> model = _db.Genres.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.ArtistId = new SelectList(_db.Artists, "ArtistId", "Description");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Genre genre, int ArtistId)
    {
      _db.Genres.Add(genre);
      _db.SaveChanges();
      if (ArtistId != 0)
      {
        _db.GenreArtist.Add(new GenreArtist() { ArtistId = ArtistId, GenreId = genre.GenreId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      var thisGenre = _db.Genres
      .Include(thisGenre => thisGenre.JoinEntities)
      .ThenInclude(join => join.Artist)
      .FirstOrDefault(thisGenre => thisGenre.GenreId == id);
      System.Console.WriteLine(thisGenre);
      return View(thisGenre);
    }
  }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("[controller]")]
 
    public class SpotifyController : Controller
    {   
        private readonly SpotifyContext _context;
        public SpotifyController(SpotifyContext context) { _context = context; }
        [HttpGet("Song/Title")]
        public async Task<IActionResult> GetSongByTitle(string Title)
        {
            if (Title == null)
            {
                return NotFound();
            }

            var song = await _context.Songs
                .FirstOrDefaultAsync(m => m.Title == Title);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);

        }
        [HttpGet("Artist/Name")]
        public async Task<IActionResult> GetArtistByName(string Nome)
        {
            if (Nome == null)
            {
                return NotFound();
            }

            var artist = await _context.Artists
                .FirstOrDefaultAsync(m => m.NomeDArte == Nome);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);

        }
        [HttpGet("Album/Title")]
        public async Task<IActionResult> GetAlbumByTitle(string Titolo)
        {
            if (Titolo == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .FirstOrDefaultAsync(m => m.Titolo == Titolo);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);

        }
        [HttpGet("Song/Artist")]
        public async Task<IActionResult> GetSongByArtist(string Nome)
        {
            if (Nome == null)
            {
                return NotFound();
            }

            var artist = await _context.Songs
                .FirstOrDefaultAsync(m => m.Artist == Nome);
            if (artist == null)
            {
                return NotFound();
            }

            return View(artist);

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Album,Artist")]Playlist playlist)
        {
            if (ModelState.IsValid)
            {
                _context.Add(playlist);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
            }return View(playlist);
        } 
    }
}

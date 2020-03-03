using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibrairieDB;
using TPLibrairiev03;

namespace TP_Web.Views
{
    public class PositionMagasinsController : Controller
    {
        private readonly LibrairieDbContext _context;

        public PositionMagasinsController(LibrairieDbContext context)
        {
            _context = context;
        }

        // GET: PositionMagasins
        public async Task<IActionResult> Index()
        {
            var librairieDbContext = _context.PositionMagasins.Include(p => p.Article).Include(p => p.Etagere);
            return View(await librairieDbContext.ToListAsync());
        }

        // GET: PositionMagasins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionMagasin = await _context.PositionMagasins
                .Include(p => p.Article)
                .Include(p => p.Etagere)
                .FirstOrDefaultAsync(m => m.IdArticle == id);
            if (positionMagasin == null)
            {
                return NotFound();
            }

            return View(positionMagasin);
        }

        // GET: PositionMagasins/Create
        public IActionResult Create()
        {
            ViewData["IdArticle"] = new SelectList(_context.Articles, "Id", "Libelle");
            ViewData["IdEtagere"] = new SelectList(_context.Etageres, "Id", "Id");
            return View();
        }

        // POST: PositionMagasins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdArticle,IdEtagere,Quantite")] PositionMagasin positionMagasin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(positionMagasin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArticle"] = new SelectList(_context.Articles, "Id", "Libelle", positionMagasin.IdArticle);
            ViewData["IdEtagere"] = new SelectList(_context.Etageres, "Id", "Id", positionMagasin.IdEtagere);
            return View(positionMagasin);
        }

        // GET: PositionMagasins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionMagasin = await _context.PositionMagasins.FindAsync(id);
            if (positionMagasin == null)
            {
                return NotFound();
            }
            ViewData["IdArticle"] = new SelectList(_context.Articles, "Id", "Libelle", positionMagasin.IdArticle);
            ViewData["IdEtagere"] = new SelectList(_context.Etageres, "Id", "Id", positionMagasin.IdEtagere);
            return View(positionMagasin);
        }

        // POST: PositionMagasins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdArticle,IdEtagere,Quantite")] PositionMagasin positionMagasin)
        {
            if (id != positionMagasin.IdArticle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(positionMagasin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PositionMagasinExists(positionMagasin.IdArticle))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdArticle"] = new SelectList(_context.Articles, "Id", "Libelle", positionMagasin.IdArticle);
            ViewData["IdEtagere"] = new SelectList(_context.Etageres, "Id", "Id", positionMagasin.IdEtagere);
            return View(positionMagasin);
        }

        // GET: PositionMagasins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var positionMagasin = await _context.PositionMagasins
                .Include(p => p.Article)
                .Include(p => p.Etagere)
                .FirstOrDefaultAsync(m => m.IdArticle == id);
            if (positionMagasin == null)
            {
                return NotFound();
            }

            return View(positionMagasin);
        }

        // POST: PositionMagasins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var positionMagasin = await _context.PositionMagasins.FindAsync(id);
            _context.PositionMagasins.Remove(positionMagasin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PositionMagasinExists(int id)
        {
            return _context.PositionMagasins.Any(e => e.IdArticle == id);
        }
    }
}

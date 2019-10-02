using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fiap.Core.Context;
using Fiap.Core.Models;
using Microsoft.AspNetCore.Authorization;

namespace Fiap.Controllers
{
    [Authorize]
    public class DestinosController : Controller
    {
        private readonly TurismoContext _context;

        public DestinosController(TurismoContext context)
        {
            _context = context;
        }

        // GET: Destinoes
        public async Task<IActionResult> Index()
        {

            //User.Identity.Name

            return View(await _context.Destinos.ToListAsync());
        }

        // GET: Destinoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // GET: Destinoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destinoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Pais,Distancia")] Destino destino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destino);
        }

        // GET: Destinoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos.FindAsync(id);
            if (destino == null)
            {
                return NotFound();
            }
            return View(destino);
        }

        // POST: Destinoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Pais,Distancia")] Destino destino)
        {
            if (id != destino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(destino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DestinoExists(destino.Id))
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
            return View(destino);
        }

        // GET: Destinoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destino = await _context.Destinos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destino == null)
            {
                return NotFound();
            }

            return View(destino);
        }

        // POST: Destinoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destino = await _context.Destinos.FindAsync(id);
            _context.Destinos.Remove(destino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinoExists(int id)
        {
            return _context.Destinos.Any(e => e.Id == id);
        }
    }
}
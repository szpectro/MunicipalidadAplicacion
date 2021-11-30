using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MySqlDotnetCore.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace MySqlDotnetCore.Controllers
{
    public class TabladocumentoesController : Controller
    {
        private readonly sakilaContext _context;

        public TabladocumentoesController(sakilaContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Tabladocumentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tabladocumentos.ToListAsync());
        }

        // GET: Tabladocumentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabladocumento = await _context.Tabladocumentos
                .FirstOrDefaultAsync(m => m.Iddocumento == id);
            if (tabladocumento == null)
            {
                return NotFound();
            }

            return View(tabladocumento);
        }

        // GET: Tabladocumentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tabladocumentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddocumento,Nombredocumento,Tipocontenido,Archivo")] Tabladocumento tabladocumento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tabladocumento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tabladocumento);
        }

        // GET: Tabladocumentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabladocumento = await _context.Tabladocumentos.FindAsync(id);
            if (tabladocumento == null)
            {
                return NotFound();
            }
            return View(tabladocumento);
        }

        // POST: Tabladocumentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Iddocumento,Nombredocumento,Tipocontenido,Archivo")] Tabladocumento tabladocumento)
        {
            if (id != tabladocumento.Iddocumento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tabladocumento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TabladocumentoExists(tabladocumento.Iddocumento))
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
            return View(tabladocumento);
        }

        // GET: Tabladocumentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tabladocumento = await _context.Tabladocumentos
                .FirstOrDefaultAsync(m => m.Iddocumento == id);
            if (tabladocumento == null)
            {
                return NotFound();
            }

            return View(tabladocumento);
        }

        // POST: Tabladocumentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tabladocumento = await _context.Tabladocumentos.FindAsync(id);
            _context.Tabladocumentos.Remove(tabladocumento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TabladocumentoExists(int id)
        {
            return _context.Tabladocumentos.Any(e => e.Iddocumento == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UCP1_PAW_047_C.Models;

namespace UCP1_PAW_047_C.Controllers
{
    public class DataObatsController : Controller
    {
        private readonly TheDrugsContext _context;

        public DataObatsController(TheDrugsContext context)
        {
            _context = context;
        }

        // GET: DataObats
        public async Task<IActionResult> Index()
        {
            return View(await _context.DataObats.ToListAsync());
        }

        // GET: DataObats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataObat = await _context.DataObats
                .FirstOrDefaultAsync(m => m.IdObat == id);
            if (dataObat == null)
            {
                return NotFound();
            }

            return View(dataObat);
        }

        // GET: DataObats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DataObats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdObat,NamaObat,TanggalKadaluarsa,Harga,Komposisi")] DataObat dataObat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dataObat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dataObat);
        }

        // GET: DataObats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataObat = await _context.DataObats.FindAsync(id);
            if (dataObat == null)
            {
                return NotFound();
            }
            return View(dataObat);
        }

        // POST: DataObats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdObat,NamaObat,TanggalKadaluarsa,Harga,Komposisi")] DataObat dataObat)
        {
            if (id != dataObat.IdObat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dataObat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DataObatExists(dataObat.IdObat))
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
            return View(dataObat);
        }

        // GET: DataObats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dataObat = await _context.DataObats
                .FirstOrDefaultAsync(m => m.IdObat == id);
            if (dataObat == null)
            {
                return NotFound();
            }

            return View(dataObat);
        }

        // POST: DataObats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dataObat = await _context.DataObats.FindAsync(id);
            _context.DataObats.Remove(dataObat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DataObatExists(int id)
        {
            return _context.DataObats.Any(e => e.IdObat == id);
        }
    }
}

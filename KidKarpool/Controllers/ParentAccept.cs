using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KidKarpool.Data;
using KidKarpool.Models;

namespace KidKarpool.Controllers
{
    public class ParentAccept : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParentAccept(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ParentAccept
        public async Task<IActionResult> Index()
        {
            return View(await _context.Accept.ToListAsync());
        }

        // GET: ParentAccept/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accept = await _context.Accept
                .FirstOrDefaultAsync(m => m.AcceptID == id);
            if (accept == null)
            {
                return NotFound();
            }

            return View(accept);
        }

        // GET: ParentAccept/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParentAccept/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcceptID,StudentName,ParentAcceptingName,CarMakeModel,PhoneNumber")] Accept accept)
        {
            if (ModelState.IsValid)
            {
                _context.Add(accept);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(accept);
        }

        // GET: ParentAccept/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accept = await _context.Accept.FindAsync(id);
            if (accept == null)
            {
                return NotFound();
            }
            return View(accept);
        }

        // POST: ParentAccept/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcceptID,StudentName,ParentAcceptingName,CarMakeModel,PhoneNumber")] Accept accept)
        {
            if (id != accept.AcceptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(accept);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcceptExists(accept.AcceptID))
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
            return View(accept);
        }

        // GET: ParentAccept/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accept = await _context.Accept
                .FirstOrDefaultAsync(m => m.AcceptID == id);
            if (accept == null)
            {
                return NotFound();
            }

            return View(accept);
        }

        // POST: ParentAccept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accept = await _context.Accept.FindAsync(id);
            _context.Accept.Remove(accept);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcceptExists(int id)
        {
            return _context.Accept.Any(e => e.AcceptID == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestQuest.Data;
using TestQuest.Models;

namespace TestQuest.Controllers
{
    public class TestItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TestItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TestItems
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TestItem.Include(t => t.AppUser).Include(t => t.Test);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TestItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testItem = await _context.TestItem
                .Include(t => t.AppUser)
                .Include(t => t.Test)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testItem == null)
            {
                return NotFound();
            }

            return View(testItem);
        }

        // GET: TestItems/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id");
            ViewData["TestId"] = new SelectList(_context.Tests, "Id", "Theme");
            return View();
        }

        // POST: TestItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,TestId,Score")] TestItem testItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id", testItem.UserId);
            ViewData["TestId"] = new SelectList(_context.Tests, "Id", "Theme", testItem.TestId);
            return View(testItem);
        }

        // GET: TestItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testItem = await _context.TestItem.FindAsync(id);
            if (testItem == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id", testItem.UserId);
            ViewData["TestId"] = new SelectList(_context.Tests, "Id", "Theme", testItem.TestId);
            return View(testItem);
        }

        // POST: TestItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TestId,Score")] TestItem testItem)
        {
            if (id != testItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestItemExists(testItem.Id))
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
            ViewData["UserId"] = new SelectList(_context.AppUsers, "Id", "Id", testItem.UserId);
            ViewData["TestId"] = new SelectList(_context.Tests, "Id", "Theme", testItem.TestId);
            return View(testItem);
        }

        // GET: TestItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testItem = await _context.TestItem
                .Include(t => t.AppUser)
                .Include(t => t.Test)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testItem == null)
            {
                return NotFound();
            }

            return View(testItem);
        }

        // POST: TestItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testItem = await _context.TestItem.FindAsync(id);
            _context.TestItem.Remove(testItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestItemExists(int id)
        {
            return _context.TestItem.Any(e => e.Id == id);
        }
    }
}

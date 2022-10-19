using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market_Project.Models;
using Microsoft.AspNetCore.Hosting;

namespace Market_Project.Controllers
{
    public class Order1Controller : Controller
    {
        private readonly ModelContext _context; 
        private readonly IWebHostEnvironment _webHostEnviroment;

        public Order1Controller(ModelContext context, IWebHostEnvironment webHostEnviromen)
        {
            _context = context;
            _webHostEnviroment = webHostEnviromen;
        }


        // GET: Order1
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Order1s.Include(o => o.User);
            return View(await modelContext.ToListAsync());
        }

        // GET: Order1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order1 = await _context.Order1s
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order1 == null)
            {
                return NotFound();
            }

            return View(order1);
        }

        // GET: Order1/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.User1s, "Userid", "Fname");
            return View();
        }

        // POST: Order1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,Datee,Total,UserId")] Order1 order1)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order1);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.User1s, "Userid", "Fname", order1.UserId);
            return View(order1);
        }

        // GET: Order1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order1 = await _context.Order1s.FindAsync(id);
            if (order1 == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.User1s, "Userid", "Fname", order1.UserId);
            return View(order1);
        }

        // POST: Order1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("OrderId,Datee,Total,UserId")] Order1 order1)
        {
            if (id != order1.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Order1Exists(order1.OrderId))
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
            ViewData["UserId"] = new SelectList(_context.User1s, "Userid", "Fname", order1.UserId);
            return View(order1);
        }

        // GET: Order1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order1 = await _context.Order1s
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order1 == null)
            {
                return NotFound();
            }

            return View(order1);
        }

        // POST: Order1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var order1 = await _context.Order1s.FindAsync(id);
            _context.Order1s.Remove(order1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Order1Exists(decimal id)
        {
            return _context.Order1s.Any(e => e.OrderId == id);
        }
    }
}

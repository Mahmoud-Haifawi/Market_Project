using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Market_Project.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Market_Project.Controllers
{
    public class User1Controller : Controller
    {
        private readonly ModelContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;
        



        public User1Controller(ModelContext context, IWebHostEnvironment webHostEnviromen)
        {
            _context = context;
            _webHostEnviroment = webHostEnviromen;
        }

        // GET: User1
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.User1s.Include(u => u.Home).Include(u => u.Role);
            return View(await modelContext.ToListAsync());
        }

        // GET: User1/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s
                .Include(u => u.Home)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (user1 == null)
            {
                return NotFound();
            }

            return View(user1);
        }

        // GET: User1/Create
        public IActionResult Create()
        {
            ViewData["Homeid"] = new SelectList(_context.Homes, "Homeid", "Homeid");
            ViewData["Roleid"] = new SelectList(_context.Role1s, "Roleid", "Roleid");
            return View();
        }

        // POST: User1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Userid,Fname,Lname,Email,Password,ImagePath,Roleid,Homeid,ImageFile")] User1 user1)
        {
            if (ModelState.IsValid)
            {
                if (user1.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "" + user1.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/images/"+ fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await user1.ImageFile.CopyToAsync(fileStream);
                    }
                    user1.ImagePath = fileName;
                    user1.Homeid=null;
                    _context.Add(user1);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
               
                  
               
            }
            ViewData["Homeid"] = new SelectList(_context.Homes, "Homeid", "Homeid", user1.Homeid);
            ViewData["Roleid"] = new SelectList(_context.Role1s, "Roleid", "Roleid", user1.Roleid);
            return View(user1);
        }

        // GET: User1/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s.FindAsync(id);
            if (user1 == null)
            {
                return NotFound();
            }
            ViewData["Homeid"] = new SelectList(_context.Homes, "Homeid", "Homeid", user1.Homeid);
            ViewData["Roleid"] = new SelectList(_context.Role1s, "Roleid", "Roleid", user1.Roleid);
            return View(user1);
        }

        // POST: User1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("Userid,Fname,Lname,Email,Password,ImagePath,Roleid,Homeid,ImageFile")] User1 user1)
        {
            if (id != user1.Userid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user1);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!User1Exists(user1.Userid))
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
            ViewData["Homeid"] = new SelectList(_context.Homes, "Homeid", "Homeid", user1.Homeid);
            ViewData["Roleid"] = new SelectList(_context.Role1s, "Roleid", "Roleid", user1.Roleid);
            return View(user1);
        }

        // GET: User1/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user1 = await _context.User1s
                .Include(u => u.Home)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(m => m.Userid == id);
            if (user1 == null)
            {
                return NotFound();
            }

            return View(user1);
        }

        // POST: User1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            var user1 = await _context.User1s.FindAsync(id);
            _context.User1s.Remove(user1);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool User1Exists(decimal id)
        {
            return _context.User1s.Any(e => e.Userid == id);
        }
    }
}

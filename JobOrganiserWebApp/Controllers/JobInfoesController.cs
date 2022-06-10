using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobOrganiserWebApp.Data;
using JobOrganiserWebApp.Models;

namespace JobOrganiserWebApp.Controllers
{
    public class JobInfoesController : Controller
    {
        private readonly JobOrganiserWebAppContext _context;

        public JobInfoesController(JobOrganiserWebAppContext context)
        {
            _context = context;
        }

        // GET: JobInfoes
        public async Task<IActionResult> Index()
        {
              return _context.JobInfo != null ? 
                          View(await _context.JobInfo.ToListAsync()) :
                          Problem("Entity set 'JobOrganiserWebAppContext.JobInfo'  is null.");
        }

        // GET: JobInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.JobInfo == null)
            {
                return NotFound();
            }

            var jobInfo = await _context.JobInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobInfo == null)
            {
                return NotFound();
            }

            return View(jobInfo);
        }

        // GET: JobInfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: JobInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,JobTitle,JobDescription,EstCompletionDate,CustomerName")] JobInfo jobInfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jobInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jobInfo);
        }

        // GET: JobInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.JobInfo == null)
            {
                return NotFound();
            }

            var jobInfo = await _context.JobInfo.FindAsync(id);
            if (jobInfo == null)
            {
                return NotFound();
            }
            return View(jobInfo);
        }

        // POST: JobInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,JobTitle,JobDescription,EstCompletionDate,CustomerName")] JobInfo jobInfo)
        {
            if (id != jobInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jobInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobInfoExists(jobInfo.Id))
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
            return View(jobInfo);
        }

        // GET: JobInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.JobInfo == null)
            {
                return NotFound();
            }

            var jobInfo = await _context.JobInfo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jobInfo == null)
            {
                return NotFound();
            }

            return View(jobInfo);
        }

        // POST: JobInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.JobInfo == null)
            {
                return Problem("Entity set 'JobOrganiserWebAppContext.JobInfo'  is null.");
            }
            var jobInfo = await _context.JobInfo.FindAsync(id);
            if (jobInfo != null)
            {
                _context.JobInfo.Remove(jobInfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobInfoExists(int id)
        {
          return (_context.JobInfo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

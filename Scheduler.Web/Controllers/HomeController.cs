using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Scheduler.Web.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Scheduler.Web.Data;

namespace Scheduler.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly SchedulerWebContext _context;

        public HomeController(SchedulerWebContext context)
        {
            _context = context;
        }

        // GET: Trainings
        public async Task<IActionResult> Index()
        {
            var result = await _context
                .Training
                .Where(training => training.DateTime > DateTime.Today &&
                                   training.DateTime < DateTime.Today.AddDays(7))
                .ToListAsync();

            var todayTrainings = result.Where(training => training.DateTime < DateTime.Today.AddDays(1));

            var tomorrowTrainings = result.Where(training => 
                training.DateTime > DateTime.Today.AddDays(1) &&
                training.DateTime < DateTime.Today.AddDays(2));

            var dayAfterTrainings = result.Where(training => 
                training.DateTime > DateTime.Today.AddDays(2) &&
                training.DateTime < DateTime.Today.AddDays(3));

            var dayAfter2Trainings = result.Where(training => 
                training.DateTime > DateTime.Today.AddDays(3) &&
                training.DateTime < DateTime.Today.AddDays(4));

            var dayAfter3Trainings = result.Where(training => 
                training.DateTime > DateTime.Today.AddDays(4) &&
                training.DateTime < DateTime.Today.AddDays(5));

            var dayAfter4Trainings = result.Where(training => 
                training.DateTime > DateTime.Today.AddDays(5) &&
                training.DateTime < DateTime.Today.AddDays(6));

            var dictionary = new Dictionary<DateTime, IEnumerable<Training>>
            {
                { DateTime.Today, todayTrainings },
                { DateTime.Today.AddDays(1), tomorrowTrainings },
                { DateTime.Today.AddDays(2), dayAfterTrainings },
                { DateTime.Today.AddDays(3), dayAfter2Trainings },
                { DateTime.Today.AddDays(4), dayAfter3Trainings },
                { DateTime.Today.AddDays(5), dayAfter4Trainings },

            };

            return View(dictionary);
        }

        // GET: Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateTime")] Training training)
        {
            if (ModelState.IsValid)
            {
                _context.Add(training);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(training);
        }

        // GET: Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training.FindAsync(id);
            if (training == null)
            {
                return NotFound();
            }
            return View(training);
        }

        // POST: Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Name,DateTime")] Training training)
        {
            if (id != training.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(training);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrainingExists(training.Id))
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
            return View(training);
        }

        // GET: Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var training = await _context.Training
                .FirstOrDefaultAsync(m => m.Id == id);
            if (training == null)
            {
                return NotFound();
            }

            return View(training);
        }

        // POST: Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var training = await _context.Training.FindAsync(id);
            _context.Training.Remove(training);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrainingExists(long id)
        {
            return _context.Training.Any(e => e.Id == id);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using InitialTask3.Models;

namespace InitialTask3.Controllers
{
    public class SalariesController : Controller
    {
        private readonly Initial3Context _context;

       
        public SalariesController(Initial3Context context)
        {
            _context = context;
        }

        // GET: Salaries
        public async Task<IActionResult> Index()

        {
           
              return _context.Salaries != null ? 
                          View(await _context.Salaries.ToListAsync()) :
                          Problem("Entity set 'Initial3Context.Salaries'  is null.");
        }

        // GET: Salaries/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Salaries == null)
            {
                return NotFound();
            }

            var salary = await _context.Salaries
                .FirstOrDefaultAsync(m => m.ActualAnnualSalary == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // GET: Salaries/Create
        public IActionResult Create()
        {
            TempData["name"] = "Update Survey";
            return View();
        }

        // POST: Salaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActualAnnualSalary,LastYearOtherIncome,TotalIncome")] List<Salary> salary)
        {
          
      
            if (ModelState.IsValid)
            {
                _context.AddRange(salary);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salary);
        }

        // GET: Salaries/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Salaries == null)
            {
                return NotFound();
            }

            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null)
            {
                return NotFound();
            }
            return View(salary);
        }

        // POST: Salaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ActualAnnualSalary,LastYearOtherIncome,TotalIncome")] Salary salary)
        {
            if (id != salary.ActualAnnualSalary)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salary);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryExists(salary.ActualAnnualSalary))
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
            return View(salary);
        }

        // GET: Salaries/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Salaries == null)
            {
                return NotFound();
            }

            var salary = await _context.Salaries
                .FirstOrDefaultAsync(m => m.ActualAnnualSalary == id);
            if (salary == null)
            {
                return NotFound();
            }

            return View(salary);
        }

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Salaries == null)
            {
                return Problem("Entity set 'Initial3Context.Salaries'  is null.");
            }
            var salary = await _context.Salaries.FindAsync(id);
            if (salary != null)
            {
                _context.Salaries.Remove(salary);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryExists(long id)
        {
          return (_context.Salaries?.Any(e => e.ActualAnnualSalary == id)).GetValueOrDefault();
        }
    }
}

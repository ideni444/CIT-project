using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School_Schedule_MVC.Models;

namespace School_Schedule_MVC.Controllers
{
    //Time table controller using Identity.
    [Authorize]
    public class TimeTablesController : Controller
    {
        private readonly School_Schedule_MVCDataContext _context;

        public TimeTablesController(School_Schedule_MVCDataContext context)
        {
            _context = context;
        }

        // GET: TimeTables
        //Gets all time table records using a lamda query.
        public IActionResult Index()
        {
            var school_Schedule_MVCDataContext = _context.TimeTable.Include(t => t.Subject).Include(t => t.Teacher);
            return View( school_Schedule_MVCDataContext.ToList());
        }

        // GET: TimeTables/Details/5
        //Gets  details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable =  _context.TimeTable
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefault(m => m.Id == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // GET: TimeTables/Create
        //Gets the create form.
        public IActionResult Create()
        {
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "SubjectRegistrationId");
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "TeacherRegistrationName");
            ViewData["Day"] = new SelectList(Enum.GetValues(typeof(DayOfWeek)));
            return View();
        }

        // POST: TimeTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds  time table record to database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,SubjectId,TeacherId,StarTime,EndTime,Day")] TimeTable timeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeTable);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", timeTable.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "ContactNumber", timeTable.TeacherId);
            return View(timeTable);
        }

        // GET: TimeTables/Edit/5
        //Gets  a time tablem record for update using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable = (from timetables in _context.TimeTable
                             where timetables.Id == id
                             select timetables).FirstOrDefault();
            if (timeTable == null)
            {
                return NotFound();
            }
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "SubjectRegistrationId", timeTable.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "TeacherRegistrationName", timeTable.TeacherId);
            ViewData["Day"] = new SelectList(Enum.GetValues(typeof(DayOfWeek)), timeTable.Day);
           
            return View(timeTable);
        }

        // POST: TimeTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the time table record 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,SubjectId,TeacherId,StarTime,EndTime,Day")] TimeTable timeTable)
        {
            if (id != timeTable.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeTable);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeTableExists(timeTable.Id))
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
            ViewData["SubjectId"] = new SelectList(_context.Subject, "Id", "Name", timeTable.SubjectId);
            ViewData["TeacherId"] = new SelectList(_context.Teacher, "Id", "ContactNumber", timeTable.TeacherId);
            return View(timeTable);
        }

        // GET: TimeTables/Delete/5
        //Gets the time table record for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeTable =  _context.TimeTable
                .Include(t => t.Subject)
                .Include(t => t.Teacher)
                .FirstOrDefault(m => m.Id == id);
            if (timeTable == null)
            {
                return NotFound();
            }

            return View(timeTable);
        }

        // POST: TimeTables/Delete/5
        //Deletes the time table record select the time table record using a linq query.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var timeTable = (from timetables in _context.TimeTable
                             where timetables.Id == id
                             select timetables).FirstOrDefault();
            _context.TimeTable.Remove(timeTable);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the time table record exists using a lamda query.
        private bool TimeTableExists(int id)
        {
            return _context.TimeTable.Any(e => e.Id == id);
        }
    }
}

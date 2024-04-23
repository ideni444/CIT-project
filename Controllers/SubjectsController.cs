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
    //Subject controller with identity.
    [Authorize]
    public class SubjectsController : Controller
    {
        private readonly School_Schedule_MVCDataContext _context;

        public SubjectsController(School_Schedule_MVCDataContext context)
        {
            _context = context;
        }

        // GET: Subjects
        //Gets all the subjects using a linq query.
        public IActionResult Index()
        {
            return View((from subject  in _context.Subject select subject).ToList());
        }

        // GET: Subjects/Details/5
        //Gets the details using  a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject =  _context.Subject
                .FirstOrDefault(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        //Gets the create form.
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds  the subject to database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Credits")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subject);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: Subjects/Edit/5
        //Gets the subject for update using  a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = (from subjects in _context.Subject
                           where subjects.Id == id
                           select subjects).FirstOrDefault();
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the subject
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Credits")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subject);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        //Gets the subject for delete using a lamda query
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = _context.Subject
                .FirstOrDefault(m => m.Id == id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        //Delete the subject uses a linq query to get the subject
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var subject = (from subjects in _context.Subject
                           where subjects.Id == id
                           select subjects).FirstOrDefault();
            _context.Subject.Remove(subject);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the subject using a linq query.
        private bool SubjectExists(int id)
        {
            return _context.Subject.Any(e => e.Id == id);
        }
    }
}

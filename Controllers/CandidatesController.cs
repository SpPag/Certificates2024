using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Certificates2024.Data;
using Certificates2024.Models;
using Certificates2024.Data.Services;

namespace Certificates2024.Controllers
{
    public class CandidatesController : Controller
    {
        private readonly ICandidatesService _service;

        public CandidatesController(ICandidatesService service)
        {
            _service = service;
        }

        // GET: Candidates
        public async Task<IActionResult> Index()
        {
            var candidates = await _service.GetAllAsync();
            return View(candidates);
        }

        // GET: Candidates/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _service.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // GET: Candidates/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidateId,FirstName,LastName,BirthDate,PhotoIdNumber,Email")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {                
                await _service.AddAsync(candidate);
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _service.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CandidateId,FirstName,LastName,BirthDate,PhotoIdNumber,Email")] Candidate candidate)
        {
            if (id != candidate.CandidateId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                    await _service.UpdateAsync(id, candidate);
                    return RedirectToAction(nameof(Index));
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!CandidateExists(candidate.CandidateId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidate = await _service.GetByIdAsync(id);
            if (candidate == null)
            {
                return NotFound();
            }

            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _service.GetByIdAsync(id);
            if (candidate != null)
            {
                await _service.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}

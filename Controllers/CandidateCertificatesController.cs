using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Certificates2024.Data;
using Certificates2024.Models;

namespace Certificates2024.Controllers
{
    public class CandidateCertificatesController : Controller
    {
        private readonly AppDbContext _context;

        public CandidateCertificatesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CandidateCertificates
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.CandidateCertificates.Include(c => c.Candidate).Include(c => c.CertificateTopic);
            return View(await appDbContext.ToListAsync());
        }

        // GET: CandidateCertificates/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateCertificate = await _context.CandidateCertificates
                .Include(c => c.Candidate)
                .Include(c => c.CertificateTopic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidateCertificate == null)
            {
                return NotFound();
            }

            return View(candidateCertificate);
        }

        // GET: CandidateCertificates/Create
        public IActionResult Create()
        {
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id");
            ViewData["CertificateTopicId"] = new SelectList(_context.CertificateTopics, "Id", "Id");
            return View();
        }

        // POST: CandidateCertificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CandidateId,CertificateTopicId,ExaminationDate,CandidateScore,MaximumScore,ResultLabel")] CandidateCertificate candidateCertificate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidateCertificate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id", candidateCertificate.CandidateId);
            ViewData["CertificateTopicId"] = new SelectList(_context.CertificateTopics, "Id", "Id", candidateCertificate.CertificateTopicId);
            return View(candidateCertificate);
        }

        // GET: CandidateCertificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateCertificate = await _context.CandidateCertificates.FindAsync(id);
            if (candidateCertificate == null)
            {
                return NotFound();
            }
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id", candidateCertificate.CandidateId);
            ViewData["CertificateTopicId"] = new SelectList(_context.CertificateTopics, "Id", "Id", candidateCertificate.CertificateTopicId);
            return View(candidateCertificate);
        }

        // POST: CandidateCertificates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CandidateId,CertificateTopicId,ExaminationDate,CandidateScore,MaximumScore,ResultLabel")] CandidateCertificate candidateCertificate)
        {
            if (id != candidateCertificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidateCertificate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidateCertificateExists(candidateCertificate.Id))
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
            ViewData["CandidateId"] = new SelectList(_context.Candidates, "Id", "Id", candidateCertificate.CandidateId);
            ViewData["CertificateTopicId"] = new SelectList(_context.CertificateTopics, "Id", "Id", candidateCertificate.CertificateTopicId);
            return View(candidateCertificate);
        }

        // GET: CandidateCertificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateCertificate = await _context.CandidateCertificates
                .Include(c => c.Candidate)
                .Include(c => c.CertificateTopic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (candidateCertificate == null)
            {
                return NotFound();
            }

            return View(candidateCertificate);
        }

        // POST: CandidateCertificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidateCertificate = await _context.CandidateCertificates.FindAsync(id);
            if (candidateCertificate != null)
            {
                _context.CandidateCertificates.Remove(candidateCertificate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidateCertificateExists(int id)
        {
            return _context.CandidateCertificates.Any(e => e.Id == id);
        }
    }
}

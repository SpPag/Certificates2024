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
    public class CandidateCertificatesController : Controller
    {
        private readonly ICandidateCertificatesService _service;


        public CandidateCertificatesController(ICandidateCertificatesService service)
        {
            _service = service;
        }

        // GET: CandidateCertificates
        public async Task<IActionResult> Index()
        {
            var appDbContext = await _service.GetAllAsync();

            return View(appDbContext);
        }

        // GET: CandidateCertificates/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateCertificate = await _service.GetByIdAsync(id);
                //.Include(c => c.Candidate)
                //.Include(c => c.CertificateTopic)
                //.FirstOrDefaultAsync(m => m.Id == id);
            if (candidateCertificate == null)
            {
                return NotFound();
            }

            return View(candidateCertificate);
        }

        // GET: CandidateCertificates/Create
        public async Task<IActionResult> Create()
        {
            var candidates = await _service.GetAllCandidatesAsync();
            var certificateTopics = await _service.GetAllCertificateTopicsAsync();
            if (candidates == null || !candidates.Any())
            {
                // Handle the case where candidates list is empty or null
                ModelState.AddModelError("", "No candidates found.");
            }

            if (certificateTopics == null || !certificateTopics.Any())
            {
                // Handle the case where certificate topics list is empty or null
                ModelState.AddModelError("", "No certificate topics found.");
            }
            ViewBag.CandidateId = new SelectList(candidates.Select(c => new { c.Id, FullName = $"{c.FirstName} {c.LastName}" }), "Id", "FullName");
            ViewBag.CertificateTopicId = new SelectList(certificateTopics, "Id", "TopicName");
            return View();
        }

        // POST: CandidateCertificates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CandidateId,CertificateTopicId,ExaminationDate,CandidateScore,MaximumScore,ResultLabel")] CandidateCertificate candidateCertificate)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(candidateCertificate);
                return RedirectToAction(nameof(Index));
            }

            var candidates = await _service.GetAllCandidatesAsync();
            var certificateTopics = await _service.GetAllCertificateTopicsAsync();
            ViewBag.CandidateId = new SelectList(candidates, "Id", "FirstName", candidateCertificate.CandidateId);
            ViewBag.CertificateTopicId = new SelectList(certificateTopics, "Id", "TopicName", candidateCertificate.CertificateTopicId);
            return View(candidateCertificate);
        }

        // GET: CandidateCertificates/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateCertificate = await _service.GetByIdAsync(Convert.ToInt32(id));
            if (candidateCertificate == null)
            {
                return NotFound();
            }

            var candidates = await _service.GetAllCandidatesAsync();
            var certificateTopics = await _service.GetAllCertificateTopicsAsync();
            ViewBag.CandidateId = new SelectList(candidates, "Id", "FirstName", candidateCertificate.CandidateId);
            ViewBag.CertificateTopicId = new SelectList(certificateTopics, "Id", "TopicName", candidateCertificate.CertificateTopicId);
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
                //try
                //{
                    await _service.UpdateAsync(id, candidateCertificate);
                    return RedirectToAction(nameof(Index));
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!CandidateCertificateExists(candidateCertificate.Id))
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
            var candidates = await _service.GetAllCandidatesAsync();
            var certificateTopics = await _service.GetAllCertificateTopicsAsync();
            ViewBag.CandidateId = new SelectList(candidates, "Id", "FirstName", candidateCertificate.CandidateId);
            ViewBag.CertificateTopicId = new SelectList(certificateTopics, "Id", "TopicName", candidateCertificate.CertificateTopicId);
            return View(candidateCertificate);
        }

        // GET: CandidateCertificates/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateCertificate = await _service.GetByIdAsync(Convert.ToInt32(id));

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
            var candidateCertificate = await _service.GetByIdAsync(id);
            if (candidateCertificate != null)
            {
                await _service.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        //private bool CandidateCertificateExists(int id)
        //{
        //    return _service.CandidateCertificates.Any(e => e.Id == id);
        //}
    }
}

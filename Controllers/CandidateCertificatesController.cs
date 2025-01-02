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
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Certificates2024.Data.Static;

namespace Certificates2024.Controllers
{
    [Authorize]
    public class CandidateCertificatesController : Controller
    {
        private readonly ICandidateCertificatesService _service;


        public CandidateCertificatesController(ICandidateCertificatesService service)
        {
            _service = service;
        }

        // GET: CandidateCertificates
        //public async Task<IActionResult> Index()
        //{
        //    var appDbContext = await _service.GetAllAsync();

        //    return View(appDbContext);
        //}
        public async Task<IActionResult> Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);

            var orders = await _service.GetCertificatesByUserIdAndRoleAsync(userId, userRole);
            return View(orders);
        }
        // GET: CandidateCertificates/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var candidateCertificate = await _service.GetByIdAsync(id);
            if (candidateCertificate == null)
            {
                return NotFound();
            }

            return View(candidateCertificate);
        }
        // GET: CandidateCertificates/Create with topicId
        public async Task<IActionResult> Create(int? topicId)
        {
            // Get current user
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentCandidate = await _service.GetCandidateByUserIdAsync(userId);

            if (currentCandidate == null)
            {
                return BadRequest("Candidate not found for the current user.");
            }

            var certificateTopics = await _service.GetAllCertificateTopicsAsync();

            ViewBag.CandidateId = new SelectList(new List<object> { new { Id = currentCandidate.Id, FullName = $"{currentCandidate.FirstName} {currentCandidate.LastName}" } }, "Id", "FullName");

            //ViewBag.CertificateTopicId = new SelectList(certificateTopics, "Id", "TopicName");
            //var currentTopic = await _service.GetCertificateTopicByIdAsync(topicId);
            //ViewBag.CertificateTopicId = new SelectList(new List<CertificateTopic> { currentTopic }, "Id", "TopicName");

            // If a topicId is passed, pre-select that topic in the dropdown
            if (topicId.HasValue)
            {
                var currentTopic = await _service.GetCertificateTopicByIdAsync(topicId.Value);
                ViewBag.CertificateTopicId = new SelectList(new List<CertificateTopic> { currentTopic }, "Id", "TopicName");
                ViewBag.IsSpecificTopic = true; // Flag to indicate a specific topic is preselected
            }
            else
            {
                ViewBag.CertificateTopicId = new SelectList(certificateTopics, "Id", "TopicName");
                ViewBag.IsSpecificTopic = false; // Flag to indicate the full list is shown
            }
            return View();
        }

        // POST: CandidateCertificates/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificateTopicId,ExaminationDate")] CandidateCertificate candidateCertificate)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var currentCandidate = await _service.GetCandidateByUserIdAsync(userId);

            if (currentCandidate == null)
            {
                return BadRequest("Candidate not found for the current user.");
            }

            candidateCertificate.CandidateId = currentCandidate.Id;

            if (ModelState.IsValid && candidateCertificate.ExaminationDate >= DateTime.Now)
            {
                await _service.AddAsync(candidateCertificate);
                return RedirectToAction(nameof(Index));
            }

            var certificateTopics = await _service.GetAllCertificateTopicsAsync();
            ViewBag.CandidateId = new SelectList(new List<object> { new { Id = currentCandidate.Id, FullName = $"{currentCandidate.FirstName} {currentCandidate.LastName}" } }, "Id", "FullName");
            ViewBag.CertificateTopicId = new SelectList(certificateTopics, "Id", "TopicName", candidateCertificate.CertificateTopicId);

            return View(candidateCertificate);
        }

        // GET: CandidateCertificates/Edit/5
        [Authorize(Roles = UserRoles.Admin)]
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
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CandidateId,CertificateTopicId,ExaminationDate,CandidateScore,MaximumScore,ResultLabel")] CandidateCertificate candidateCertificate)
        {
            if (id != candidateCertificate.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid && candidateCertificate.ExaminationDate >= DateTime.Now)
            {
                await _service.UpdateAsync(id, candidateCertificate);
                return RedirectToAction(nameof(Index));
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
            if (candidateCertificate.CandidateTestId != null)
            {
                return View("~/Views/Account/AccessDenied.cshtml");
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
    }
}

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
    public class CertificateTopicsController : Controller
    {
        private readonly AppDbContext _context;

        public CertificateTopicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CertificateTopics
        public async Task<IActionResult> Index()
        {
            var allTopics = await _context.CertificateTopics.ToListAsync();
            return View(allTopics);
        }

        // GET: CertificateTopics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateTopic = await _context.CertificateTopics
                .FirstOrDefaultAsync(m => m.CertificateTopicID == id);
            if (certificateTopic == null)
            {
                return NotFound();
            }

            return View(certificateTopic);
        }

        // GET: CertificateTopics/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CertificateTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CertificateTopicID,TopicName")] CertificateTopic certificateTopic)
        {
            if (ModelState.IsValid)
            {
                _context.Add(certificateTopic);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(certificateTopic);
        }

        // GET: CertificateTopics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateTopic = await _context.CertificateTopics.FindAsync(id);
            if (certificateTopic == null)
            {
                return NotFound();
            }
            return View(certificateTopic);
        }

        // POST: CertificateTopics/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CertificateTopicID,TopicName")] CertificateTopic certificateTopic)
        {
            if (id != certificateTopic.CertificateTopicID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(certificateTopic);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificateTopicExists(certificateTopic.CertificateTopicID))
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
            return View(certificateTopic);
        }

        // GET: CertificateTopics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateTopic = await _context.CertificateTopics
                .FirstOrDefaultAsync(m => m.CertificateTopicID == id);
            if (certificateTopic == null)
            {
                return NotFound();
            }

            return View(certificateTopic);
        }

        // POST: CertificateTopics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certificateTopic = await _context.CertificateTopics.FindAsync(id);
            if (certificateTopic != null)
            {
                _context.CertificateTopics.Remove(certificateTopic);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificateTopicExists(int id)
        {
            return _context.CertificateTopics.Any(e => e.CertificateTopicID == id);
        }
    }
}

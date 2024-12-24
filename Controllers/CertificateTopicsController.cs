﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Certificates2024.Data;
using Certificates2024.Models;
using Certificates2024.Data.Enums;
using Certificates2024.Data.Services;

namespace Certificates2024.Controllers
{
    public class CertificateTopicsController : Controller
    {
        private readonly ICertificateTopicsService _service;

        public CertificateTopicsController(ICertificateTopicsService service)
        {
            _service = service;
        }

        // GET: CertificateTopics
        public async Task<IActionResult> Index()
        {
            var allTopics = await _service.GetAllAsync();
            return View(allTopics);
        }

        // GET: CertificateTopics/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateTopic = await _service.GetByIdAsync(Convert.ToInt32(id));
            if (certificateTopic == null)
            {
                return NotFound();
            }

            return View(certificateTopic);
        }

        // GET: CertificateTopics/Create
        public IActionResult Create()
        {
            ViewData["TopicName"] = Enum.GetValues(typeof(TopicName))
                         .Cast<TopicName>()
                         .Select(t => new SelectListItem
                         {
                             Value = ((int)t).ToString(), // Use integer value for database storage
                             Text = t.ToString()         // Display enum name in dropdown
                         })
                         .ToList();
            return View();
        }

        // POST: CertificateTopics/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TopicName")] CertificateTopic certificateTopic)
        {
            Console.WriteLine("Create has been called");
            if (ModelState.IsValid)
            {
                await _service.AddAsync(certificateTopic);
                Console.WriteLine("ModelState is valid");
                ViewData["TopicName"] = Enum.GetValues(typeof(TopicName))
                     .Cast<TopicName>()
                     .Select(t => new SelectListItem
                     {
                         Value = t.ToString(),
                         Text = t.ToString()
                     })
                     .ToList();
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("ModelState is invalid");

            return View(certificateTopic);
        }

        // GET: CertificateTopics/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateTopic = await _service.GetByIdAsync(Convert.ToInt32(id));
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,TopicName")] CertificateTopic certificateTopic)
        {
            if (id != certificateTopic.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //try
                //{
                await _service.UpdateAsync(id, certificateTopic);
                return RedirectToAction(nameof(Index));
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!CertificateTopicExists(certificateTopic.Id))
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
            return View(certificateTopic);
        }

        // GET: CertificateTopics/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certificateTopic = await _service.GetByIdAsync(Convert.ToInt32(id));
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
            var certificateTopic = await _service.GetByIdAsync(id);
            if (certificateTopic != null)
            {
                await _service.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
        //    private bool CertificateTopicExists(int id)
        //    {
        //        return _context.CertificateTopics.Any(e => e.Id == id);
        //    }
    }
}
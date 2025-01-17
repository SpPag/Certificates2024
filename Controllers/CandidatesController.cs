﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Certificates2024.Data;
using Certificates2024.Models;
using Certificates2024.Data.Services;
using Microsoft.AspNetCore.Authorization;
using Certificates2024.Data.Static;
using Microsoft.AspNetCore.Identity;

namespace Certificates2024.Controllers
{
    [Authorize]
    public class CandidatesController : Controller
    {
        private readonly ICandidatesService _service;
        private readonly UserManager<ApplicationUser> _userManager;

        public CandidatesController(ICandidatesService service, UserManager<ApplicationUser> userManager)
        {
            _service = service;
            _userManager = userManager;
        }

        // GET: Candidates
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Index()
        {
            var candidates = await _service.GetAllAsync();
            return View(candidates);
        }

        // GET: Candidates/Details/5
        [Authorize(Roles = UserRoles.Admin)]
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
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Candidates/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FirstName,LastName,BirthDate,PhotoIdNumber,Email")] Candidate candidate)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var errors = ModelState.Values.SelectMany(v => v.Errors);
        //        foreach (var error in errors)
        //        {
        //            Console.WriteLine(error.ErrorMessage);
        //        }
        //        return View(candidate);
        //    }
        //    await _service.AddAsync(candidate);
        //    return RedirectToAction(nameof(Index));

        //}

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
            //UPDATE 5/1/25 Edit and permission
            var loggedInUserId = _userManager.GetUserId(User); // Logged-in user's ID
            if (!User.IsInRole(UserRoles.Admin) && candidate.ApplicationUserId != loggedInUserId)
            {
                return Forbid(); // Return 403 Forbidden if access is denied
            }
                //END UPDATE
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken] I don't know if this messes anything up so I'm commenting it.Also it was auto-generated so we may not want it at all
        public async Task<IActionResult> Edit(int id, [Bind("Id, ApplicationUserId, FirstName, LastName, BirthDate, PhotoIdNumber, Email")] Candidate candidate)
        {
            if (id != candidate.Id)
            {
                return NotFound();
            }
            //UPDATE 5/1/25 Edit and permission
            var loggedInUserId = _userManager.GetUserId(User); // Logged-in user's ID
            if (!User.IsInRole(UserRoles.Admin) && candidate.ApplicationUserId != loggedInUserId)
            {
                return Forbid(); // Return 403 Forbidden if access is denied
            }
            //END UPDATE

            if (!ModelState.IsValid)
            {
                return View(candidate);
            }

            if (candidate == null)
            {
                return NotFound();
            }


            // Update the email in the ApplicationUser table
            var user = await _userManager.FindByIdAsync(candidate.ApplicationUserId);
            if (user != null)
            {
                user.FullName = $"{candidate.FirstName} {candidate.LastName}";
                user.Email = candidate.Email;
                user.UserName = candidate.Email; // Update username if it is tied to email
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    return View(candidate);
                }
            }

            //Update the Candidate
            await _service.UpdateAsync(id, candidate);

            if (User.IsInRole(UserRoles.User) && candidate.ApplicationUserId == loggedInUserId)
            {
                return RedirectToAction("UserDetails", "Account"); //action, controller
            }

            if (User.IsInRole(UserRoles.Admin))
            {
                return RedirectToAction(nameof(Index));
            }
            return NotFound();

        }

        // GET: Candidates/Delete/5
        [Authorize(Roles = UserRoles.Admin)]
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

            if (candidate.CandidateCertificates?.Count > 0)
            {
                Console.WriteLine("Candidate has certificates");
                TempData["DeleteMessage"] = "You cannot delete this candidate because they have certificates.";
                return RedirectToAction(nameof(Index));
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var candidate = await _service.GetByIdAsync(id);
            if (candidate != null)
            {
                // First, delete the associated ApplicationUser
                var user = await _userManager.FindByIdAsync(candidate.ApplicationUserId);
                if (user != null)
                {
                    Console.WriteLine("user isn't null");
                    var deleteResult = await _userManager.DeleteAsync(user);
                    Console.WriteLine("user deleted");
                    if (!deleteResult.Succeeded)
                    {
                        foreach (var error in deleteResult.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                        return View(candidate);
                    }
                }
                //await _service.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
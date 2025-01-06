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
using Certificates2024.Data.Static;
using Microsoft.AspNetCore.Authorization;
using Certificates2024.Data.Enums;

namespace Certificates2024.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class QuestionsController : Controller
    {
        private readonly IQuestionsService _service;

        public QuestionsController(IQuestionsService service)
        {
            _service = service;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var questions = await _service.GetAllAsync();
            return View(questions);
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _service.GetByIdAsync(Convert.ToInt32(id));
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public async Task<IActionResult> Create()
        {
            var topics = await _service.GetAllTopicsAsync();
            ViewBag.CertificateTopicId = Enum.GetValues(typeof(TopicName))
                         .Cast<TopicName>()
                         .Select(t => new SelectListItem
                         {
                             Value = ((int)t).ToString(), // Use integer value for database storage
                             Text = EnumExtensions.GetDescription(t) // Display enum name in dropdown
                         })
                         .ToList();
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionText,CertificateTopicId,ImageSource,BooleanA,AnswerA,BooleanB,AnswerB,BooleanC,AnswerC,BooleanD,AnswerD")] Question question, string CorrectOption)
        {
            switch (CorrectOption)
            {
                case "A":
                    question.BooleanA = true;
                    break;
                case "B":
                    question.BooleanB = true;
                    break;
                case "C":
                    question.BooleanC = true;
                    break;
                case "D":
                    question.BooleanD = true;
                    break;
            }
            int trueCount = new[] { question.BooleanA, question.BooleanB, question.BooleanC, question.BooleanD }.Count(b => b);

            if (trueCount > 1)
            {
                ModelState.AddModelError(string.Empty, "Only one of the Boolean fields (BooleanA, BooleanB, BooleanC, BooleanD) can be true.");
            }
            if (ModelState.IsValid)
            {
                await _service.AddAsync(question);
                return RedirectToAction(nameof(Index));
            }

            var topics = await _service.GetAllTopicsAsync();
            ViewBag.CertificateTopicId = Enum.GetValues(typeof(TopicName))
                         .Cast<TopicName>()
                         .Select(t => new SelectListItem
                         {
                             Value = ((int)t).ToString(), // Use integer value for database storage
                             Text = EnumExtensions.GetDescription(t) // Display enum name in dropdown
                         })
                         .ToList();
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _service.GetByIdAsync(Convert.ToInt32(id));
            if (question == null)
            {
                return NotFound();
            }
            var topics = await _service.GetAllTopicsAsync();
            ViewBag.CertificateTopicId = Enum.GetValues(typeof(TopicName))
                         .Cast<TopicName>()
                         .Select(t => new SelectListItem
                         {
                             Value = ((int)t).ToString(), // Use integer value for database storage
                             Text = EnumExtensions.GetDescription(t) // Display enum name in dropdown
                         })
                         .ToList();
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionText,CertificateTopicId,ImageSource,BooleanA,AnswerA,BooleanB,AnswerB,BooleanC,AnswerC,BooleanD,AnswerD")] Question question, string CorrectOption)
        {
            switch (CorrectOption)
            {
                case "A":
                    question.BooleanA = true;
                    break;
                case "B":
                    question.BooleanB = true;
                    break;
                case "C":
                    question.BooleanC = true;
                    break;
                case "D":
                    question.BooleanD = true;
                    break;
            }
            int trueCount = new[] { question.BooleanA, question.BooleanB, question.BooleanC, question.BooleanD }.Count(b => b);

            if (trueCount > 1)
            {
                ModelState.AddModelError(string.Empty, "Only one of the Boolean fields (BooleanA, BooleanB, BooleanC, BooleanD) can be true.");
            }

            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id, question);
                return RedirectToAction(nameof(Index));
            }
            var topics = await _service.GetAllTopicsAsync();
            ViewBag.CertificateTopicId = Enum.GetValues(typeof(TopicName))
                         .Cast<TopicName>()
                         .Select(t => new SelectListItem
                         {
                             Value = ((int)t).ToString(), // Use integer value for database storage
                             Text = EnumExtensions.GetDescription(t) // Display enum name in dropdown
                         })
                         .ToList();
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _service.GetByIdAsync(Convert.ToInt32(id));
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _service.GetByIdAsync(id);
            if (question != null)
            {
                await _service.DeleteAsync(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
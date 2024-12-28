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
            Console.WriteLine("Create has been called");
            var topics = await _service.GetAllTopicsAsync();
            ViewBag.CertificateTopicId = new SelectList(topics, "Id", "TopicName");
            Console.WriteLine("ViewBag has been created");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionText,CertificateTopicId,ImageSource,BooleanA,AnswerA,BooleanB,AnswerB,BooleanC,AnswerC,BooleanD,AnswerD")] Question question)
        {
            Console.WriteLine("Post create has been called");
            if (ModelState.IsValid)
            {
                Console.WriteLine("ModelState is valid");
                await _service.AddAsync(question);
                return RedirectToAction(nameof(Index));
            }
            Console.WriteLine("ModelState is not valid");
            var topics = await _service.GetAllTopicsAsync();
            ViewBag.CertificateTopicId = new SelectList(topics, "Id", "TopicName");
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
            ViewBag.CertificateTopicId = new SelectList(topics, "Id", "TopicName");
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,QuestionText,CertificateTopicId,ImageSource,BooleanA,AnswerA,BooleanB,AnswerB,BooleanC,AnswerC,BooleanD,AnswerD")] Question question)
        {
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
            ViewBag.CertificateTopicId = new SelectList(topics, "Id", "TopicName");
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

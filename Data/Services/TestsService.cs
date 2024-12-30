﻿using Certificates2024.Data.Services;
using Certificates2024.Data;
using Certificates2024.Models;

public class TestsService : ITestsService
{
    private readonly IQuestionsService _questionsService;
    private readonly AppDbContext _context;

    public TestsService(IQuestionsService questionsService, AppDbContext context)
    {
        _questionsService = questionsService;
        _context = context;
    }

    public async Task<double> CalculateScoreAsync(int topicId, List<CandidateResponse> responses)
    {
        var questions = await _questionsService.GetQuestionsByTopicIdAsync(topicId);
        int correctAnswers = 0;

        foreach (var response in responses)
        {
            var question = questions.FirstOrDefault(q => q.Id == response.QuestionId);
            if (question == null) continue;

            string correctAnswer = question.BooleanA ? question.AnswerA :
                                   question.BooleanB ? question.AnswerB :
                                   question.BooleanC ? question.AnswerC :
                                   question.BooleanD ? question.AnswerD : null;

            if (response.SelectedAnswer == correctAnswer)
            {
                correctAnswers++;
            }
        }

        return (double)correctAnswers / questions.Count() * 100; // Return score as a percentage
    }

    public async Task SaveTestResultAsync(CandidateTest candidateTest)
    {
        _context.CandidateTests.Add(candidateTest);
        await _context.SaveChangesAsync();
    }
}
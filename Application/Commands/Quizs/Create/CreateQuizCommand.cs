﻿using MediatR;

namespace Application.Features.Quizs.Create
{
    public class CreateQuizCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string WrongAnswer1 { get; set; }
        public string WrongAnswer2 { get; set; }
        public string WrongAnswer3 { get; set; }
    }
}

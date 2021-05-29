using System;
using FluentValidation;
using Lab1.ViewModels;

namespace Lab1.Validators
{
    public class MovieValidator : AbstractValidator<MovieViewModel>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Description).MinimumLength(10);
            RuleFor(m => m.Director).NotEmpty();
            RuleFor(m => m.Rating).InclusiveBetween(1,10);
        }
    }
}

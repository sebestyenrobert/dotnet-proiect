using System;
using FluentValidation;
using Lab1.ViewModels;

namespace Lab1.Validators
{
    public class CommentValidator : AbstractValidator<CommentViewModel>
    {
        public CommentValidator()
        {
            RuleFor(c => c.Content).NotEmpty().WithMessage("nem lehet ures a content");
            RuleFor(c => c.DateTime).NotEmpty();
            RuleFor(c => c.Stars).InclusiveBetween(1, 5);
        }
    }
}

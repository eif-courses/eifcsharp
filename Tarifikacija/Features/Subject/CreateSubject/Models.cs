using FastEndpoints;
using FluentValidation;

namespace Tarifikacija.Features.Subject.CreateSubject;

sealed record Request(string Title, string Description);
sealed record Response(string Message);

sealed class Validator : Validator<Request>
{
    public Validator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title cannot be empty!");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description cannot be empty!");
    }
}



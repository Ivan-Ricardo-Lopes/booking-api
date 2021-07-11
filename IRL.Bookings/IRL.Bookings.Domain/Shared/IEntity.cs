using FluentValidation;
using FluentValidation.Results;
using System;

namespace IRL.Bookings.Domain.Shared
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool Valid { get; set; }
        ValidationResult ValidationResult { get; set; }

        bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator);
    }
}
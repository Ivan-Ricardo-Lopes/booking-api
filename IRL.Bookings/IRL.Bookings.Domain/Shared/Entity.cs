using FluentValidation;
using FluentValidation.Results;
using System;

namespace IRL.Bookings.Domain.Shared
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; set; }
        public bool Valid { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
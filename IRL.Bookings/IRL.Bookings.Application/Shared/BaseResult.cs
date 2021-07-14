using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IRL.Bookings.Application.Shared
{
    public class BaseResult<T>
    {
        public BaseResult()
        {
            this.Payload = (T)Activator.CreateInstance(typeof(T));
        }

        public T Payload { get; set; }
        public Dictionary<string, List<string>> Errors { get; set; } = new Dictionary<string, List<string>>();
        public bool IsValid => !Errors.Any();

        public void AddError(string property, string error)
        {
            //Errors.Add(property, error);
        }

        public void AddErrors(ValidationResult validationResult)
        {
            if (validationResult != null)
            {
                foreach (var item in validationResult.Errors)
                {
                    //this.Errors.Add(item.PropertyName, item.ErrorMessage);
                }
            }
        }
    }
}
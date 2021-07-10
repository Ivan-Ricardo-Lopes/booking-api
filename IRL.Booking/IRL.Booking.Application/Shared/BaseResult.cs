using System;
using System.Collections.Generic;
using System.Linq;

namespace IRL.Booking.Application.Shared
{
    public class BaseResult<T>
    {
        public BaseResult()
        {
            this.Payload = (T)Activator.CreateInstance(typeof(T));
        }

        public BaseResult(ICollection<string> errors)
        {
            Errors = errors;
        }

        public T Payload { get; set; }
        public ICollection<string> Errors { get; set; } = new List<string>();
        public bool IsSuccess => !Errors.Any();

        public void AddError(string error)
        {
            Errors.Add(error);
        }
    }
}
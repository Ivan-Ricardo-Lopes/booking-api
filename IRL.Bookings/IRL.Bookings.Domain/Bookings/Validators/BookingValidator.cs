using FluentValidation;
using IRL.Bookings.Domain.Bookings.Entities;
using System;

namespace IRL.Bookings.Domain.Bookings.Validators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator()
        {
            RuleFor(x => x.RoomId).NotEmpty();
            RuleFor(x => x.FromDate).NotEmpty();
            RuleFor(x => x.ToDate).NotEmpty();
            RuleFor(x => x.CustomerName).NotEmpty();

            RuleFor(x => x.ToDate)
                .GreaterThan(x => x.FromDate);

            RuleFor(x => x.FromDate).Must(fromDate =>
              ValidateFromDate(fromDate))
              .WithMessage("FromDate must be greater or equal than current date.");

            RuleFor(x => x.ToDate).Must(toDate =>
              ValidateToDate(toDate))
              .WithMessage("ToDate must be greater than current date.");

            RuleFor(x => x.FromDate).Must((booking, fromDate) =>
                ValidateMaximumStays(booking.ToDate, fromDate))
                .WithMessage("The stay can’t be longer than 3 days.");

            RuleFor(x => x.ToDate).Must(toDate =>
               ValidateBookingAdvanceLimit(toDate))
               .WithMessage("Can’t be reserved more than 30 days in advance.");
        }
        private bool ValidateToDate(DateTime toDate)
        {
            var currentDate = DateTime.UtcNow.Date;
            return toDate.Date > currentDate.Date;
        }
        private bool ValidateFromDate(DateTime fromDate)
        {
            var currentDate = DateTime.UtcNow.Date;
            return fromDate.Date >= currentDate.Date;
        }

        private bool ValidateBookingAdvanceLimit(DateTime toDate)
        {
            var currentDate = DateTime.UtcNow.Date;
            return (toDate.Date - currentDate).TotalDays <= 30;
        }

        private bool ValidateMaximumStays(DateTime toDate, DateTime fromDate)
        {
            return (fromDate.Date - toDate.Date).TotalDays <= 3;
        }
    }
}
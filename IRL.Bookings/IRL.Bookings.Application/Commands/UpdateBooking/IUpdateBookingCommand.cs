using IRL.Bookings.Application.Commands.CreateBooking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.Commands.UpdateBooking
{
    public interface IUpdateBookingCommand :  ICreateBookingCommand
    {
        public Guid Id { get; set; }
    }
}

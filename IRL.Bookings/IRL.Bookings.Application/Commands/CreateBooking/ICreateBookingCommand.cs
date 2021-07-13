using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRL.Bookings.Application.Commands.CreateBooking
{
    public interface ICreateBookingCommand
    {
        public Guid RoomId { get; set; }
        public string CustomerName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}

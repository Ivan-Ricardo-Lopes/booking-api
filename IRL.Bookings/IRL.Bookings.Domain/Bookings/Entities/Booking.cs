using IRL.Bookings.Domain.Bookings.Validators;
using IRL.Bookings.Domain.Shared;
using System;

namespace IRL.Bookings.Domain.Bookings.Entities
{
    public class Booking : Entity, IEntity
    {
        public Booking(Guid id, DateTime fromDate, DateTime toDate, Guid roomId, string customerName)
        {
            Id = id;
            RoomId = roomId;
            CustomerName = customerName;
            FromDate = fromDate;
            ToDate = toDate;

            this.Validate(this, new BookingValidator());
        }

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public Guid RoomId { get; private set; }
        public string CustomerName { get; private set; }

        public void ModifyDates(DateTime fromDate, DateTime toDate)
        {
            this.FromDate = fromDate;
            this.ToDate = toDate;
            this.Validate(this, new BookingValidator());
        }

        public void ChangeRoom(Guid roomid)
        {
            this.RoomId = roomid;
            this.Validate(this, new BookingValidator());
        }

        public void ChangeCustomer(string customerName)
        {
            this.CustomerName = customerName;
            this.Validate(this, new BookingValidator());
        }
    }
}
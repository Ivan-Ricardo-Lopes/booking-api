using IRL.Bookings.Domain.Bookings.ValueObjects;
using IRL.Bookings.Domain.Shared;
using System;

namespace IRL.Bookings.Domain.Bookings.Entities
{
    public class Booking : Entity, IEntity
    {
        public Booking(Guid id, DateTime fromDate, DateTime toDate, Guid roomId, CustomerInfo customerInfo)
        {
            Id = id;
            RoomId = roomId;
            CustomerInfo = customerInfo;
            FromDate = fromDate;
            ToDate = toDate;
        }

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
        public Guid RoomId { get; private set; }
        public CustomerInfo CustomerInfo { get; private set; }

        public void ModifySchedule(DateTime startDate, DateTime endDate)
        {
            //var currentDate = DateTime.UtcNow.Date;
            //var limitAdvanceDate = currentDate.AddDays(30);

            //if (startDate < currentDate || startDate < Schedule.StartDate)
            //{
            //    //invalida start date
            //}

            //if (Schedule.EndDate.Date <= currentDate)
            //{
            //    //cannot modify an completed booking
            //}

            //if (endDate > Schedule.StartDate.AddDays(3))
            //{
            //    //cannot stay more than 3 days.
            //}

            //Schedule = new Schedule(startDate, endDate);
        }

        public void ChangeCustomerName(string customerName)
        {
            throw new NotImplementedException();
        }
    }
}
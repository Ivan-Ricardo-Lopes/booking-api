using AutoMapper;
using IRL.Booking.API.Transport.Bookings.Cancel;
using IRL.Booking.API.Transport.Bookings.Create;
using IRL.Booking.API.Transport.Bookings.GetAll;
using IRL.Booking.API.Transport.Bookings.Update;
using IRL.Bookings.Application.Commands.CancelBooking;
using IRL.Bookings.Application.Commands.CreateBooking;
using IRL.Bookings.Application.Commands.UpdateBooking;
using IRL.Bookings.Application.Queries.GetBookings;

namespace IRL.Booking.API.AutoMapper
{
    public class APIMapperProfile : Profile
    {
        public APIMapperProfile()
        {
            CreateMap<CreateBookingModel, CreateBookingCommand>();
            CreateMap<UpdateBookingModel, UpdateBookingCommand>();
            CreateMap<CancelBookingModel, CancelBookingCommand>();
            CreateMap<GetAllBookingModel, GetBookingsQuery>();

            CreateMap<CreateBookingResult, CreateBookingResponse>();
            CreateMap<UpdateBookingResult, UpdateBookingResponse>();
            CreateMap<CancelBookingResult, CancelBookingResponse>();
            CreateMap<GetBookingsResult, GetAllBookingResponse>();
        }
    }
}
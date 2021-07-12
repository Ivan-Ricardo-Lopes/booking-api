using AutoMapper;
using IRL.Bookings.Application.Queries.GetBookings;
using IRL.Bookings.Application.Queries.GetRooms;
using IRL.Bookings.Domain.Bookings.Entities;
using IRL.Bookings.Domain.Rooms.Entities;
using IRL.Bookings.Infra.DatabaseModels;

namespace IRL.Bookings.Application.AutoMapper
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Booking, BookingDbModel>().ReverseMap();
            CreateMap<Room, RoomDbModel>().ReverseMap();
            CreateMap<BookingDbModel, BookingsResultItem>();
            CreateMap<RoomDbModel, RoomsResultItem>();
        }
    }
}
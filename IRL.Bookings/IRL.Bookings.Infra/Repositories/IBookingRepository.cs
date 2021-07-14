using IRL.Bookings.Infra.DatabaseModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace IRL.Bookings.Infra.Repositories
{
    public interface IBookingRepository
    {
        Task<BookingDbModel> GetById(string id);

        Task<IQueryable<BookingDbModel>> GetAll(string roomId = null);

        Task<bool> ExistsBetweenDates(string roomId, DateTime fromDate, DateTime toDate, string notIncludingId = null);

        Task Add(BookingDbModel model);

        Task Update(BookingDbModel model);

        Task Delete(BookingDbModel model);

        Task SaveChanges();
    }
    
}
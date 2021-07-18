using IRL.Bookings.Infra.DatabaseModels;
using System.Linq;
using System.Threading.Tasks;

namespace IRL.Bookings.Infra.Repositories
{
    public interface IBookingRepository
    {
        Task<BookingDbModel> GetById(string id);

        Task<IQueryable<BookingDbModel>> GetAll(string roomId = null);

        Task Add(BookingDbModel model);

        Task Update(BookingDbModel model);

        Task Delete(BookingDbModel model);

        Task SaveChanges();
    }
}
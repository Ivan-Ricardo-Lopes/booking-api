using IRL.Bookings.Infra.DatabaseModels;
using IRL.Bookings.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace IRL.Bookings.Infra.Databases.EntityFramework.Repositories
{
    public class EFBookingRepository : IBookingRepository
    {
        private readonly AppDbContext _db;

        public EFBookingRepository(AppDbContext db)
        {
            this._db = db;
        }

        public Task<IQueryable<BookingDbModel>> GetAll(string roomId = null)
        {
            var result = _db.Bookings
                .Where(x => roomId != null ? x.RoomId == roomId : true)
                .AsNoTracking()
                .AsQueryable();

            return Task.FromResult(result);
        }

        public async Task<BookingDbModel> GetById(string id)
        {
            return await _db.Bookings.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Add(BookingDbModel model)
        {
            await _db.AddAsync(model);
        }

        public Task Update(BookingDbModel model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Task.FromResult(_db.Bookings.Update(model));
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }

        public Task Delete(BookingDbModel model)
        {
            return Task.FromResult(_db.Bookings.Remove(model));
        }
    }
}
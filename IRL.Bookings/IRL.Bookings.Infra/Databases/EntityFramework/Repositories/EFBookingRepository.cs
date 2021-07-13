using IRL.Bookings.Infra.DatabaseModels;
using IRL.Bookings.Infra.Repositories;
using System;
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

        public Task<bool> ExistsBetweenDates(string roomId, DateTime fromDate, DateTime toDate, string notIncludingId = null)
        {
            return Task.FromResult(_db.Bookings
                .Where(x => x.Id != notIncludingId)
                .Where(x => x.RoomId == roomId)
                .Any(x => ((fromDate >= x.FromDate && fromDate <= x.ToDate) ||
                (toDate >= x.FromDate && toDate <= x.ToDate))));
        }

        public Task<IQueryable<BookingDbModel>> GetAll(string roomId = null)
        {
            var result = _db.Bookings
                .Where(x => roomId != null ? x.RoomId == roomId : true)
                .AsQueryable();

            return Task.FromResult(result);
        }

        public async Task<BookingDbModel> GetById(string id)
        {
            return await _db.Bookings.FindAsync(id);
        }

        public async Task Add(BookingDbModel model)
        {
            await _db.AddAsync(model);
        }

        public Task Update(BookingDbModel model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return Task.FromResult(_db.Update(model));
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
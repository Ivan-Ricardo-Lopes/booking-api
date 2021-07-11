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

        public Task<bool> ExistsBetweenDates(string roomId, DateTime fromDate, DateTime toDate)
        {
            return Task.FromResult(_db.Bookings
           .Any(x => x.RoomId == roomId &&
           ((fromDate >= x.FromDate && fromDate <= x.ToDate) ||
            (toDate >= x.FromDate && toDate <= x.ToDate))));
        }

        public Task<IQueryable<BookingDbModel>> GetAll()
        {
            return Task.FromResult(_db.Bookings.AsQueryable());
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
            return Task.FromResult(_db.Update(model));
        }

        public async Task SaveChanges()
        {
            await _db.SaveChangesAsync();
        }
    }
}
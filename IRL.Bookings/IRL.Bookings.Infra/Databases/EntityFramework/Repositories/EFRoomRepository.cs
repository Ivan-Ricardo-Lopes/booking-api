using IRL.Bookings.Infra.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace IRL.Bookings.Infra.Databases.EntityFramework.Repositories
{
    public class EFRoomRepository : IRoomRepository
    {
        private readonly AppDbContext _db;

        public EFRoomRepository(AppDbContext db)
        {
            this._db = db;
        }

        public Task<bool> Exists(string roomId)
        {
            return Task.FromResult(this._db.Rooms.Any(x => x.Id == roomId));
        }
    }
}
using IRL.Bookings.Infra.DatabaseModels;
using System.Linq;
using System.Threading.Tasks;

namespace IRL.Bookings.Infra.Repositories
{
    public interface IRoomRepository
    {
        Task<IQueryable<RoomDbModel>> GetAll();

        Task<bool> Exists(string roomId);
    }
}
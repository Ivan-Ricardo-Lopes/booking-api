using System.Threading.Tasks;

namespace IRL.Bookings.Infra.Repositories
{
    public interface IRoomRepository
    {
        Task<bool> Exists(string roomId);
    }
}
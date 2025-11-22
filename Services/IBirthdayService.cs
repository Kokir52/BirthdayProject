using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Services
{
    public interface IBirthdayService
    {
        Task<IEnumerable<Birthday>> GetAll();
        Task<IEnumerable<Birthday>> FindByName(string name);
        Task<IEnumerable<Birthday>> Add(Birthday b);
        Task<bool> Remove(string name);
        Task<IEnumerable<Birthday>> GetUpcomingBirthdays();
        Task<IEnumerable<Birthday>> GetBirthdaysByMonth(int month);
    }
}

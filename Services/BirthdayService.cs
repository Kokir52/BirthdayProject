using RodjendaniProjekat.Models;
using RodjendaniProjekat.DB;
using Microsoft.EntityFrameworkCore;

namespace RodjendaniProjekat.Services
{
    public class BirthdayService : IBirthdayService
    {
        private readonly BirthdayDb _context;

        public BirthdayService(BirthdayDb context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Birthday>> GetAll() => await _context.Birthdays.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Birthday>> FindByName(string name) =>
            await _context.Birthdays
                .Where(p => EF.Functions.Like(p.FirstName, $"{name}%"))
                .AsNoTracking()
                .ToListAsync();

        public async Task<IEnumerable<Birthday>> Add(Birthday p)
        {
            _context.Birthdays.Add(p);
            _context.SaveChanges();
            var birthdays = await _context.Birthdays.ToListAsync();
            return _context.Birthdays;
        }

        public async Task<bool> Remove(string name)
        {
            var person = _context.Birthdays.FirstOrDefault(p => p.FirstName == name);
            if (person == null) return false;

            _context.Birthdays.Remove(person);
            _context.SaveChanges();
            var birthdays = await _context.Birthdays.ToListAsync();
            return true;
        }


        public async Task<IEnumerable<Birthday>> GetUpcomingBirthdays()
        {
            var today = DateTime.Today;

            var birthdays = await _context.Birthdays
                .AsNoTracking()
                .ToListAsync();

            return birthdays
                .OrderBy(b =>
                {
                    var nextBirthday = new DateTime(today.Year, b.Month, b.Day);
                    if (nextBirthday < today)
                        nextBirthday = nextBirthday.AddYears(1);
                    return (nextBirthday - today).Days;
                })
                .ToList();
        }

        public async Task<IEnumerable<Birthday>> GetBirthdaysByMonth(int month)
        {
            return await _context.Birthdays
                .AsNoTracking()
                .Where(b => b.Month == month)
                .OrderBy(b => b.Day)
                .ToListAsync();
        }
    }
}


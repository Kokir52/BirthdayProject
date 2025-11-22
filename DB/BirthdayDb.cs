using Microsoft.EntityFrameworkCore;
using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.DB
{
    public class BirthdayDb : DbContext
    {
        public BirthdayDb(DbContextOptions<BirthdayDb> options) : base(options) { }

        public DbSet<Birthday> Birthdays { get; set; }
    }
}

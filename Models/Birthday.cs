namespace RodjendaniProjekat.Models
{
    public class Birthday
    {
        public int Id { get; set; }  // Primary key

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public Birthday() { }

        public Birthday(string firstName, string lastName, int day, int month, int year)
        {
            FirstName = firstName;
            LastName = lastName;
            Day = day;
            Month = month;
            Year = year;
        }
    }
}


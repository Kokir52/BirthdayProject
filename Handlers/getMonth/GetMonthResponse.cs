using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Handlers.getMonth
{
    public class GetMonthResponse
    {
        private IEnumerable<Birthday> birthdays;

        public GetMonthResponse(IEnumerable<Birthday> birthdays)
        {
            this.birthdays = birthdays;
        }

        public IEnumerable<Birthday> GetBirthdays()
        {
            return birthdays;
        }
    }
}

using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Handlers.getAll
{
    public class getAllResponse
    {
        private IEnumerable<Birthday> birthdays;

        public getAllResponse(IEnumerable<Birthday> birthdays)
        {
            this.birthdays = birthdays;
        }

        public IEnumerable<Birthday> GetBirthdays()
        {
            return birthdays;
        }
    }
}

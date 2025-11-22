using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Handlers.getSorted
{
    public class GetSortedResponse
    {
        private IEnumerable<Birthday> birthdays;

        public GetSortedResponse(IEnumerable<Birthday> birthdays)
        {
            this.birthdays = birthdays;
        }

        public IEnumerable<Birthday> GetBirthdays()
        {
            return birthdays;
        }
    }
}

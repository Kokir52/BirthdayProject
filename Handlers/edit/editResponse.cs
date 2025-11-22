using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Handlers.edit
{
    public class editResponse
    {
        private IEnumerable<Birthday> birthdays;

        public editResponse(IEnumerable<Birthday> birthdays)
        {
            this.birthdays = birthdays;
        }

        public IEnumerable<Birthday> getBirthday()
        {
            return this.birthdays;
        }
    }
}

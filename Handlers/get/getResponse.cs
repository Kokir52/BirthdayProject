using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Handlers.get
{
    public class getResponse
    {
        private IEnumerable<Birthday> birthdays;

        public getResponse(IEnumerable<Birthday> birthdays)
        {
            this.birthdays = birthdays;
        }

        public IEnumerable<Birthday> getBirthday()
        {
            return this.birthdays;
        }
    }
}

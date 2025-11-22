using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Handlers.addBirthday
{
    public class addBirthdayRequest : IRequest<addBirthdayResponse>
    {
        private Birthday birthday;
        public addBirthdayRequest(Birthday birthday)
        {
            this.birthday = birthday;
        }

        public Birthday getBirthday()
        {
            return birthday;
        }
    }
}

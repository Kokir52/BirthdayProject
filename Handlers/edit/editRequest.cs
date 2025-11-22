using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Handlers.edit
{
    public class editRequest : IRequest<editResponse>
    {
        private Birthday birthday;
        public editRequest(Birthday birthday)
        {
            this.birthday = birthday;
        }

        public Birthday getBirthday()
        {
            return birthday;
        }
    }
}

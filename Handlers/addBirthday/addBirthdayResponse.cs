using RodjendaniProjekat.Models;

namespace RodjendaniProjekat.Handlers.addBirthday
{
    public class addBirthdayResponse
    {
        private Birthday responseCode;

        public addBirthdayResponse(Birthday response)
        {
            this.responseCode = response;
        }

        public Birthday getResponseCode() { return responseCode; }
    }
}

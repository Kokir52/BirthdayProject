using RodjendaniProjekat.Services;

namespace RodjendaniProjekat.Handlers.addBirthday
{
    public class addBirthdayHandler : IHandler<addBirthdayRequest, addBirthdayResponse>
    {
        private readonly IBirthdayService birthdayService;

        public addBirthdayHandler(IBirthdayService birthdayService)
        {
            this.birthdayService = birthdayService;
        }

        public async Task<addBirthdayResponse> Handle(addBirthdayRequest request)
        {
            var birthday = await birthdayService.Add(request.getBirthday());
            return new addBirthdayResponse(request.getBirthday());
        }
    }
}

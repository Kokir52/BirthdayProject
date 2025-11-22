using RodjendaniProjekat.Services;

namespace RodjendaniProjekat.Handlers.getAll
{
    public class getAllHandler : IHandler<getAllRequest, getAllResponse>
    {
        private readonly IBirthdayService _birthdayService;

        public getAllHandler(IBirthdayService birthdayService)
        {
            _birthdayService = birthdayService;
        }

        public async Task<getAllResponse> Handle(getAllRequest request)
        {
            return new getAllResponse(await _birthdayService.GetAll());
        }


    }
}

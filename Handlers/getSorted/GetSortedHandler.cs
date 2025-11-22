using RodjendaniProjekat.Services;

namespace RodjendaniProjekat.Handlers.getSorted
{
    public class GetSortedHandler : IHandler<GetSortedRequest, GetSortedResponse>
    {
        private readonly IBirthdayService _birthdayService;

        public GetSortedHandler(IBirthdayService birthdayService)
        {
            _birthdayService = birthdayService;
        }

        public async Task<GetSortedResponse> Handle(GetSortedRequest request)
        {
            var birthdays = await _birthdayService.GetUpcomingBirthdays();
            return new GetSortedResponse(birthdays);
        }
    }
}

using RodjendaniProjekat.Services;

namespace RodjendaniProjekat.Handlers.getMonth
{
    public class GetMonthHandler : IHandler<GetMonthRequest, GetMonthResponse>
    {
        private readonly IBirthdayService _birthdayService;

        public GetMonthHandler(IBirthdayService birthdayService)
        {
            _birthdayService = birthdayService;
        }

        public async Task<GetMonthResponse> Handle(GetMonthRequest request)
        {
            int month = request.getMonth();
            
            return new GetMonthResponse(await _birthdayService.GetBirthdaysByMonth(month));
        }
    }
}

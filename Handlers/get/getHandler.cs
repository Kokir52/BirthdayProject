using RodjendaniProjekat.Models;
using RodjendaniProjekat.Services;

namespace RodjendaniProjekat.Handlers.get
{
    public class getHandler : IHandler<getRequest, getResponse>
    {
        private readonly IBirthdayService birthdayService;

        public getHandler(IBirthdayService birthdayService)
        {
            this.birthdayService = birthdayService;
        }

        public async Task<getResponse> Handle(getRequest request)
        {
            string name = request.getName();
            IEnumerable<Birthday> birthdays = await birthdayService.FindByName(name);
            return new getResponse(birthdays);
        }
    }
}

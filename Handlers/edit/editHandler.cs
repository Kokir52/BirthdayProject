using RodjendaniProjekat.Models;
using RodjendaniProjekat.Services;

namespace RodjendaniProjekat.Handlers.edit
{
    public class editHandler : IHandler<editRequest, editResponse>
    {
        private readonly IBirthdayService birthdayService;

        public editHandler(IBirthdayService birthdayService)
        {
            this.birthdayService = birthdayService;
        }
        public async Task<editResponse> Handle(editRequest request)
        {
            Birthday newBirthday = request.getBirthday();
            var removed = await birthdayService.Remove(newBirthday.FirstName);
            var throwaway = await birthdayService.Add(newBirthday);
            return new editResponse(await birthdayService.FindByName(newBirthday.FirstName));
        }
    }
}

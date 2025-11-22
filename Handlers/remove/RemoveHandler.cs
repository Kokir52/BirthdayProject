using RodjendaniProjekat.Services;

namespace RodjendaniProjekat.Handlers.remove
{
    public class RemoveHandler : IHandler<RemoveRequest, RemoveResponse>
    {
        private readonly IBirthdayService birthdayService;
        public RemoveHandler(IBirthdayService birthdayService) 
        {
            this.birthdayService = birthdayService;
        }
        public async Task<RemoveResponse> Handle(RemoveRequest request)
        {
            string name = request.getName();
            bool is_removed = await birthdayService.Remove(name);
            return new RemoveResponse(is_removed);
        }
    }
}

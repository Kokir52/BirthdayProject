namespace RodjendaniProjekat.Handlers.remove
{
    public class RemoveRequest : IRequest<RemoveResponse>
    {
        private string name;

        public RemoveRequest(string name)
        {
            this.name = name;
        }

        public string getName() { return name; }
    }
}

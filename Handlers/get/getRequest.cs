namespace RodjendaniProjekat.Handlers.get
{
    public class getRequest : IRequest<getResponse>
    {
        private string name;

        public getRequest(string name)
        {
            this.name = name;
        }

        public string getName() { return name; }
    }
}

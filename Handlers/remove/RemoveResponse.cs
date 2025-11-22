namespace RodjendaniProjekat.Handlers.remove
{
    public class RemoveResponse
    {
        private bool response;

        public RemoveResponse(bool responseCode) { this.response = responseCode; }

        public bool getResponseCode() { return response; }
    }
}

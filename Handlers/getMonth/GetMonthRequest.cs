namespace RodjendaniProjekat.Handlers.getMonth
{
    public class GetMonthRequest : IRequest<GetMonthResponse>
    {
        private int month;

        public GetMonthRequest(int month)
        {
            this.month = month;
        }

        public int getMonth() { return month; }

    }
}

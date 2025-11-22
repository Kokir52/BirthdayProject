namespace RodjendaniProjekat.Handlers
{
    public interface IHandler<TRequest,  TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}

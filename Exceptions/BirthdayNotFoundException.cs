namespace RodjendaniProjekat.Exceptions
{
    public class BirthdayNotFoundException : Exception
    {
       
        public BirthdayNotFoundException(string name)
            : base($"Birthday for '{name}' was not found.") { }
       
    }
}

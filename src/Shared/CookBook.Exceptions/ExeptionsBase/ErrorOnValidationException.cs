namespace CookBook.Exceptions.ExeptionsBase
{
    public class ErrorOnValidationException : CookBookExceptions
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages) { ErrorMessages = errorMessages; }
    }
}

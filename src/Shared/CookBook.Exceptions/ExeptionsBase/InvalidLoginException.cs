namespace CookBook.Exceptions.ExeptionsBase
{
    public class InvalidLoginException : CookBookExceptions
    {
        public InvalidLoginException() : base(ResourceMessagesException.EMAIL_OR_PASSWORD_INVALID)
        {
        }
    }
}

namespace Task3.Exceptions
{
    public class ErrorHandler
    {
        public static string GetErrorMessage(BaseException e)
        {
            return e.Message;
        }
    }
}

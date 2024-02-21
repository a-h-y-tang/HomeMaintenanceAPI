namespace HomeMaintenance.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}

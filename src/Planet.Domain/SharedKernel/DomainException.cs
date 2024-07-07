namespace Planet.Domain.SharedKernel
{
    public class DomainException : Exception
    {
        public string Code { get; init; }

        public DomainException(string code, string message) : base(message)
        {
            Code = code;
        }

        public DomainException(string code, string message, Exception innerException) : base(message, innerException)
        {
            Code = code;
        }
    }
}

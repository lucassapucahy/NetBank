namespace NetBank.SharedPackages.Model
{
    public class DomainResult<T>
    {
        public T? ResultObject { get; private set; }
        public bool Success { get; private set; }
        public List<string>? ErrorMessages { get; private set; }

        public static DomainResult<T> CreateSuccess(T resultObject) 
        {
            return new DomainResult<T> { ResultObject = resultObject, Success = true };
        }

        public static DomainResult<T> CreateFailure(List<string> errorMessages)
        {
            return new DomainResult<T> { ErrorMessages = new List<string>(errorMessages), Success = false };
        }
    }
}

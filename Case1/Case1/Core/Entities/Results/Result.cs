namespace Case1.Core.Entities.Results
{
    public class Result : IResultt
    {
        public Result(bool success, string message) : this(success)
        {
            Message = message;
            //Success = success;  yerine this(success) yazdık
        }
        public Result(bool success, int message) : this(success)
        {
            intMessage = message;
           
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }
        public string Message { get; }
        public int intMessage { get; }

    }
}

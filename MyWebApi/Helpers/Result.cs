namespace MyWebApi.Helpers
{
    public class Result
    {
        public bool IsValid { get; set; }

        public Result(bool isValid)
        {
            IsValid = isValid;
        }
    }
}

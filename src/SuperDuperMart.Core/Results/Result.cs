namespace SuperDuperMart.Core.Results
{
    public class Result
    {
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; } = default!;

        public Result()
        {
        }

        public Result(bool success)
        {
            Success = success;
        }

        public Result(bool success, IEnumerable<string> errors)
        {
            Success = success;
            Errors = errors;
        }

        public static Result Ok() => new Result(success: true);
        public static Result Failure(List<string> errors) => new Result(success: false, errors);
    }
}

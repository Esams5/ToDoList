namespace ToDoList.API.ViewModels
{
    public class ResultViewModel
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }

        public static ResultViewModel ApplicationErrorMessage()
        {
            return new ResultViewModel
            {
                Message = "Ocorreu um erro interno na aplicação, por favor, tente novamente!",
                Success = false,
                Data = null
            };
        }

        public static ResultViewModel DomainErrorMessage(string message, IReadOnlyCollection<string> errors)
        {
            return new ResultViewModel
            {
                Message = message,
                Success = false,
                Data = errors
            };
        }
    }
}
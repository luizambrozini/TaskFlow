namespace TaskFlow.Application.Exceptions.ExceptionsBase
{
    public class ErrorOnDeleteException : TaskFlowException
    {
        public string Error { get; set; } = string.Empty;
        public ErrorOnDeleteException(string errorMesage)
        {
            Error = errorMesage;
        }
    }
}

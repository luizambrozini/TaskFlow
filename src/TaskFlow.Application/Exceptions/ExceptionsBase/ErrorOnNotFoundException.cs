namespace TaskFlow.Application.Exceptions.ExceptionsBase
{
    public class ErrorOnNotFoundException : TaskFlowException
    {
        public string Error { get; set; } = string.Empty;
        public ErrorOnNotFoundException(string errorMesage)
        {
            Error = errorMesage;
        }
    }
}

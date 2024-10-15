namespace TaskFlow.Application.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException : TaskFlowException
    {
        public List<string> Errors { get; set; } = [];
        public ErrorOnValidationException(List<string> errorMesages)
        {
            Errors = errorMesages;
        }
    }
}

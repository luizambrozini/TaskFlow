namespace TaskFlow.Comunication.Responses
{
    public class ResponseErrorJson
    {
        public List<string> ErrorMessage { get; set; }

        public ResponseErrorJson(List<string> errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public ResponseErrorJson(string errorMessage)
        {
            ErrorMessage = [errorMessage];
        }
    }
}

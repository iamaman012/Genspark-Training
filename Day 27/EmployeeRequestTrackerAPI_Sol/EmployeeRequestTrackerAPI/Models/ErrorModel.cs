namespace EmployeeRequestTrackerAPI.Models
{
    public class ErrorModel
    {
        int ErrorCode { get; set; }
        string ErrorMessage { get; set; }

        public ErrorModel(int errorCode, string errorMessage)
        {
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}

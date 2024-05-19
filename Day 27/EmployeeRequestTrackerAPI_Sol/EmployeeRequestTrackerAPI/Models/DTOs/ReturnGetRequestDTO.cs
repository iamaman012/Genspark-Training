namespace EmployeeRequestTrackerAPI.Models.DTOs
{
    public class ReturnGetRequestDTO
    {
        public int RequestId { get; set; }
        public int RequestRaisedBy { get; set; }
        public string RequestMessage { get; set; }
        public string Status { get; set; }
        public int? RequestClosedBy { get; set; }    
    }
}

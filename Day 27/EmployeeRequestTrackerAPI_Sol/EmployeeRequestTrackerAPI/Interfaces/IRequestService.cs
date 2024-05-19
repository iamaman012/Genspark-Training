using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Interfaces
{
    public interface IRequestService
    {
        public Task<ReturnRequestDTO> RaiseRequest(RequestRaisedDTO requestDTO);
        public Task<IEnumerable<ReturnRequestDTO>> GetRequest(GetRequestDTO getRequestDTO);

    }
}

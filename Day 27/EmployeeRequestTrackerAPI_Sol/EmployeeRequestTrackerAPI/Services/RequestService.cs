using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;

namespace EmployeeRequestTrackerAPI.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _requestRepo;
        private readonly IRepository<int,Employee> _employeeRepo;

        public RequestService(IRepository<int,Request> requestRepo,IRepository<int,Employee> employeeRepo) {
            _employeeRepo = employeeRepo;
            _requestRepo = requestRepo;
        }

        public  async Task<IEnumerable<ReturnRequestDTO>> GetRequest(GetRequestDTO getRequestDTO)
        {
            try
            {
                var employee = await _employeeRepo.Get(getRequestDTO.EmployeeId);
                if (employee == null)
                {
                    throw new Exception("Employee not found");
                }
                if (employee.Role == "Admin")
                {
                    var requests = await _requestRepo.Get();
                    List<ReturnRequestDTO> returnRequestDTOs = new List<ReturnRequestDTO>();
                    foreach (var request in requests)
                    {
                        ReturnRequestDTO returnRequestDTO = new ReturnRequestDTO() { RequestId = request.RequestNumber, RequestMessage = request.RequestMessage, RequestStatus = request.RequestStatus, RequestRaisedBy = request.RequestRaisedBy, RequestClosedBy = request.RequestClosedBy, RequestDate = request.RequestDate, ClosedDate = request.ClosedDate };
                        returnRequestDTOs.Add(returnRequestDTO);
                    }
                    return returnRequestDTOs;
                }
                else
                {
                    var requests = await _requestRepo.Get();
                    requests = requests.Where(r => r.RequestRaisedBy == getRequestDTO.EmployeeId);
                    List<ReturnRequestDTO> returnRequestDTOs = new List<ReturnRequestDTO>();
                    foreach (var request in requests)
                    {
                        ReturnRequestDTO returnRequestDTO = new ReturnRequestDTO() { RequestId = request.RequestNumber, RequestMessage = request.RequestMessage, RequestStatus = request.RequestStatus, RequestRaisedBy = request.RequestRaisedBy, RequestClosedBy = request.RequestClosedBy, RequestDate = request.RequestDate, ClosedDate = request.ClosedDate };
                        returnRequestDTOs.Add(returnRequestDTO);
                    }
                    return returnRequestDTOs;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ReturnRequestDTO> RaiseRequest(RequestRaisedDTO requestDTO)
        {
            try
            {
                var employee = await _employeeRepo.Get(requestDTO.EmployeeId);
                if(employee==null)
                {
                    throw new Exception("Employee not found");
                }
                Request request = new Request() { RequestMessage = requestDTO.RequestMessage, RequestStatus="Open",RequestRaisedBy=requestDTO.EmployeeId };
                var result = await _requestRepo.Add(request);

                if(result == null)
                {
                    throw new Exception("Request not raised");
                }
                ReturnRequestDTO returnRequestRaisedDTO = new ReturnRequestDTO() { RequestId = result.RequestNumber, RequestMessage = result.RequestMessage, RequestStatus = result.RequestStatus, RequestRaisedBy = result.RequestRaisedBy,RequestClosedBy=result.RequestClosedBy,
                    RequestDate=result.RequestDate,ClosedDate=result.ClosedDate };
                return returnRequestRaisedDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

using EmployeeRequestTrackerAPI.Interfaces;
using EmployeeRequestTrackerAPI.Models;
using EmployeeRequestTrackerAPI.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeRequestTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        [Authorize]
        [HttpPost("RaiseRequest")]
        [ProducesResponseType(typeof(ReturnRequestDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ReturnRequestDTO>> RaiseRequest(RequestRaisedDTO requestDTO)
        {
            try
            {
                var result = await _requestService.RaiseRequest(requestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }
        [Authorize]
        [HttpPost("GetRequest")]
        [ProducesResponseType(typeof(IEnumerable<ReturnRequestDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ReturnRequestDTO>>> GetRequest(GetRequestDTO getRequestDTO)
        {
            try
            {
                var result = await _requestService.GetRequest(getRequestDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorModel(400, ex.Message));
            }
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using BusinessAccessLayer.Services.BusinessRequestBlood;

namespace BloodBankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestBlood_Controller : ControllerBase
    {

        public IServiceRequestBlood _IserviceRequestBlood;
        public RequestBlood_Controller(IServiceRequestBlood serviceRequestBlood)
        {
            _IserviceRequestBlood = serviceRequestBlood;
        }

        // To enter the request details in the 'requestBlood' Table when a request for blood is performed 
        [HttpPost("/SaveRequestDetailsToDB")]
        [Authorize(Roles = "Requestor")]
        public IActionResult SaveRequestDetailsToDB(RequestBlood request)
        {
            try
            {
                _IserviceRequestBlood.RequestForBlood(request);
                    return Ok("Blood Request successfully submitted.");
               
            }
            catch (Exception ex)
            {
               
                
                    return BadRequest("Error occurred while making the blood request" + ex.Message);

                
            }
        }

        // To get the requestor status of a specific Requestor from 'requestStatus' Table
        [HttpGet("{requestorId}")]
        [Authorize(Roles = "Requestor")]
        public IActionResult GetRequestorStatus(string requestorId)
        {
            try
            {
                var rs =  _IserviceRequestBlood.GetRequestStatuses(requestorId);
               
                return Ok(rs);
                
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Value cannot be null"))
                {
                    return BadRequest("The Requestor Id Does not exists");
                }
                else
                {
                    return BadRequest("Error:" + ex.Message);
                }
            }
        }

    }
}

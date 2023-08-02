using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using DataAccessLayer.Models;
using BusinessAccessLayer.Services.ApproveReject;

namespace BloodBankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateStatusInfo_Controller : ControllerBase
    {

        public IServiceApproveReject _IServiceApproveReject;
        public UpdateStatusInfo_Controller(IServiceApproveReject ServiceApproveReject)
        {
            _IServiceApproveReject = ServiceApproveReject;
        }

        // Controller which takes requestor id as parameter and returns requestor details list

        [HttpGet("GetRequestorDetails/{requestorId}")]
        [Authorize(Roles = "Requestor")]
        public IActionResult GetRequestorDetails(string requestorId)
        {
            try 
            {
				var rs = _IServiceApproveReject.getreqdetails(requestorId);
				return Ok(rs);
			}
			catch (Exception ex)
			{
                if(ex.Message.Contains("Enter a valid Requestor Id"))
                {
                    return BadRequest("Requestor Id does not exists");
                }
                else
                {
				    return BadRequest("Error Occurred while retrieving the requestor details : " + ex.Message);

                }
			}

		}

        // Controller which takes requestor id and object of the class as parameter and updates the status of requestor

        [HttpPut("SaveRequestorStatusInfoToDB/{requestorId}")]
        [Authorize(Roles = "Requestor")]
        public IActionResult SaveRequestorStatusInfoToDB(string requestorId, string status)
        {
            try
            {
				var ex = _IServiceApproveReject.saverequestorstatusinfotodb(requestorId, status);
                if (ex == "ENTER A VALID REQUESTOR ID")
                {
                    return BadRequest("Please add valid Requestor ID");
                }

                else if (ex == "Error occured while updating the requestor")
                {
                    return BadRequest("Unable to update details");
                }
                else
                {
                    return Ok("Successfully Updated");
                   
                }
            }
            catch(Exception x)
            {
				return BadRequest("Error Occurred while updating the requestor status : " + x.Message);
			}
        }

		// Controller which takes donor id as parameter and returns donor details list

		[HttpGet("GetDonorDetails/{donorId}")]
        [Authorize(Roles = "Donor")]
        public IActionResult GetDonorDetails(string donorId)
        {
            try
            {
                var dr = _IServiceApproveReject.getdonordetails(donorId);
                return Ok(dr);
			}
            catch(Exception ex)
            {
                if (ex.Message.Contains("Enter a valid Donor Id"))
                {
                    return BadRequest("Donor Id does not exists");
                }
                else
                {
                    return BadRequest("Error Occurred while retrieving the donor details : " + ex.Message);
                }
            }
                
        }

	    // Controller which takes donor id and object of the class as parameter and updates the status of donor


		[HttpPut("SaveDonorStatusInfoToDB/{donorId}")]
        [Authorize(Roles = "Donor")]
        public IActionResult SaveDonorStatusInfoToDB(string donorId, string status)
        {
            try
            {
				var ex = _IServiceApproveReject.savedonorstatusinfotodb(donorId, status);
                if (ex == "ENTER A VALID DONOR ID")
                {
                    return BadRequest("Please add valid Donor ID");
                }

                else if (ex == "Error occured while updating the Donor")
                {
                    return BadRequest("Unable to update details");
                }
                else
                {
                    return Ok("Successfully Updated");

                }
			}
            catch(Exception x)
            {
				return BadRequest("Error Occurred while updating the donor status : " + x.Message);

			}
		}
    }
}
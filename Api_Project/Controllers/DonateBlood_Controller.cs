using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using BusinessAccessLayer.Services.DonateBloodAndCheck;

namespace BloodBankManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonateBlood_Controller : ControllerBase
    {



        public IServiceBusinessDonateBloodAndCheck _IServiceBusinessDonateBloodAndCheck;



        public DonateBlood_Controller(IServiceBusinessDonateBloodAndCheck ServiceBusinessBloodAndCheck)
        {
            _IServiceBusinessDonateBloodAndCheck = ServiceBusinessBloodAndCheck;
        }



        /*To insert a donor detils who are donating blood*/
        [HttpPost("/SaveDonateBloodRequestToDB")]
        [Authorize(Roles = "Donor")]
        public IActionResult SaveDonateBloodRequestToDB(DonateBlood donateBlood)
        {
            try
            {
                _IServiceBusinessDonateBloodAndCheck.DonateBloodRequestToDB(donateBlood);
                return Ok("Blood Donor details entered successfully");
            }

            catch(Exception ex)
            {
                if(ex.Message.Contains("conflicted with the FOREIGN KEY constraint"))
                {
                    return BadRequest("The Donor Id Does not exists");

                }
                else
                {

                    return BadRequest("Error:" + ex.Message);
                }
            }
           
        }

        /*To get the donor details with status from the donateblood table */
        [HttpGet("{donorId}")]
        [Authorize(Roles = "Donor")]
        public IActionResult GetDonorStatus(string donorId)
        {
            try
            {
                var DS =_IServiceBusinessDonateBloodAndCheck.DonorStatus(donorId);
                

                var Status = DS.Status;
                var DonorId = DS.DonorId;
                var FullName = DS.FullName;

                if (DonorId == null)
                {
                    throw new Exception("Enter a valid Donor ID");
                }
                else
                {
                    return Ok(new { Status, DonorId, FullName });
                }
            }
            
            catch(Exception ex)
            {
                return BadRequest("Error:" + ex.Message);
            }

        }

    }
}
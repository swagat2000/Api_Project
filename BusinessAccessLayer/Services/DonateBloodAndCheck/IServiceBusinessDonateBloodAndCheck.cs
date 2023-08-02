using DataAccessLayer.Models;



namespace BusinessAccessLayer.Services.DonateBloodAndCheck
{
    public interface IServiceBusinessDonateBloodAndCheck
    {
        public DonateBlood DonateBloodRequestToDB(DonateBlood donateBlood);
        public (string DonorId, string FullName, string Status) DonorStatus(string donorId);
    }
}
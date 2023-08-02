using DataAccessLayer.Models;




namespace DataAccessLayer.Contracts
{
    public interface IDAL_DonateBloodAndCheck_repository
    {
        public DonateBlood SaveDonateBloodRequestToDB(DonateBlood donateBlood);
        public (string DonorId, string FullName, string Status) GetDonorStatus(string donorId);



    }
}
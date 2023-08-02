using DataAccessLayer.Models;



namespace DataAccessLayer.Contracts
{
    public interface IDAL_ApproveReject_repository
    {
        public IEnumerable<Requestor> GetRequestorDetails(string requestorId);
        public string SaveRequestorStatusInfoToDB(string requestorId, string status);
        public IEnumerable<Donor> GetDonorDetails(string donorId);
        public string SaveDonorStatusInfoToDB(string donorId, string status);
    }
}
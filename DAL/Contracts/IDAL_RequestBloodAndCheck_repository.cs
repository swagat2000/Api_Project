using DataAccessLayer.Models;

namespace DataAccessLayer.Contracts
{
    public interface IDAL_RequestBloodAndCheck_repository
    {
        public RequestBlood MakeRequest(RequestBlood request);
        public IEnumerable<RequestStatus> GetRequestorStatus(string requestorId);

    }
}
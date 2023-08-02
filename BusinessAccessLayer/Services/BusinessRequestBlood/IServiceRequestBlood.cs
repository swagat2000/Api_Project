using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services.BusinessRequestBlood
{
    public interface IServiceRequestBlood
    {
        public RequestBlood RequestForBlood(RequestBlood request);
        public IEnumerable<RequestStatus> GetRequestStatuses(string requestorId);

    }
}

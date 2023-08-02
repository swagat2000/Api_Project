using DataAccessLayer.Contracts;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services.BusinessRequestBlood
{
    public class ServiceRequestBlood : IServiceRequestBlood
    {
        public readonly IDAL_RequestBloodAndCheck_repository _iDAL_RequestBloodAndCheck_repository;

        public ServiceRequestBlood(IDAL_RequestBloodAndCheck_repository DAL_RequestBloodAndCheckr_repository)
        {

            _iDAL_RequestBloodAndCheck_repository = DAL_RequestBloodAndCheckr_repository;
        }
        public RequestBlood RequestForBlood(RequestBlood request)
        {
            try
            {

                return _iDAL_RequestBloodAndCheck_repository.MakeRequest(request);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public IEnumerable<RequestStatus> GetRequestStatuses(string requestorId)
        {
            try
            {

                return _iDAL_RequestBloodAndCheck_repository.GetRequestorStatus(requestorId).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }

    }
}
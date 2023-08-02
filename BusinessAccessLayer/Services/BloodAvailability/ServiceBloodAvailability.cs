using DataAccessLayer.Contracts;

namespace BusinessAccessLayer.Services.BloodAvailability
{
    public class ServiceBloodAvailability : IServiceBloodAvailability
    {

        public readonly IDAL_BloodAvailability_repository _iDAL_BloodAvailability_repository;

        public ServiceBloodAvailability(IDAL_BloodAvailability_repository DAL_BloodAvailability_repository)
        {

            _iDAL_BloodAvailability_repository = DAL_BloodAvailability_repository;
        }
        public int GetBloodCount(string bloodGroup)
        {
            try
            {

                return _iDAL_BloodAvailability_repository.GetBloodStatus(bloodGroup);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}

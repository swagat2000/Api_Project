using DataAccessLayer.Contracts;
using DataAccessLayer.Models;



namespace BusinessAccessLayer.Services.DonateBloodAndCheck
{
    public class ServiceBusinessDonateBloodAndCheck : IServiceBusinessDonateBloodAndCheck
    {
        public readonly IDAL_DonateBloodAndCheck_repository _iDAL_BusinessDonateBloodAndCheck_repository;



        public ServiceBusinessDonateBloodAndCheck(IDAL_DonateBloodAndCheck_repository iDAL_BusinessDonateBloodAndCheck_repository)
        {
            _iDAL_BusinessDonateBloodAndCheck_repository = iDAL_BusinessDonateBloodAndCheck_repository;
        }



        public DonateBlood DonateBloodRequestToDB(DonateBlood donateBlood)
        {
            try
            {

                return _iDAL_BusinessDonateBloodAndCheck_repository.SaveDonateBloodRequestToDB(donateBlood);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }



        public (string DonorId, string FullName, string Status) DonorStatus(string donorId)
        {
            try
            {

                return _iDAL_BusinessDonateBloodAndCheck_repository.GetDonorStatus(donorId);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); throw; }
        }
    }

}
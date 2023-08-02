using DataAccessLayer.Contracts;
using DataAccessLayer.Models;



namespace BusinessAccessLayer.Services.ApproveReject
{
    public class ServiceApproveReject : IServiceApproveReject
    {
        public readonly IDAL_ApproveReject_repository _iDAL_ApproveReject_repository;

        public ServiceApproveReject(IDAL_ApproveReject_repository DAL_ApproveReject_repository)
        {
           
                _iDAL_ApproveReject_repository = DAL_ApproveReject_repository;

           
        }

        public IEnumerable<Requestor> getreqdetails(string requestorId)
        {
            try
            {
                var result =  _iDAL_ApproveReject_repository.GetRequestorDetails(requestorId).ToList();

                if(result.Count == 0) 
                { 
                    throw new Exception("Enter a valid Requestor Id"); 
                }
                else 
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        public string saverequestorstatusinfotodb(string requestorId, string status)
        {
            try
            { 
                return _iDAL_ApproveReject_repository.SaveRequestorStatusInfoToDB(requestorId, status);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        public IEnumerable<Donor> getdonordetails(string donorId)
        {
            try
            {
                var result = _iDAL_ApproveReject_repository.GetDonorDetails(donorId).ToList();
                if (result.Count == 0)
                {
                    throw new Exception("Enter a valid Donor Id");
                }
                else
                {
                    return result;
                }

            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message); 
                throw; 
            }




}
        public string savedonorstatusinfotodb(string donorId, string status)
        {
            try
            {

                return _iDAL_ApproveReject_repository.SaveDonorStatusInfoToDB(donorId, status);
            

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); throw; }


}
    }
}
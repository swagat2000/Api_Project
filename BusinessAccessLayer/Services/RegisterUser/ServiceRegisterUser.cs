using DataAccessLayer.Contracts;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services.RegisterUser
{
    public class ServiceRegisterUser : IServiceRegisterUser
    {
        public readonly IDAL_RegisterUser_repository _iDAL_RegisterUser_repository;

        public ServiceRegisterUser(IDAL_RegisterUser_repository DAL_RegisterUser_repository)
        {
            _iDAL_RegisterUser_repository = DAL_RegisterUser_repository;
        }

        public List<Donor> GetAllDonor()
        {
            try
            {

                return _iDAL_RegisterUser_repository.GetDonorDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public List<Requestor> GetAllRequestor()
        {
            try
            {

                return _iDAL_RegisterUser_repository.GetRequestorDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public Donor AddDonor(Donor donorModel)
        {
            try
            {

                return _iDAL_RegisterUser_repository.AddDonorDetails(donorModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public Requestor AddRequestor(Requestor requestorModel)
        {
            try
            { 
                return _iDAL_RegisterUser_repository.AddRequestorDetails(requestorModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public string AuthenticateRequestor(string requestorname, string password)
        {
            try
            {

                return _iDAL_RegisterUser_repository.AuthenticateRequestor(requestorname, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public string AuthenticateDonor(string Donorname, string password)
        {
            try
            {

                return _iDAL_RegisterUser_repository.AuthenticateDonor(Donorname, password);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public (string, string) GenerateToken(Admin user)
        {
            // IActionResult response = Unauthorized();
            try
            {

            var (user_, password, role) = _iDAL_RegisterUser_repository.AuthenticateUser(user);
            if (user_ != null)
            {
                var token = _iDAL_RegisterUser_repository.GenerateToken(new Admin { UserId = user_, Password = password }, role);


                return (token, role);


            }
            return (null, null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

    }
}

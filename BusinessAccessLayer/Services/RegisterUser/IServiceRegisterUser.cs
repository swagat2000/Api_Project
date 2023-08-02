using DataAccessLayer.Models;

namespace BusinessAccessLayer.Services.RegisterUser
{
    public interface IServiceRegisterUser
    {
        public List<Donor> GetAllDonor();

        public List<Requestor> GetAllRequestor();

        public Donor AddDonor(Donor donorModel);

        public Requestor AddRequestor(Requestor requestorModel);


        public string AuthenticateRequestor(string requestorname, string password);

        public string AuthenticateDonor(string requestorname, string password);

      

        public (string, string) GenerateToken(Admin user);
    }
}

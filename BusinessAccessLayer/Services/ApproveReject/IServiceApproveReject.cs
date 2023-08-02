using DataAccessLayer.Models;



namespace BusinessAccessLayer.Services.ApproveReject
{
    public interface IServiceApproveReject
    {
        public IEnumerable<Requestor> getreqdetails(string requestorId);
        public string saverequestorstatusinfotodb(string requestorId, string status);
        public IEnumerable<Donor> getdonordetails(string donorId);
        public string savedonorstatusinfotodb(string donorId, string status);
    }
}
namespace DataAccessLayer.Contracts
{
    public interface IDAL_BloodAvailability_repository
    {
        public int GetBloodStatus(string bloodGroup);
    }
}

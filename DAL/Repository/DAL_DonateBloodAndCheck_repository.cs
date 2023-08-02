using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.Repository

{
    public class DAL_DonateBloodAndCheck_repository : IDAL_DonateBloodAndCheck_repository
    {
        private readonly string connectionString;

        public DAL_DonateBloodAndCheck_repository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        /*Method to enter the donor details who have requested to donate blood*/
        
        public DonateBlood SaveDonateBloodRequestToDB(DonateBlood donateBlood)
        {
            try
            {
               
                    List<DonateBlood> donate = new List<DonateBlood>();
                    using (var connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand("SaveDonateBloodRequestToDB", connection);
                        command.CommandType = CommandType.StoredProcedure;

                            command.Parameters.AddWithValue("@DonorId", donateBlood.DonorId);
                            command.Parameters.AddWithValue("@FullName", donateBlood.FullName);
                            command.Parameters.AddWithValue("@DOB", donateBlood.DOB);
                            command.Parameters.AddWithValue("@Gender", donateBlood.Gender);
                            command.Parameters.AddWithValue("@Blood_Group", donateBlood.Blood_Group);
                            command.Parameters.AddWithValue("@City", donateBlood.City);
                            command.Parameters.AddWithValue("@Weight", donateBlood.Weight);
                            command.Parameters.AddWithValue("@Date_Of_Last_Donation", donateBlood.Date_Of_Last_Donation);
                            command.Parameters.AddWithValue("How_Many_Times", donateBlood.How_Many_Times);
                            command.Parameters.AddWithValue("@Phone_Number", donateBlood.Phone_Number);
                            command.Parameters.AddWithValue("@EmailId", donateBlood.EmailId);
                            command.Parameters.AddWithValue("@Status", donateBlood.Status);
                            command.ExecuteNonQuery();
               
                        return donateBlood;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
       // Method to get the donor details from donateblood table   
        public (string DonorId, string FullName, string Status) GetDonorStatus(string donorId)
        {
            try
            {

                string DonorId,FullName,Status;
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetDonorStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DonorId", donorId);
                    using (var reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            DonorId = reader["DonorId"].ToString();
                            FullName = reader["FullName"].ToString();
                            Status = reader["Status"].ToString();
                            return (DonorId,FullName,Status);

                        }
                    }
                    return (null, null, null);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}






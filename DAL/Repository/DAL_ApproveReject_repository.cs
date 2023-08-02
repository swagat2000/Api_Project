using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer.DataAccess
{
    public class DAL_ApproveReject_repository : IDAL_ApproveReject_repository
    {

        private readonly string connectionString;

        public DAL_ApproveReject_repository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Method to get the requestor details of a specific requestor 

        public IEnumerable<Requestor> GetRequestorDetails(string requestorId)
        {
            try
            {
                List<Requestor> requestors = new List<Requestor>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetRequestorDetail_s", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@RequestorId", requestorId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Requestor req = new Requestor
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Password = reader["Password"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Address = reader["Address"].ToString(),
                                ContactNo = reader["ContactNo"].ToString(),
                                EmailId = reader["EmailId"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                RequestorId = reader["RequestorId"].ToString()
                            };
                            requestors.Add(req);
                        }
                    }
                    return requestors;

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
                throw; 
            }
        }

        // Method to update requestor status details of a specific requestor

        public string SaveRequestorStatusInfoToDB(string requestorId, string Status)
        {
            try
            {
               
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SaveRequestorStatusInfoToDB", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Notes", Status);
                    command.Parameters.AddWithValue("@RequestorId", requestorId);
                    try
                    {
                        command.ExecuteNonQuery();
                        return ("Success");

                    }
                    catch (SqlException ex)
                    {
                        if(ex.Message.Contains("ENTER A VALID REQUESTOR ID"))
                        {
                            return ("ENTER A VALID REQUESTOR ID");
                        }
                        else
                        {
                            return ("Error occured while updating the requestor");
                        }

                        
                    }
                }
               
            }

            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); 
                throw; 
            }

        }

    // Method to get the donor details of a specfic donor

    public IEnumerable<Donor> GetDonorDetails(string donorId)
        {
            try
            {
                List<Donor> donors = new List<Donor>();
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetDonorDetail_s", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@DonorId", donorId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Donor don = new Donor
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Password = reader["Password"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Address = reader["Address"].ToString(),
                                ContactNo = reader["ContactNo"].ToString(),
                                EmailId = reader["EmailId"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                BloodGroup = reader["BloodGroup"].ToString(),
                                DonorId = reader["DonorId"].ToString()
                            };
                            donors.Add(don);
                        }
                        
                    }
                    return donors;

                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message); 
                throw;
            }
        }

        // Method to update donor status details of a specific donor

        public string SaveDonorStatusInfoToDB(string donorId, string status)
        {
            try
            {
              
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SaveDonorStatusInfoToDB", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Status", status);
                    command.Parameters.AddWithValue("@DonorId", donorId);
                    try
                    {
                        command.ExecuteNonQuery();
                        return ("Success");

                    }
                    catch (SqlException ex)
                    {
                        if (ex.Message.Contains("ENTER A VALID DONOR ID"))
                        {
                            return ("ENTER A VALID DONOR ID");
                        }
                        else
                        {
                            return ("Error occured while updating the donor");
                        }

                    }
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










using System.Data;
using System.Data.SqlClient;

using DataAccessLayer.Contracts;
using DataAccessLayer.Models;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.DataAccess
{
    public class DAL_RequestBloodAndCheck_repository : IDAL_RequestBloodAndCheck_repository
    {
        private readonly string connectionString;

        public DAL_RequestBloodAndCheck_repository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public RequestBlood MakeRequest(RequestBlood request)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("MakeRequest", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RequestorId", request.RequestorId);
                    command.Parameters.AddWithValue("@Patient_Name", request.Patient_Name);
                    command.Parameters.AddWithValue("@Requested_Blood_Group", request.Required_Blood_Group);
                    command.Parameters.AddWithValue("@City", request.City);
                    command.Parameters.AddWithValue("@DoctorName", request.DoctorName);
                    command.Parameters.AddWithValue("@Hospital_Name_Address", request.Hospital_Name_Address);
                    command.Parameters.AddWithValue("@Blood_required_Date", request.Blood_required_Date);
                    command.Parameters.AddWithValue("@Contact_Name", request.Contact_Name);
                    command.Parameters.AddWithValue("@Contact_Number", request.Contact_Number);
                    command.Parameters.AddWithValue("@Contact_Email_Id", request.Contact_Email_Id);
                    command.Parameters.AddWithValue("@Message", request.Message);

                    command.ExecuteNonQuery();

                    return (request);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        public IEnumerable<RequestStatus> GetRequestorStatus(string requestorId)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetRequestorStatus", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RequestorId", requestorId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            var result = new List<RequestStatus>();
                            while (reader.Read())
                            {
                                var requestStatus = new RequestStatus
                                {
                                    RequestorId = reader.GetString("RequestorId"),
                                    PatientId = reader.GetString("PatientId"),
                                    Blood_Glucose_Level = reader.GetString("Blood_Glucose_Level"),
                                    Time_Of_The_Day = Convert.ToDateTime(reader["Time_Of_The_Day"]),
                                    Notes = reader.GetString("Notes")
                                };
                                result.Add(requestStatus);
                            }
                            return result;
                        }
                        else
                            return null;
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

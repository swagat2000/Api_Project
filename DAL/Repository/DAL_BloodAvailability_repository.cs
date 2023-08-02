using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Contracts;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer.DataAccess
{
    public class DAL_BloodAvailability_repository : IDAL_BloodAvailability_repository
    {

        private readonly string connectionString;

        public DAL_BloodAvailability_repository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        // it is a method which takes blood group as an argument and returns the no. of units of blood available in the blood bank
        public int GetBloodStatus(string bloodGroup)
        {
            try
            {
                if(bloodGroup == "A+" || bloodGroup == "B+"|| bloodGroup == "AB+" || bloodGroup == "O+"|| bloodGroup == "A-" || bloodGroup == "B-" || bloodGroup == "AB-" || bloodGroup == "O-") { 

                    var response = 0;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand("GetBloodStatus", connection);
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("@BloodGroup", bloodGroup);
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            int availability = Convert.ToInt32(reader["Availability"]);
                            response = availability;
                            reader.Close();
                        }
                        return response;

                    }

                }
                else
                {
                    throw new Exception("Enter a valid Blood Group");
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
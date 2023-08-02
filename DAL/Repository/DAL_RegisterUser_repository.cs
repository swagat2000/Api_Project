using System.Data;
using System.Data.SqlClient;
using System.Text;
using DataAccessLayer.Models;
using DataAccessLayer.Contracts;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace DataAccessLayer.DataAccess
{
    public class DAL_RegisterUser_repository : IDAL_RegisterUser_repository
    {
        private readonly string connectionString;

        private IConfiguration? _config;
        public DAL_RegisterUser_repository(IConfiguration configuration)
        {
            _config = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Donor> GetDonorDetails()
        {
            try
            {
                List<Donor> donor = new List<Donor>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("GetDonorDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Donor dono_r = new Donor
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
                                DonorId = reader["DonorId"].ToString(),
                            };

                            donor.Add(dono_r);
                        }
                    }

                }
                return donor;


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public List<Requestor> GetRequestorDetails()
        {
            try
            {
                List<Requestor> requestor = new List<Requestor>();
                Requestor requestorList = new Requestor();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("GetRequestorDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            Requestor requesto_r = new Requestor
                            {
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Password = reader["Password"].ToString(),
                                DOB = Convert.ToDateTime(reader["DOB"]),
                                Address = reader["Address"].ToString(),
                                ContactNo = reader["ContactNo"].ToString(),
                                EmailId = reader["EmailId"].ToString(),
                                Gender = reader["Gender"].ToString(),
                                // BloodGroup = reader["BloodGroup"].ToString(),
                                RequestorId = reader["RequestorId"].ToString()
                            };
                            requestor.Add(requesto_r);
                        }
                    }
                    return requestor;

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public Donor AddDonorDetails(Donor donorModel)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("AddDonorDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@DonorId", donorModel.DonorId);
                    command.Parameters.AddWithValue("@FirstName", donorModel.FirstName);
                    command.Parameters.AddWithValue("@LastName", donorModel.LastName);
                    command.Parameters.AddWithValue("@DOB", donorModel.DOB);
                    command.Parameters.AddWithValue("@EmailId", donorModel.EmailId);
                    command.Parameters.AddWithValue("@ContactNo", donorModel.ContactNo);
                    command.Parameters.AddWithValue("@BloodGroup", donorModel.BloodGroup);
                    command.Parameters.AddWithValue("@Address", donorModel.Address);
                    command.Parameters.AddWithValue("@Gender", donorModel.Gender);

                    command.ExecuteNonQuery();


                    return donorModel;
                }
            }


            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


        public Requestor AddRequestorDetails(Requestor requestorModel)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    connection.Open();
                    SqlCommand command = new SqlCommand("AddRequestorDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RequestorId", requestorModel.RequestorId);
                    command.Parameters.AddWithValue("@FirstName", requestorModel.FirstName);
                    command.Parameters.AddWithValue("@LastName", requestorModel.LastName);
                    command.Parameters.AddWithValue("@DOB", requestorModel.DOB);
                    command.Parameters.AddWithValue("@EmailId", requestorModel.EmailId);
                    command.Parameters.AddWithValue("@ContactNo", requestorModel.ContactNo);
                    command.Parameters.AddWithValue("@Password", requestorModel.Password);
                    command.Parameters.AddWithValue("@Address", requestorModel.Address);
                    command.Parameters.AddWithValue("@Gender", requestorModel.Gender);
                    command.ExecuteNonQuery();
                }

                return requestorModel;

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
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AuthenticateRequestor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FirstName", requestorname);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        string requestorId = (string)command.ExecuteScalar();


                        return requestorId;

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        
        public string AuthenticateDonor(string requestorname, string password)
        {
            try
            {

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("AuthenticateDonor", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@FirstName", requestorname);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();
                        string donorId = (string)command.ExecuteScalar();

                        return donorId;
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        //----------------------------------------------------------------------------------------------
        //--------------------------LOGIN PART-------------------------------
        public string GenerateToken(Admin user, string role)
        {
            try
            {
                var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                   // new Claim(ClaimTypes.Name, user.UserId),
                    new Claim(ClaimTypes.Role , role)
                };

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddMinutes(20),
                    signingCredentials: credentials
                    );
                return new JwtSecurityTokenHandler().WriteToken(token);


            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    public (string UserId , string Password , string Role) AuthenticateUser(Admin user)
    {
            try
            {

                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DonorId as UserId, Password, 'Donor' AS Role FROM Donor WHERE FirstName = @Userid" +
                    " UNION " +
                    "SELECT RequestorId as UserId, Password, 'Requestor' AS Role FROM Requestor WHERE FirstName = @Userid";


                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Userid", user.UserId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string UserId = reader["UserId"].ToString();
                            string password = reader["Password"].ToString();
                            string Role = reader["Role"].ToString();

                            if (password == user.Password)
                            {
                               /* user.UserId = UserId;*/
                                reader.Close();
                                return (UserId, password, Role);
                            }
                        }
                    }
                    reader.Close();
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

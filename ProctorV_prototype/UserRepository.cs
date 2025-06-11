using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UserRepo
{
    internal class UserRepository : IUserRepository
    {
        private string connStr;
        private MySqlConnection connection;

        public UserRepository() 
        {
            string connStr = "Server=localhost;Port=3306;Database=proctorv_db;Uid=root;Pwd=#32Monster$Hw;";
            connection = new MySqlConnection(connStr);
        }

        public void AddGroup(string groupname)
        {
            
        }

        public List<User> GetCandidates()
        {
            throw new NotImplementedException();
        }

        public string GetEmail(string username)
        {         
                try
                {
                    connection.Open();

                    string query = "SELECT email FROM users WHERE username = @Value";

                    using (var command = new MySqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Value", username);

                        var result = command.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToString(result);
                        }
                        else
                        {
                            return "";
                        }
                    }
                }
                finally
                {
                    connection.Close();
                }
            
        }

        public string GetFirstname(string username)
        {
            try
            {
                connection.Open();

                string query = "SELECT firstname FROM users WHERE username = @Value";

                using (var command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Value", username);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToString(result);
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public GroupOfCandidates GetGroupOfCandidates(string groupname)
        {
            throw new NotImplementedException();
        }

        public List<string> GetGroupsName()
        {
            throw new NotImplementedException();
        }

        public string GetLastname(string username)
        {
            try
            {
                connection.Open();

                string query = "SELECT lastname FROM users WHERE username = @Value";

                using (var command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Value", username);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToString(result);
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public string GetPhoneNumber(string username)
        {
            try
            {
                connection.Open();

                string query = "SELECT phoneNumber FROM users WHERE username = @Value";

                using (var command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Value", username);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToString(result);
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public string GetRole(string username)
        {
            try
            {
                connection.Open();

                string query = "SELECT role_name FROM user_roles_view WHERE username = @Value";

                using (var command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Value", username);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToString(result);
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public User GetUserByUsername(string username)
        {
           string query = @"
        SELECT u.username, u.password, u.email, u.phoneNumber, u.firstname, u.lastname, r.role_name
        FROM users u
        JOIN user_roles_view r ON u.username = r.username
        WHERE u.username = @username";
                      
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new User
                        {
                            Username = reader["username"].ToString(),
                            Password = reader["password"].ToString(),
                            Email = reader["email"].ToString(),
                            Phone_number = reader["phoneNumber"].ToString(),
                            FirstName = reader["firstname"].ToString(),
                            LastName = reader["lastname"].ToString(),
                            Role = reader["role_name"].ToString()
                        };
                    }
                }
                connection.Close();
            }

            return null; 
        }


        public string GetUserName(string phoneNumber, string firstName)
        {
            try
            {
                connection.Open();

                string query = "SELECT username  FROM users WHERE phoneNumber= @Value1 AND firstname=@Value2";

                using (var command = new MySqlCommand(query, connection))
                {

                    command.Parameters.AddWithValue("@Value1", phoneNumber);
                    command.Parameters.AddWithValue("@Value2", firstName);

                    var result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToString(result);
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            finally
            {
                connection.Close();
            }
        }

        public void RemoveGruop(string groupname)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(GroupOfCandidates group)
        {
            throw new NotImplementedException();
        }

        public bool VerifyPassword(string username, string password)
        {
            string storedPassword = null;

            
                connection.Open();
                string query = "SELECT password FROM users WHERE username = @username";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            storedPassword = reader.GetString(0);
                        }
                    }
                }
            connection.Close();

            if (storedPassword == null)
                return false;

            return storedPassword == password;
        }


    public bool VerifyUsername(string username)
        {
            
                try
                {
                    connection.Open();
                    string query = "SELECT EXISTS(SELECT 1 FROM Users WHERE username = @username)";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);

                        var result = Convert.ToInt64(command.ExecuteScalar());
                        return result == 1;
                    }
                }
                finally
                {
                    connection.Close();
                }
        }
        

}
}

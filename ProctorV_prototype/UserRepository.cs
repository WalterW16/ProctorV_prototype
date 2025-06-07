using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace UserRepo
{
    internal class UserRepository : IUserRepository
    {
        private string connStr;
        private MySqlConnection connection;

        public UserRepository() {
            string connStr = "Server=localhost;Port=3306;Database=proctorv_db;Uid=root;Pwd=#32Monster$Hw;";
            connection = new MySqlConnection(connStr);
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

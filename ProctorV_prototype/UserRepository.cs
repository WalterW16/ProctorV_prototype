using Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

        public UserRepository() 
        {
            string connStr = "Server=localhost;Port=3306;Database=proctorv_db;Uid=root;Pwd=#32Monster$Hw;";
            connection = new MySqlConnection(connStr);
        }

        public void AddGroup(string groupname)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO groups_names (name) VALUES (@name)";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", groupname);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while adding: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<User> GetCandidates()
        {
            List<User> candidates = new List<User>();

            try
            {
                connection.Open();
                string query = @"
        SELECT u.username, u.password, u.email, u.phoneNumber, u.firstname, u.lastname, r.role_name
        FROM users u
        JOIN user_roles_view r ON u.username = r.username
        WHERE r.role_name = @value";                

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("value", "candidate");
                    using (MySqlDataReader reader = command.ExecuteReader()) { 
                    
                    while (reader.Read())
                    {
                        User user = new User(
                            reader.GetString("username"),
                            reader.GetString("password"),
                            reader.GetString("email"),
                            reader.GetString("phoneNumber"),
                            reader.GetString("firstname"),
                            reader.GetString("lastname"),                           
                            reader.GetString("role_name")
                        );

                        candidates.Add(user);
                    }
                }
            }
                }
                catch (MySqlException ex)
                {                 
                    Console.WriteLine("Database error: " + ex.Message);
                }
            finally
            {
                connection.Close();
            }
            

            return candidates;
        
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
            GroupOfCandidates group = new GroupOfCandidates(groupname);
            List<string> usernames = new List<string>();

            try
            {
                connection.Open();
                string query = "SELECT username FROM user_groups WHERE group_name = @value";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@value", groupname);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            usernames.Add(reader.GetString("username"));
                        }
                    }
                }

                // Закінчився data reader → тепер можна викликати інші запити
                foreach (string un in usernames)
                {
                    User newuser = GetUserByUsername(un);
                    if (newuser != null)
                        group.AddCandidate(newuser);
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return group;
        }


        public List<string> GetGroupsName()
        {
            List<string> groups = new List<string>();

            try
            {
                connection.Open();
                string query = "SELECT name FROM groups_names";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string gr = reader.GetString("name");
                            groups.Add(gr);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Database error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return groups;
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
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
                string query = @"
                SELECT u.username, u.password, u.email, u.phoneNumber, u.firstname, u.lastname, r.role_name
                FROM users u
                JOIN user_roles_view r ON u.username = r.username
                WHERE u.username = @username";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
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
                   

                }
            }
            finally
            {
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

        public void RemoveGroup(string groupname)
        {
            throw new NotImplementedException();
        }

        public void UpdateGroup(GroupOfCandidates group)
        {
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            string groupName = group.GetName();
            List<string> userList = new List<string>();
            foreach (var item in group.GetCandidates())
            {
                userList.Add(item.Username);
            }            
            string query = @"
                INSERT INTO user_groups (username, group_name)
                SELECT @username, @groupname
                FROM DUAL
                WHERE NOT EXISTS (
                    SELECT 1 FROM user_groups WHERE username = @username AND group_name = @groupname
                );";
            foreach (var username in userList)
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@groupname", groupName);
                    cmd.ExecuteNonQuery();
                }
            }
            connection.Close();
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

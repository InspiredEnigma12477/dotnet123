using System.Data;
using IACSD.Model;
using MySql.Data.MySqlClient;

namespace IACSD.DAL;

public static class UserDataAcess
{
    public static string database_name = "userinfo";
    public static string table_name = "users";
    public static string conString =
        @"server=localhost; port=3306; user=root; password=1234567890; database=" + database_name;

    public static void Configure()
    {
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            connection.Open();
            StreamReader sr = new StreamReader("../MySqlDBScripts/userdbscripts.sql");
            string query = sr.ReadToEnd();
            sr.Close();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    public static List<User> GetAllUsers()
    {
        List<User> allUsers = new List<User>();
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            connection.Open();

            string query = "SELECT * FROM " + table_name;

            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(ds);

            DataTable dt = ds.Tables[0];
            DataRowCollection rows = dt.Rows;

            foreach (DataRow row in rows)
            {
                User user = new User
                {
                    userid = int.Parse(row["userid"].ToString()),
                    username = row["username"].ToString(),
                    course = row["course"].ToString(),
                    courseDate = row["courseDate"].ToString(),
                };
                allUsers.Add(user);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }

        return allUsers;
    }

    public static User GetUserById(int userid)
    {
        User user = null;
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            connection.Open();
            string query = "SELECT * FROM " + table_name + " WHERE userid = " + userid;

            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    userid = int.Parse(reader["userid"].ToString()),
                    username = reader["username"].ToString(),
                    course = reader["course"].ToString(),
                    courseDate = reader["courseDate"].ToString(),
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
        return user;
    }

    public static User GetUserByName(string username)
    {
        User user = null;
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            connection.Open();
            Console.WriteLine("username: " + username);
            string query = $"SELECT * FROM {table_name} WHERE username = '{username}'"; 
            Console.WriteLine("query: " + query);
            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    userid = int.Parse(reader["userid"].ToString()),
                    username = reader["username"].ToString(),
                    course = reader["course"].ToString(),
                    courseDate = reader["courseDate"].ToString(),
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
        return user;
    }

    public static void InsertUser(User user)
    {
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            connection.Open();
            string query =
                $"INSERT INTO {table_name} (username, course, courseDate) VALUES ('{user.username}', '{user.course}', '{user.courseDate}')";

            DataSet ds = new DataSet();
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    userid = int.Parse(reader["userid"].ToString()),
                    username = reader["username"].ToString(),
                    course = reader["course"].ToString(),
                    courseDate = reader["courseDate"].ToString(),
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }

    public static User UpdateUser(User user, int userid)
    {
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            connection.Open();
            string query =
                $"UPDATE {table_name} SET username = '{user.username}', course = '{user.course}', courseDate = '{user.courseDate}' WHERE userid = {userid}";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                user = new User
                {
                    userid = int.Parse(reader["userid"].ToString()),
                    username = reader["username"].ToString(),
                    course = reader["course"].ToString(),
                    courseDate = reader["courseDate"].ToString(),
                };
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
        return user;
    }

    public static void DeleteUser(int userid)
    {
        MySqlConnection connection = new MySqlConnection(conString);
        try
        {
            connection.Open();
            string query = $"DELETE FROM {table_name} WHERE userid = {userid}";

            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader reader = cmd.ExecuteReader();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }
}

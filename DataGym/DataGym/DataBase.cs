using System.Data.SqlClient;

namespace DataGym
{
    public class DataBase
    {
        //подключение к БД
        internal string connectionStr;
        public void Connect(string servername, string dbname)
            => connectionStr = $"Data Source={servername};Initial Catalog={dbname};Integrated Security=True";

        //логика входа в систему
        public bool LogSystem(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Users WHERE Username = @Username AND Password = @Password", connection);
                command.Parameters.AddWithValue("@Username", username.Trim());
                command.Parameters.AddWithValue("@Password", password.Trim());
                SqlDataReader reader = command.ExecuteReader();
                bool isValidUser = reader.Read();

                connection.Close();
                return isValidUser;
            }
        }

        //проверка роли
        public string GetUserRole(string username)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT Role FROM Users WHERE Username = @Username", connection);
                command.Parameters.AddWithValue("@Username", username.Trim());

                string role = (string)command.ExecuteScalar();

                connection.Close();
                return role;
            }
        }
    }
}

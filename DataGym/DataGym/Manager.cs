using System.Data;
using System.Data.SqlClient;

namespace DataGym
{
    public class Manager
    {
        private DataBase db;
        public Manager(DataBase database) => db = database;

        //отображение клиентов
        public SqlDataReader ViewClients()
        {
            SqlConnection connection = new SqlConnection(db.connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Clients", connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //отображение тренеров
        public SqlDataReader ViewTrainers()
        {
            SqlConnection connection = new SqlConnection(db.connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Trainers", connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //отображение снаряжения
        public SqlDataReader ViewEquipment()
        {
            SqlConnection connection = new SqlConnection(db.connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Equipment", connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //генерация репортов
        public SqlDataReader GenerateClientReport()
        {
            SqlConnection connection = new SqlConnection(db.connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Clients", connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader GenerateTrainerReport()
        {
            SqlConnection connection = new SqlConnection(db.connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Trainers", connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        public SqlDataReader GenerateEquipmentReport()
        {
            SqlConnection connection = new SqlConnection(db.connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Equipment", connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }
    }
}

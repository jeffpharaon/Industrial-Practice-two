using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGym
{
    public class Admin
    {
        private DataBase db;

        public Admin(DataBase database) => db = database;

        // Методы для работы с клиентами
        public void AddClient(string fullName, string contactInfo, string subscription, int trainerId)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Clients (FullName, ContactInfo, Subscription, TrainerID) VALUES (@FullName, @ContactInfo, @Subscription, @TrainerID)", connection);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@ContactInfo", contactInfo);
                command.Parameters.AddWithValue("@Subscription", subscription);
                command.Parameters.AddWithValue("@TrainerID", trainerId);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EditClient(int clientId, string fullName, string contactInfo, string subscription, int trainerId)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Clients SET FullName = @FullName, ContactInfo = @ContactInfo, Subscription = @Subscription, TrainerID = @TrainerID WHERE ClientID = @ClientID", connection);
                command.Parameters.AddWithValue("@ClientID", clientId);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@ContactInfo", contactInfo);
                command.Parameters.AddWithValue("@Subscription", subscription);
                command.Parameters.AddWithValue("@TrainerID", trainerId);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteClient(int clientId)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Clients WHERE ClientID = @ClientID", connection);
                command.Parameters.AddWithValue("@ClientID", clientId);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Методы для работы с тренерами
        public void AddTrainer(string fullName, string specialization, string schedule)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Trainers (FullName, Specialization, Schedule) VALUES (@FullName, @Specialization, @Schedule)", connection);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Specialization", specialization);
                command.Parameters.AddWithValue("@Schedule", schedule);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EditTrainer(int trainerId, string fullName, string specialization, string schedule)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Trainers SET FullName = @FullName, Specialization = @Specialization, Schedule = @Schedule WHERE TrainerID = @TrainerID", connection);
                command.Parameters.AddWithValue("@TrainerID", trainerId);
                command.Parameters.AddWithValue("@FullName", fullName);
                command.Parameters.AddWithValue("@Specialization", specialization);
                command.Parameters.AddWithValue("@Schedule", schedule);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteTrainer(int trainerId)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Trainers WHERE TrainerID = @TrainerID", connection);
                command.Parameters.AddWithValue("@TrainerID", trainerId);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Методы для работы с тренажерами
        public void AddEquipment(string name, string description, bool availability)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Equipment (Name, Description, Availability) VALUES (@Name, @Description, @Availability)", connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Availability", availability);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EditEquipment(int equipmentId, string name, string description, bool availability)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Equipment SET Name = @Name, Description = @Description, Availability = @Availability WHERE EquipmentID = @EquipmentID", connection);
                command.Parameters.AddWithValue("@EquipmentID", equipmentId);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Description", description);
                command.Parameters.AddWithValue("@Availability", availability);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteEquipment(int equipmentId)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Equipment WHERE EquipmentID = @EquipmentID", connection);
                command.Parameters.AddWithValue("@EquipmentID", equipmentId);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Методы для работы с тренировками
        public void AddWorkout(int clientId, int trainerId, DateTime date, string time)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO Workouts (ClientID, TrainerID, Date, Time) VALUES (@ClientID, @TrainerID, @Date, @Time)", connection);
                command.Parameters.AddWithValue("@ClientID", clientId);
                command.Parameters.AddWithValue("@TrainerID", trainerId);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Time", time);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void EditWorkout(int workoutId, int clientId, int trainerId, DateTime date, string time)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Workouts SET ClientID = @ClientID, TrainerID = @TrainerID, Date = @Date, Time = @Time WHERE WorkoutID = @WorkoutID", connection);
                command.Parameters.AddWithValue("@WorkoutID", workoutId);
                command.Parameters.AddWithValue("@ClientID", clientId);
                command.Parameters.AddWithValue("@TrainerID", trainerId);
                command.Parameters.AddWithValue("@Date", date);
                command.Parameters.AddWithValue("@Time", time);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public void DeleteWorkout(int workoutId)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Workouts WHERE WorkoutID = @WorkoutID", connection);
                command.Parameters.AddWithValue("@WorkoutID", workoutId);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Методы для генерации отчетов
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

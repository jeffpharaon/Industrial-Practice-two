using System.Data;
using System.Data.SqlClient;

namespace DataGym
{
    public class Trainer
    {
        private DataBase db;
        public Trainer(DataBase database) => db = database;

        //отображение групп
        public SqlDataReader ViewGroups()
        {
            SqlConnection connection = new SqlConnection(db.connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Attendance", connection);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //отображение субъектов
        public SqlDataReader ViewSubjects(int trainerId)
        {
            SqlConnection connection = new SqlConnection(db.connectionStr);
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT * FROM Subjects WHERE TrainerID = @TrainerID", connection);
            command.Parameters.AddWithValue("@TrainerID", trainerId);
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        //изменения журнала
        public void EditJournal(int workoutId, string notes)
        {
            using (SqlConnection connection = new SqlConnection(db.connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Workouts SET Notes = @Notes WHERE WorkoutID = @WorkoutID", connection);
                command.Parameters.AddWithValue("@WorkoutID", workoutId);
                command.Parameters.AddWithValue("@Notes", notes);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
    }
}

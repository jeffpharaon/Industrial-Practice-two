using DataGym;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PPThemeTwo
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //инициализация БД
        private DataBase db = new DataBase();
        private Admin admin;
        private Trainer trainer;
        private Manager manager;

        public MainWindow()
        {
            InitializeComponent();
            InitalizeSettings();
        }

        private void InitalizeSettings()
        {
            //настройки отображения UI
            AdminGrid.Visibility = Visibility.Hidden;
            TrainerGrid.Visibility = Visibility.Hidden;
            ManagerGrid.Visibility = Visibility.Hidden;
            SystemInfo.Visibility = Visibility.Hidden;

            //подключение к БД
            db.Connect("JEFFPHARAON\\SQLEXPRESS", "Gym");
            admin = new Admin(db);
            trainer = new Trainer(db);
            manager = new Manager(db);
        }

        //логика входа в систему
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            if (db.LogSystem(username, password))
            {
                string role = db.GetUserRole(username);

                if (role == "admin")
                    AdminGrid.Visibility = Visibility.Visible;

                else if (role == "trainer")
                    TrainerGrid.Visibility = Visibility.Visible;

                else if (role == "manager")
                    ManagerGrid.Visibility = Visibility.Visible;
            }

            else SystemInfo.Visibility = Visibility.Visible;
        }

        //Добавить клиента
        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameTextBox.Text;
            string contactInfo = ContactInfoTextBox.Text;
            string subscription = SubscriptionTextBox.Text;
            int trainerId = int.Parse(TrainerIdTextBox.Text);

            admin.AddClient(fullName, contactInfo, subscription, trainerId);
            MessageBox.Show("Client added successfully.");
        }

        //Изменить информацию о клиенте
        private void EditClientButton_Click(object sender, RoutedEventArgs e)
        {
            int clientId = int.Parse(ClientIdTextBox.Text); 
            string fullName = FullNameTextBox.Text;
            string contactInfo = ContactInfoTextBox.Text;
            string subscription = SubscriptionTextBox.Text;
            int trainerId = int.Parse(TrainerIdTextBox.Text);

            admin.EditClient(clientId, fullName, contactInfo, subscription, trainerId);
            MessageBox.Show("Client edited successfully.");
        }

        //удалить клиента
        private void DeleteClientButton_Click(object sender, RoutedEventArgs e)
        {
            int clientId = int.Parse(ClientIdTextBox.Text);

            admin.DeleteClient(clientId);
            MessageBox.Show("Client deleted successfully.");
        }

        //сгенирировать репорт
        private void GenerateClientReportButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsListBox.Items.Clear();
            var reader = admin.GenerateClientReport();
            while (reader.Read())
                ClientsListBox.Items.Add($"{reader["ClientID"]}: {reader["FullName"]}");
            reader.Close();
        }

        //добавить тренера
        private void AddTrainerButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = TrainerFullNameTextBox.Text;
            string specialization = SpecializationTextBox.Text;
            string schedule = ScheduleTextBox.Text;

            admin.AddTrainer(fullName, specialization, schedule);
            MessageBox.Show("Trainer added successfully.");
        }

        //изменить информацию о тренере
        private void EditTrainerButton_Click(object sender, RoutedEventArgs e)
        {
            int trainerId = int.Parse(TrainersIdTextBox.Text); 
            string fullName = TrainerFullNameTextBox.Text;
            string specialization = SpecializationTextBox.Text;
            string schedule = ScheduleTextBox.Text;

            admin.EditTrainer(trainerId, fullName, specialization, schedule);
            MessageBox.Show("Trainer edited successfully.");
        }

        //удалить тренера
        private void DeleteTrainerButton_Click(object sender, RoutedEventArgs e)
        {
            int trainerId = int.Parse(TrainersIdTextBox.Text); 

            admin.DeleteTrainer(trainerId);
            MessageBox.Show("Trainer deleted successfully.");
        }

        //сгенирировать репорт
        private void GenerateTrainerReportButton_Click(object sender, RoutedEventArgs e)
        {
            TrainersListBox.Items.Clear();
            var reader = admin.GenerateTrainerReport();
            while (reader.Read())
                TrainersListBox.Items.Add($"{reader["TrainerID"]}: {reader["FullName"]}");
            reader.Close();
        }

        //добавить снаряжение
        private void AddEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            string name = EquipmentNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            bool availability = AvailabilityCheckBox.IsChecked ?? false;

            admin.AddEquipment(name, description, availability);
            MessageBox.Show("Equipment added successfully.");
        }

        //изменить информацию о снаряжении
        private void EditEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            int equipmentId = int.Parse(EquipmentIdTextBox.Text); 
            string name = EquipmentNameTextBox.Text;
            string description = DescriptionTextBox.Text;
            bool availability = AvailabilityCheckBox.IsChecked ?? false;

            admin.EditEquipment(equipmentId, name, description, availability);
            MessageBox.Show("Equipment edited successfully.");
        }

        //удалить снаряжение
        private void DeleteEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            int equipmentId = int.Parse(EquipmentIdTextBox.Text); 

            admin.DeleteEquipment(equipmentId);
            MessageBox.Show("Equipment deleted successfully.");
        }

        //сгенирировать репорт
        private void GenerateEquipmentReportButton_Click(object sender, RoutedEventArgs e)
        {
            EquipmentListBox.Items.Clear();
            var reader = admin.GenerateEquipmentReport();
            while (reader.Read())
                EquipmentListBox.Items.Add($"{reader["EquipmentID"]}: {reader["Name"]}");
            reader.Close();
        }

        //добавить тренировку
        private void AddWorkoutButton_Click(object sender, RoutedEventArgs e)
        {
            int clientId = int.Parse(ClientsIdTextBox.Text);
            int trainerId = int.Parse(WorkoutTrainerIdTextBox.Text);
            DateTime date = WorkoutDatePicker.SelectedDate ?? DateTime.Now;
            string time = WorkoutTimeTextBox.Text;

            admin.AddWorkout(clientId, trainerId, date, time);
            MessageBox.Show("Workout added successfully.");
        }

        //изменить тренировку
        private void EditWorkoutButton_Click(object sender, RoutedEventArgs e)
        {
            int workoutId = int.Parse(WorkoutIdTextBox.Text); 
            int clientId = int.Parse(ClientsIdTextBox.Text);
            int trainerId = int.Parse(WorkoutTrainerIdTextBox.Text);
            DateTime date = WorkoutDatePicker.SelectedDate ?? DateTime.Now;
            string time = WorkoutTimeTextBox.Text;

            admin.EditWorkout(workoutId, clientId, trainerId, date, time);
            MessageBox.Show("Workout edited successfully.");
        }

        //удалить тренировку
        private void DeleteWorkoutButton_Click(object sender, RoutedEventArgs e)
        {
            int workoutId = int.Parse(WorkoutIdTextBox.Text); 

            admin.DeleteWorkout(workoutId);
            MessageBox.Show("Workout deleted successfully.");
        }

        //скрытие UI
        private void RemovePlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        //отображение UI
        private void AddPlaceholderText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                if (textBox.Name == "FullNameTextBox") textBox.Text = "Full Name";
                else if (textBox.Name == "ContactInfoTextBox") textBox.Text = "Contact Info";
                else if (textBox.Name == "SubscriptionTextBox") textBox.Text = "Subscription";
                else if (textBox.Name == "TrainerIdTextBox") textBox.Text = "Trainer ID";
                else if (textBox.Name == "TrainerFullNameTextBox") textBox.Text = "Full Name";
                else if (textBox.Name == "SpecializationTextBox") textBox.Text = "Specialization";
                else if (textBox.Name == "ScheduleTextBox") textBox.Text = "Schedule";
                else if (textBox.Name == "EquipmentNameTextBox") textBox.Text = "Name";
                else if (textBox.Name == "DescriptionTextBox") textBox.Text = "Description";
                else if (textBox.Name == "ClientIdTextBox") textBox.Text = "Client ID";
                else if (textBox.Name == "WorkoutTrainerIdTextBox") textBox.Text = "Trainer ID";
                else if (textBox.Name == "WorkoutTimeTextBox") textBox.Text = "Time (HH:MM)";
                else if (textBox.Name == "WorkoutIdTextBox") textBox.Text = "Workout ID";
                else if (textBox.Name == "EquipmentIdTextBox") textBox.Text = "Equipment ID";
            }
        }

        //отбражение групп
        private void ViewGroupsButton_Click(object sender, RoutedEventArgs e)
        {
            GroupsListBox.Items.Clear();
            var reader = trainer.ViewGroups();
            while (reader.Read())
            {
                GroupsListBox.Items.Add($"{reader["GroupID"]}: {reader["GroupName"]}");
            }
            reader.Close();
        }

        //отображение субъектов
        private void ViewSubjectsButton_Click(object sender, RoutedEventArgs e)
        {
            SubjectsListBox.Items.Clear();
            int trainerId = int.Parse(TrainerIdTextBox.Text);
            var reader = trainer.ViewSubjects(trainerId);
            while (reader.Read())
            {
                SubjectsListBox.Items.Add($"{reader["SubjectID"]}: {reader["SubjectName"]}");
            }
            reader.Close();
        }

        //изменить журнал
        private void EditJournalButton_Click(object sender, RoutedEventArgs e)
        {
            int workoutId = int.Parse(WorkoutIdTextBox.Text);
            string notes = NotesTextBox.Text;

            trainer.EditJournal(workoutId, notes);
            MessageBox.Show("Journal edited successfully.");
        }

        //скрытие UI
        private void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Foreground == Brushes.Gray)
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        //отображение UI
        private void AddPlaceholder(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Foreground = Brushes.Gray;
                if (textBox.Name == "TrainerIdTextBox")
                {
                    textBox.Text = "Trainer ID";
                }
                else if (textBox.Name == "WorkoutIdTextBox")
                {
                    textBox.Text = "Workout ID";
                }
                else if (textBox.Name == "NotesTextBox")
                {
                    textBox.Text = "Notes";
                }
            }
        }

        //отобразить клиентов
        private void ViewClientsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsListBox.Items.Clear();
            var reader = manager.ViewClients();
            while (reader.Read())
            {
                ClientsList.Items.Add($"{reader["ClientID"]}: {reader["FullName"]}");
            }
            reader.Close();
        }

        //отобразить тренеров
        private void ViewTrainersButton_Click(object sender, RoutedEventArgs e)
        {
            TrainersListBox.Items.Clear();
            var reader = manager.ViewTrainers();
            while (reader.Read())
            {
                TrainersList.Items.Add($"{reader["TrainerID"]}: {reader["FullName"]}");
            }
            reader.Close();
        }

        //отобразить снаряжение
        private void ViewEquipmentButton_Click(object sender, RoutedEventArgs e)
        {
            EquipmentListBox.Items.Clear();
            var reader = manager.ViewEquipment();
            while (reader.Read())
            {
                EquipmentList.Items.Add($"{reader["EquipmentID"]}: {reader["Name"]}");
            }
            reader.Close();
        }

        //сгенерировать клиент репорт
        private void GenerateClientReportBtn_Click(object sender, RoutedEventArgs e)
        {
            ClientsListBox.Items.Clear();
            var reader = manager.GenerateClientReport();
            while (reader.Read())
            {
                ClientsList.Items.Add($"{reader["ClientID"]}: {reader["FullName"]}");
            }
            reader.Close();
        }

        //сгенерировать тренер репорт
        private void GenerateTrainerReportBtn_Click(object sender, RoutedEventArgs e)
        {
            TrainersListBox.Items.Clear();
            var reader = manager.GenerateTrainerReport();
            while (reader.Read())
            {
                TrainersList.Items.Add($"{reader["TrainerID"]}: {reader["FullName"]}");
            }
            reader.Close();
        }

        //сгенерировать снаряжение репорт
        private void GenerateEquipmentReportBtn_Click(object sender, RoutedEventArgs e)
        {
            EquipmentListBox.Items.Clear();
            var reader = manager.GenerateEquipmentReport();
            while (reader.Read())
            {
                EquipmentList.Items.Add($"{reader["EquipmentID"]}: {reader["Name"]}");
            }
            reader.Close();
        }
    }
}

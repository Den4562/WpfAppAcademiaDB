using System.Linq;
using System.Windows;
using System.Windows.Controls;
using WpfAppAcademia.Tables;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WpfAppAcademia.Icons;

namespace WpfAppAcademia
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private List<Teacher> GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Teacher";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Teacher teacher = new Teacher
                        {
                            Id = reader.GetInt32(0),
                            EmploymentDate = reader.GetDateTime(1),
                            Name = reader.GetString(2),
                            Premium = reader.GetDecimal(3),
                            Salary = reader.GetDecimal(4),
                            Surname = reader.GetString(5)
                        };
                        teachers.Add(teacher);
                    }
                }
            }

            return teachers;
        }

        private List<Group> GetGroups()
        {
            List<Group> groups = new List<Group>();

            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM [Group]";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Group group = new Group
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Rating = reader.GetInt32(2),
                            Year = reader.GetInt32(3)
                        };
                        groups.Add(group);
                    }
                }
            }

            return groups;
        }

        private List<Department> GetDepartments()
        {
            List<Department> departments = new List<Department>();

            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Department";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Department department = new Department
                        {
                            Id = reader.GetInt32(0),
                            Financing = reader.GetDecimal(1),
                            Name = reader.GetString(2)
                        };
                        departments.Add(department);
                    }
                }
            }

            return departments;
        }

        private List<Faculties> GetFaculties()
        {
            List<Faculties> faculties = new List<Faculties>();
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Faculties";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Faculties faculty = new Faculties
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                        faculties.Add(faculty);
                    }
                }
            }

            return faculties;
        }




        private void SaveTeachers(List<Teacher> teachers)
        {
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int totalRowsAffected = 0;

                foreach (Teacher teacher in teachers)
                {
                    string query = "UPDATE Teacher SET EmploymentDate = @EmploymentDate, Name = @Name, Premium = @Premium, Salary = @Salary, Surname = @Surname WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", teacher.Id);
                        command.Parameters.AddWithValue("@EmploymentDate", teacher.EmploymentDate);
                        command.Parameters.AddWithValue("@Name", teacher.Name);
                        command.Parameters.AddWithValue("@Premium", teacher.Premium);
                        command.Parameters.AddWithValue("@Salary", teacher.Salary);
                        command.Parameters.AddWithValue("@Surname", teacher.Surname);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            totalRowsAffected++;
                        }
                    }
                }

                if (totalRowsAffected > 0)
                {
                    MessageBox.Show("Изменения сохранены успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при сохранении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveGroups(List<Group> groups)
        {
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int totalRowsAffected = 0;

                foreach (Group group in groups)
                {
                    string query = "UPDATE [Group] SET Name = @Name, Rating = @Rating, Year = @Year WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", group.Id);
                        command.Parameters.AddWithValue("@Name", group.Name);
                        command.Parameters.AddWithValue("@Rating", group.Rating);
                        command.Parameters.AddWithValue("@Year", group.Year);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            totalRowsAffected++;
                        }
                    }
                }

                if (totalRowsAffected > 0)
                {
                    MessageBox.Show("Изменения сохранены успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при сохранении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }


        private void SaveDepartments(List<Department> departments)
        {
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int totalRowsAffected = 0;

                foreach (Department department in departments)
                {
                    string query = "UPDATE Department SET Financing = @Financing, Name = @Name WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", department.Id);
                        command.Parameters.AddWithValue("@Financing", department.Financing);
                        command.Parameters.AddWithValue("@Name", department.Name);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            totalRowsAffected++;
                        }
                    }
                }

                if (totalRowsAffected > 0)
                {
                    MessageBox.Show("Изменения сохранены успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при сохранении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveFaculties(List<Faculties> faculties)
        {
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                int totalRowsAffected = 0; // Переменная для подсчета общего числа успешно обновленных записей

                foreach (Faculties faculty in faculties)
                {
                    string query = "UPDATE Faculties SET Name = @Name WHERE Id = @Id";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", faculty.Id);
                        command.Parameters.AddWithValue("@Name", faculty.Name);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            totalRowsAffected++; // Увеличиваем счетчик успешных обновлений
                        }
                    }
                }

                if (totalRowsAffected > 0)
                {
                    MessageBox.Show("Изменения сохранены успешно", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при сохранении данных", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataTable.ItemsSource is List<Teacher> teachers)
            {
                SaveTeachers(teachers);
            }
            else if (DataTable.ItemsSource is List<Group> groups)
            {
                SaveGroups(groups);
            }
            else if (DataTable.ItemsSource is List<Department> departments)
            {
                SaveDepartments(departments);
            }
            else if (DataTable.ItemsSource is List<Faculties> faculties)
            {
                SaveFaculties(faculties);
            }
        }

    

     
        private void ButtonGroups_Click(object sender, RoutedEventArgs e)
        {
            List<Group> groups = GetGroups();
            DataTable.ItemsSource = groups;
        }

        private void ButtonDepartments_Click(object sender, RoutedEventArgs e)
        {
            List<Department> departments = GetDepartments();
            DataTable.ItemsSource = departments;
        }

        private void ButtonFaculties_Click(object sender, RoutedEventArgs e)
        {
            List<Faculties> faculties = GetFaculties();
            DataTable.ItemsSource = faculties;
        }

        private void ButtonTeachers_Click(object sender, RoutedEventArgs e)
        {
            List<Teacher> teachers = GetTeachers();
            DataTable.ItemsSource = teachers;
        }

        private void DeleteTeacher(int teacherId)
        {
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Teacher WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", teacherId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при удалении", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void DeleteFaculties(int facultiesId)
        {
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Faculties WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", facultiesId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при удалении", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void DeleteGroup(int groupId)
        {
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM [Group] WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", groupId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при удалении", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void DeleteDepartment(int departmentId)
        {
            string connectionString = "Data Source=DESKTOP-N5K3CGS\\SQLEXPRESS01;Initial Catalog=AcademiaHM;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Department WHERE Id = @Id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", departmentId);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно удалена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Произошла ошибка при удалении", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }


        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataTable.SelectedItem != null && DataTable.SelectedItem is Teacher selectedTeacher)
            {
                DeleteTeacher(selectedTeacher.Id);

                // После удаления обновите данные в DataGrid
                List<Teacher> teachers = GetTeachers();
                DataTable.ItemsSource = teachers;
            }
            else if (DataTable.SelectedItem != null && DataTable.SelectedItem is Department selectedDepartment)
            {
                DeleteDepartment(selectedDepartment.Id);

                // После удаления обновите данные в DataGrid для таблицы Department
                List<Department> departments = GetDepartments();
                DataTable.ItemsSource = departments;
            }
            else if (DataTable.SelectedItem != null && DataTable.SelectedItem is Faculties selectedFaculties)
            {
                DeleteFaculties(selectedFaculties.Id);

                // После удаления обновите данные в DataGrid для таблицы Faculties
                List<Faculties> faculties = GetFaculties();
                DataTable.ItemsSource = faculties;
            }
            else if (DataTable.SelectedItem != null && DataTable.SelectedItem is Group selectedGroup)
            {
                DeleteGroup(selectedGroup.Id);

                // После удаления обновите данные в DataGrid для таблицы Group
                List<Group> groups = GetGroups();
                DataTable.ItemsSource = groups;
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите учителя для удаления", "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


        private void TeacherButton_Click(object sender, RoutedEventArgs e)
        {
            WinTeacher winTeacher = new WinTeacher();
            this.Close();
            winTeacher.ShowDialog(); // Открывает окно как модальное
        }

        private void GroupButton_Click(object sender, RoutedEventArgs e)
        {
            WinGroup group = new WinGroup();
            this.Close();
            group.ShowDialog(); // Открывает окно как модальное
        }

        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            WinDepartment department = new WinDepartment();
            this.Close();
            department.ShowDialog(); // Открывает окно как модальное
        }

        private void FacultiesButton_Click(object sender, RoutedEventArgs e)
        {
            WinFaculties faculties = new WinFaculties();
            this.Close();
            faculties.ShowDialog(); // Открывает окно как модальное
        }

    }
}

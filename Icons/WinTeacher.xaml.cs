using System;
using System.Windows;
using WpfAppAcademia.Tables;

namespace WpfAppAcademia.Icons
{
    /// <summary>
    /// Логика взаимодействия для WinTeacher.xaml
    /// </summary>
    public partial class WinTeacher : Window
    {
        public WinTeacher()
        {
            InitializeComponent();
        }

        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new AcademiaDBContext())
            {
                var newTeacher = new Teacher
                {
                    EmploymentDate = EmploymentDatePicker.SelectedDate ?? DateTime.Now, // Используйте выбранную дату или текущую дату
                    Name = NameTextBox.Text,
                    Premium = decimal.Parse(PremiumTextBox.Text),
                    Salary = decimal.Parse(SalaryTextBox.Text),
                    Surname = SurnameTextBox.Text
                };

                context.Teacher.Add(newTeacher);
                context.SaveChanges();

                MessageBox.Show("Запись успешно добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очистите текстовые поля после добавления записи
                EmploymentDatePicker.SelectedDate = null;
                NameTextBox.Clear();
                PremiumTextBox.Clear();
                SalaryTextBox.Clear();
                SurnameTextBox.Clear();
            }
        }
        private void MainWin_Click(object sender, RoutedEventArgs e)
        {
            MainWindow win = new MainWindow();
            this.Close();
            win.ShowDialog();



        }
    }


}

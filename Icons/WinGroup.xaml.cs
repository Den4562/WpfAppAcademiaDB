using System;
using System.Windows;
using WpfAppAcademia.Tables;

namespace WpfAppAcademia.Icons
{
    /// <summary>
    /// Логика взаимодействия для WinGroup.xaml
    /// </summary>
    public partial class WinGroup : Window
    {
        public WinGroup()
        {
            InitializeComponent();
        }


        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new AcademiaDBContext()) // Замените YourDbContext на имя вашего контекста
            {
                var newGroup = new Group
                {
                    Name = NameTextBox.Text,
                    Rating = int.Parse(RatingTextBox.Text),
                    Year = int.Parse(YearTextBox.Text)
                };

                context.Group.Add(newGroup);
                context.SaveChanges();

                MessageBox.Show("Запись успешно добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очистите текстовые поля после добавления записи
                NameTextBox.Clear();
                RatingTextBox.Clear();
                YearTextBox.Clear();
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

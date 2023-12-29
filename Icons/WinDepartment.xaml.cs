using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAppAcademia.Tables;

namespace WpfAppAcademia.Icons
{
    /// <summary>
    /// Логика взаимодействия для WinDepartment.xaml
    /// </summary>
    public partial class WinDepartment : Window
    {
        public WinDepartment()
        {
            InitializeComponent();
        }

        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new AcademiaDBContext()) // Замените YourDbContext на имя вашего контекста
            {
                var newDepartment = new Department
                {
                    Name = NameTextBox.Text,
                    Financing = decimal.Parse(FinancingTextBox.Text)
                };

                context.Department.Add(newDepartment);
                context.SaveChanges();

                MessageBox.Show("Запись успешно добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очистите текстовые поля после добавления записи
                NameTextBox.Clear();
                FinancingTextBox.Clear();
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

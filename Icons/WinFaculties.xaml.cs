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
    /// Логика взаимодействия для WinFaculties.xaml
    /// </summary>
    public partial class WinFaculties : Window
    {
        public WinFaculties()
        {
            InitializeComponent();
        }
        private void AddFaculties_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new AcademiaDBContext()) 
            {
                var newFaculties = new Faculties
                {
                    Name = NameTextBox.Text
                };

                context.Faculties.Add(newFaculties);
                context.SaveChanges();

                MessageBox.Show("Запись успешно добавлена", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                // Очистите текстовые поля после добавления записи
                NameTextBox.Clear();
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

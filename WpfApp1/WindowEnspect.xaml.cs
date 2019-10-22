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
using System.Data;
using MySql.Data.MySqlClient;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для WindowEnspect.xaml
    /// </summary>
    public partial class WindowEnspect : Window
    {
        MySqlConnection connection;
        public DataRowView view2;
        public DataTable table2;
        DataRowView view;
        public WindowEnspect()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Drivers drivers = new Drivers();
            this.Close();
            drivers.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();
                // Из данного условия мы вытаскиваем два нужных нам значения ВУ:  Серию и Номер.
                MySqlCommand command = new MySqlCommand($"SELECT * FROM driverLic WHERE driverLic.drivers = '{view2["iddrivers"].ToString()}'", connection);
                MySqlDataReader reader1 = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader1);
                // Из условия, данного ниже, мы выбираем нужную нам таблицу.
                MySqlCommand sqlCommand = new MySqlCommand($"SELECT *, drivers.Name as NameDrivers FROM driverLic LEFT JOIN kategories ON driverLic.kategories = kategories.idketogries LEFT JOIN drivers ON driverlic.drivers = drivers.iddrivers group by '{table.Rows[0]["Seria"].ToString()}' + '{table.Rows[0]["Number"].ToString()}'", connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(reader);
                dataGrid.ItemsSource = data.DefaultView;
                reader.Close();
                table2 = data;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            view = dataGrid.SelectedItem as DataRowView;
            if(table2.Rows[0]["Status"].ToString() == "1")
            {
                MySqlCommand command1 = new MySqlCommand($"UPDATE driverLic SET Status = '0' WHERE driverLic.drivers = '{view2["iddrivers"].ToString()}'", connection);
                command1.ExecuteNonQuery();
                MessageBox.Show("Права успешно изъяты!");
                UpdateGrid();
            }
            else if(table2.Rows[0]["Status"].ToString() == "0")
            {
                view = dataGrid.SelectedItem as DataRowView;
                MySqlCommand command = new MySqlCommand($"UPDATE driverLic SET Status = '1' WHERE driverLic.drivers = '{view2["iddrivers"].ToString()}'", connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Права успешно выданы!");
                UpdateGrid();
            }
        }
        void UpdateGrid()
        {
            // Из данного условия мы вытаскиваем два нужных нам значения ВУ:  Серию и Номер.
            MySqlCommand command = new MySqlCommand($"SELECT * FROM driverLic WHERE driverLic.drivers = '{view2["iddrivers"].ToString()}'", connection);
            MySqlDataReader reader1 = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader1);
            if (table.Rows[0]["Status"].ToString() == "1")
            {
                // Из условия, данного ниже, мы выбираем нужную нам таблицу.
                MySqlCommand sqlCommand = new MySqlCommand($"SELECT *, drivers.Name as NameDrivers FROM driverLic LEFT JOIN kategories ON driverLic.kategories = kategories.idketogries LEFT JOIN drivers ON driverlic.drivers = drivers.iddrivers group by '{table.Rows[0]["Seria"].ToString()}' + '{table.Rows[0]["Number"].ToString()}'", connection);
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                DataTable data = new DataTable();
                data.Load(reader);
                dataGrid.ItemsSource = data.DefaultView;
                reader.Close();
                table2 = data;
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Сеанс завершён!");
            Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            Addlic licenses = new Addlic();
            licenses.rowView = view2 as DataRowView;
            licenses.ShowDialog();
            UpdateGrid();
        }
    }
}

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
    /// Логика взаимодействия для BackSIde.xaml
    /// </summary>
    public partial class BackSIde : Window
    {
        MySqlConnection connection;
        public DataRowView rowView;
        public BackSIde()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();

            MySqlCommand command = new MySqlCommand($"SELECT * FROM driverLic LEFT JOIN kategories ON driverlic.kategories = kategories.idketogries WHERE driverLic.drivers = '{rowView["iddrivers"].ToString()}'",connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dataReader);
            dataGrid.ItemsSource = table.DefaultView;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }
    }
}

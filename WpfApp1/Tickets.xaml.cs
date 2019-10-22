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
    /// Логика взаимодействия для Tickets.xaml
    /// </summary>
    public partial class Tickets : Window
    {
        MySqlConnection connection;
        public DataRowView rowView;
        public Tickets()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();
            MySqlCommand command = new MySqlCommand($"SELECT * FROM tickets LEFT JOIN drivers ON tickets.drivers = drivers.iddrivers WHERE tickets.drivers = '{rowView["iddrivers"].ToString()}'",connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGrid.ItemsSource = data.DefaultView;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                string url = (dataGrid.SelectedItem as DataRowView)["photo"].ToString();
                bitmap.UriSource = new Uri(Environment.CurrentDirectory + @"\img\" + url);
                bitmap.EndInit();
                image.Source = bitmap;
            }
        }
        private void UpdateGrid()
        {
            MySqlCommand command = new MySqlCommand($"SELECT * FROM tickets LEFT JOIN drivers ON tickets.drivers = drivers.iddrivers WHERE tickets.drivers = '{rowView["iddrivers"].ToString()}'", connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            DataTable data = new DataTable();
            data.Load(dataReader);
            dataGrid.ItemsSource = data.DefaultView;
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedIndex != -1)
            {
                mediaElement.Source = new Uri(Environment.CurrentDirectory + @"\Video\" + (dataGrid.SelectedItem as DataRowView)["video"].ToString());
            }

        }
    }
}

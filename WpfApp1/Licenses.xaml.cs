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
    /// Логика взаимодействия для Licenses.xaml
    /// </summary>
    public partial class Licenses : Window
    {
        MySqlConnection connection;
        public DataRowView rowView;
        public Licenses()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();
            textBox.Text = rowView["MiddleName"].ToString();
            textBox1.Text = rowView["Name"].ToString();

            BitmapImage image1 = new BitmapImage();
            image1.BeginInit();
            image1.UriSource = new Uri(Environment.CurrentDirectory + @"\img\" + rowView["photo"].ToString());
            image1.EndInit();
            image.Source = image1;
            MySqlCommand command = new MySqlCommand($"SELECT * FROM driverLic LEFT JOIN kategories ON driverLic.kategories = kategories.idketogries WHERE driverLic.drivers = '{rowView["iddrivers"].ToString()}'", connection);
            MySqlDataReader dataReader2 = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dataReader2);
            datePicker1.SelectedDate = DateTime.Parse(rowView["DateBirth"].ToString());
            datePicker2.SelectedDate = DateTime.Parse(table.Rows[0]["DateStart"].ToString());
            datePicker3.SelectedDate = DateTime.Parse(table.Rows[0]["DateEnd"].ToString());
            textBox3.Text = table.Rows[0]["Seria"].ToString() + " " + table.Rows[0]["Number"].ToString();
            textBox4.Text = rowView["adress"].ToString();
            string kategories = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                kategories += table.Rows[i]["Name"].ToString() + ", ";
            }
            textBox5.Text = kategories.ToString();
            dataReader2.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BackSIde sIde = new BackSIde();
            sIde.rowView = rowView;
            sIde.ShowDialog();
        }
    }
}

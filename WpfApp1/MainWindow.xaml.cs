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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int s;
        MySqlConnection connection;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //label3.Content = VIN_LIB.VINLib.CheckVIN("3FA6P0HD2ER107416").ToString();
            //label4.Content = VIN_LIB.VINLib.GetVINCountry("3FA6P0HD2ER107416").ToString();
           // label5.Content = VIN_LIB.VINLib.GetTransporYear("3FA6P0HD2ER107416").ToString();
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();
            
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MySqlCommand command = new MySqlCommand($"SELECT * FROM user WHERE login ='{textBox.Text}' AND Password = '{textBox1.Text}'",connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dataReader);
            if (textBox.Text != "" && textBox1.Text != "")
            {
                if (table.Rows.Count > 0)
                {
                    MessageBox.Show("Welcome!");
                    Drivers drivers = new Drivers();
                    this.Close();
                    drivers.ShowDialog();
                }
                else
                {
                    if(s==2)
                    {
                        MessageBox.Show("Не правильно введённые данные. Для следующего входа подождите 5 секунд!");
                        button.IsEnabled = false;
                        Thread.Sleep(5000);
                        s = 0;
                        button.IsEnabled = true;
                        MySqlCommand command1 = new MySqlCommand("INSERT INTO nevlog (nomerPK, data) Values (@nomerPK, @data)", connection);
                        command1.Parameters.Add("nomerPK", MySqlDbType.VarChar).Value = Environment.MachineName;
                        command1.Parameters.Add("data", MySqlDbType.DateTime).Value = DateTime.Now.ToString("yyyy-M-dd HH:MM:ss");
                        command1.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Проверьте правильность введёных данных!");
                        s = s + 1;
                    }
                    
                }
            }
        }
    }
}

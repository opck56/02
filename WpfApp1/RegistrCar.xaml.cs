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
    /// Логика взаимодействия для RegistrCar.xaml
    /// </summary>
    public partial class RegistrCar : Window
    {
        public DataRowView view;
        public bool VinIsCorrect  = false;
        MySqlConnection connection;
        public string nom= "";
        public RegistrCar()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox9.Text != "")
            {
                if(VIN_LIB.VINLib.CheckVIN(textBox9.Text))
                {
                    MessageBox.Show("VIN номер транспортного средства верный!");
                    VinIsCorrect = true;
                }
                else
                {
                    MessageBox.Show("Проверьте правильность введёного VIN номера");
                    VinIsCorrect = false;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && VinIsCorrect == true)
            {
                MySqlCommand command = new MySqlCommand($"INSERT INTO registrcar (Marka, Model, TipTS, KategoryTS, godVipuska, Color, PowerEngine, MinWeight, MaxWeight, VinNomer, NomerTS, Drivers) Values ('{textBox.Text}','{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}', '{textBox4.Text}', '{textBox5.Text}', '{textBox6.Text}', '{textBox7.Text}', '{textBox8.Text}', '{VinIsCorrect}', '{REG_MARK_LIB.Class1.GetNextMarkAfter(GetLastNumber()).ToString().ToUpper()}', '{view["iddrivers"].ToString()}')",connection);
                command.ExecuteNonQuery();
                MessageBox.Show("Получен номер " + REG_MARK_LIB.Class1.GetNextMarkAfter(GetLastNumber()).ToString().ToUpper());
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Drivers drivers = new Drivers();
            this.Close();
            drivers.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();
        }
        public string GetLastNumber()
        {
            MySqlCommand command = new MySqlCommand($"SELECT NomerTS FROM registrcar ORDER BY idregistrcar DESC LIMIT 1", connection);
            string nomer = command.ExecuteScalar().ToString();
            return nomer;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }
    }
}

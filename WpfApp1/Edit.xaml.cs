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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        MySqlConnection connection;
        public DataRowView rowView;
        public Edit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            Drivers drivers = new Drivers();
            this.Close();
            drivers.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();
            textBox.Text = rowView["Name"].ToString();
            textBox2.Text = rowView["MiddleName"].ToString();
            textBox3.Text = rowView["passportSerial"].ToString();
            textBox7.Text = rowView["passportNumber"].ToString();
            textBox4.Text = rowView["postcode"].ToString();
            textBox5.Text = rowView["adress"].ToString();
            textBox6.Text = rowView["adressLife"].ToString();
            textBox8.Text = rowView["jobname"].ToString();
            textBox9.Text = rowView["phone"].ToString();
            textBox10.Text = rowView["email"].ToString();
            MySqlCommand command = new MySqlCommand("SELECT * FROM Company",connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(dataReader);
            comboBox.ItemsSource = table.DefaultView;
            comboBox.DisplayMemberPath = "Name";
            dataReader.Close();
        }


        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            DataRowView data = comboBox.SelectedItem as DataRowView;
            if (comboBox.SelectedIndex != -1 && textBox.Text != "" && textBox2.Text != "" && textBox3.Text != "" &&  textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "" && datePicker1.SelectedDate.HasValue)
            {
                MySqlCommand command = new MySqlCommand($"UPDATE drivers SET Name = '{textBox.Text}', MiddleName = '{textBox2.Text}', passportSerial = '{textBox3.Text}', passportNumber = '{textBox7.Text}', postcode = '{textBox4.Text}', adress = '{textBox5.Text}', adressLife = '{textBox6.Text}', company = '{data["idcompany"].ToString()}', jobname = '{textBox8.Text}', phone = '{textBox9.Text}', email = '{textBox10.Text}', DateBirth = '{datePicker1.SelectedDate.Value.ToString("yyyy-M-dd")}' WHERE iddrivers = '{rowView["iddrivers"].ToString()}'", connection);
                command.ExecuteNonQuery();
                Drivers drivers = new Drivers();
                this.Close();
                drivers.ShowDialog();
            }
            else
            {
                MessageBox.Show("Введите все нужные значения!");
            }
        }
    }
}

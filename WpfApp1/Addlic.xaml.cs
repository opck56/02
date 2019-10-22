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
    /// Логика взаимодействия для Addlic.xaml
    /// </summary>
    public partial class Addlic : Window
    {
        public DataRowView rowView;
        MySqlConnection connection;
        public Addlic()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();
            textBox.Text = rowView["Name"].ToString();
            textBox2.Text = rowView["MiddleName"].ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        void Kategories(CheckBox checkBox)
        {
            string idkategories = "";
            MySqlCommand command = new MySqlCommand($"SELECT idketogries FROM kategories WHERE Name = '{checkBox.Content}'" ,connection);
            command.ExecuteScalar().ToString();
            idkategories = command.ExecuteScalar().ToString();
            MySqlCommand sqlCommand = new MySqlCommand($"INSERT INTO driverLic (drivers, kategories, DateStart, DateEnd, Status, Seria, Number) VALUES ('{rowView["iddrivers"].ToString()}', '{idkategories}', '{DateTime.Now.ToString("yyyy-M-dd")}', '{DateTime.Now.AddYears(10).ToString("yyyy-M-dd")}', '1', '{textBox3.Text}', '{textBox4.Text}')", connection);
            sqlCommand.ExecuteNonQuery();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ()
            {

            }
            else if ()
            {
                if (checkbox.IsChecked == true)
                {
                    Kategories(checkbox);
                }

                if (checkbox2.IsChecked == true)
                {
                    Kategories(checkbox2);
                }
                if (checkbox3.IsChecked == true)
                {
                    Kategories(checkbox3);
                }
                if (checkbox4.IsChecked == true)
                {
                    Kategories(checkbox4);
                }

                if (checkbox5.IsChecked == true)
                {
                    Kategories(checkbox5);
                }
                if (checkbox6.IsChecked == true)
                {
                    Kategories(checkbox6);
                }
                if (checkbox7.IsChecked == true)
                {
                    Kategories(checkbox7);
                }

                if (checkbox8.IsChecked == true)
                {
                    Kategories(checkbox8);
                }
                if (checkbox9.IsChecked == true)
                {
                    Kategories(checkbox9);
                }
                if (checkbox10.IsChecked == true)
                {
                    Kategories(checkbox);
                }

                if (checkbox11.IsChecked == true)
                {
                    Kategories(checkbox11);
                }
                if (checkbox12.IsChecked == true)
                {
                    Kategories(checkbox12);
                }
                this.Close();
            }
        }
    }
}

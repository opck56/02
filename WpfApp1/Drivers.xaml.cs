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
using VIN_LIB;
using REG_MARK_LIB;
using System.IO;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Drivers.xaml
    /// </summary>
    public partial class Drivers : Window
    {
        MySqlConnection connection;
        public DataTable table;
        public Drivers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            connection = new MySqlConnection("server=localhost; uid=root; pwd=student123; database=gibdd");
            connection.Open();
            //label1.Content = VINLib.CheckVIN(/*"JF1BC7BL0EG025399"*/ "3FA6P0HD2ER107416").ToString();
            //label.Content = VINLib.GetVINCountry("3FA6P0HD2ER107416").ToString();
            //label2.Content = VINLib.GetTransporYear("3FA6P0HD2ER107416").ToString();
            //label3.Content = REG_MARK_LIB.Class1.CheckMark("A888AA777").ToString();
            //label4.Content = Class1.GetNextMarkAfter("X999XX777").ToString();
            MySqlCommand command = new MySqlCommand("SELECT * FROM drivers", connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            table = dataTable;
            dataTable.Columns.Add("Image");
            for (int i=0; i < dataTable.Rows.Count; i++)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(Environment.CurrentDirectory + @"\img\" + dataTable.Rows[i]["Photo"].ToString());
                image.EndInit();
                dataTable.Rows[i]["Image"] = image;
            }
            dataGrid1.ItemsSource = dataTable.DefaultView;
            table = dataTable;
            dataReader.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            connection.Close();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex != -1)
            {
                Licenses licenses = new Licenses();
                licenses.rowView = dataGrid1.SelectedItem as DataRowView;
                licenses.ShowDialog();
                Update_Grid();
            }
            else
            {
                MessageBox.Show("Выберите водителя!");
            }
        }
        private void Update_Grid()
        {
            MySqlCommand command = new MySqlCommand("SELECT * FROM drivers", connection);
            MySqlDataReader dataReader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(dataReader);
            dataTable.Columns.Add("Image");
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(Environment.CurrentDirectory + @"\img\" + dataTable.Rows[i]["Photo"].ToString());
                image.EndInit();
                dataTable.Rows[i]["Image"] = image;
            }
            dataGrid1.ItemsSource = dataTable.DefaultView;
            dataReader.Close();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex != -1)
            {
                Edit edit = new Edit();
                edit.rowView = dataGrid1.SelectedItem as DataRowView;
                this.Close();
                edit.ShowDialog();
                Update_Grid();
            }
            else
            {
                MessageBox.Show("Выберите водителя!");
            }
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex != -1)
            {
                RegistrCar car = new RegistrCar();
                car.view = dataGrid1.SelectedItem as DataRowView;
                this.Close();
                car.ShowDialog();
            }
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button4_Click_1(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex != -1)
            {
                WindowEnspect enspect = new WindowEnspect();
                enspect.view2 = dataGrid1.SelectedItem as DataRowView;
                this.Close();
                enspect.ShowDialog();
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid1.SelectedIndex != -1)
            {
                Tickets tickets = new Tickets();
                tickets.rowView = dataGrid1.SelectedItem as DataRowView;
                this.Close();
                tickets.ShowDialog();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter(Environment.CurrentDirectory + "\\text1.csv");
            sw.WriteLine("id|name|MiddleName|Adress");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                sw.WriteLine(table.Rows[i]["iddrivers"].ToString() + " | " + table.Rows[i]["name"].ToString() + " | " + table.Rows[i]["Middlename"].ToString() + " | " + table.Rows[i]["adress"].ToString());
            }
            sw.Close();
            MessageBox.Show("Данные экспортированы!");
        }
    }
}

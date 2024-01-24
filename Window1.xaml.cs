using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Aquatoria
{
  
    public partial class Window1 : Window
    {
        static SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Car; Integrated Security=SSPI;");
        public Window1()
        {
            InitializeComponent();
            try
            {
                string selectString = @"Use Car﻿ select Orders.ID, Orders.NumberBox, Orders.DateOrder, Orders.StatusOrder, Services.Discriptions  from Orders, Services, OrderServices where (Orders.IDWorker = OrderServices.IDOrder AND Services.ID = OrderServices.IDSevices) AND Orders.StatusOrder = 0";
                conn.Open();
                SqlCommand cmd = new SqlCommand(selectString, conn);

                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        OrderBlock.Text += read[i] + "\t";
                    }
                    OrderBlock.Text += "\n";

                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка в подключении БД");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}

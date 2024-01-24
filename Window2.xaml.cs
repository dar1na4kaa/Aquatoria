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
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        static SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Акватория; Integrated Security=SSPI;");
        public Window2()
        {
            InitializeComponent();
            try
            {
                string selectString = @"Use [Акватория] select Orders.ID, Orders.NumberBox, Orders.DateOrder, Orders.StatusOrder, Services.Discriptions  from Orders, Services, OrderServices where (Orders.IDWorker = OrderServices.IDOrder AND Services.ID = OrderServices.IDSevices) AND Orders.StatusOrder = 0";
                conn.Open();
                SqlCommand cmd = new SqlCommand(selectString, conn);

                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    for (int i = 0; i < read.FieldCount; i++)
                    {
                        BlockTextBox.Text += read[i] + "\t";
                    }
                    BlockTextBox.Text += "\n";

                }
                conn.Close();
            }
            catch
            {
                MessageBox.Show("Ошибка в подключении БД");

            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace MS_Library_Services
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if ((susr.Text == "") && (spass.Password == ""))
            {
                Staff_Loged_in logged = new Staff_Loged_in();
                logged.Show();
                this.Close();
                //string Path1 = System.Environment.CurrentDirectory;
                //string ttt = Directory.GetCurrentDirectory();
            }
            else
            {
                MessageBox.Show("Wrong Password!");
            }

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT password from slibrary where id= susr.Text",con);
            //String p1;
            //sda.Fill(p1);
            //if(spass.Password == p1 )
                //MessageBox.Show("Success!");
        }

        

        private void button0_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main1 = new MainWindow();
            this.Close();
            MessageBox.Show(" Thanks for using this Software.");
        }

        private void button10_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main1 = new MainWindow();
            this.Close();
            MessageBox.Show(" Thanks for using this Software.");
        }
    }
}



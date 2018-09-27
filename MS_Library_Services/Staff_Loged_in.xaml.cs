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
using System.Windows.Shapes;
using System.Data;
using System.Configuration;
using System.Globalization;  // For date, time etc.
using System.Data.SqlClient;


namespace MS_Library_Services
{
    /// <summary>
    /// Interaction logic for Staff_Loged_in.xaml
    /// </summary>
    public partial class Staff_Loged_in : Window
    {
        //Background:

        /*<Window.Background>
        <LinearGradientBrush EndPoint="1,0.5" StartPoint="0,0.5">
            <GradientStop Color="Black" Offset="0" />
            <GradientStop Color="White" Offset="0.494" />
        </LinearGradientBrush>
    </Window.Background>*/


        /*
         <TabControl.Background>
                    <RadialGradientBrush>
                        <GradientStop Color="Coral" Offset="0.215" />
                        <GradientStop Color="#FFDBDB84" Offset="1" />
                        <GradientStop Color="#FFD4D47B" Offset="1" />
                    </RadialGradientBrush>
                </TabControl.Background>
         */


        /*void isenabled(String id)
        { 
            // Connect to database, call this method in all below functions.pass id each time.
            //if not enabled, Show error message. Thats it.

            SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\documents\visual studio 2010\Projects\MS_Library_Services\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True");
            string query = "SELECT disabled from student where id = '" + studentid.Text + "'";
            con.Open();
            SqlCommand com = new SqlCommand(query, con);
            con.Close();
        }*/
        public Staff_Loged_in()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /*SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\documents\visual studio 2010\Projects\MS_Library_Services\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True";
            string query = "SELECT quantity from book where bookid ";
            con.Open();
            con.Close();*/
        }
        private void sadd_Click(object sender, RoutedEventArgs e) // Edit here and include Update query if ID Exists.
        {
            //string s = "Enabled";
            try
            {
                //C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                DateTime now = DateTime.Now;
                cmd.CommandText = "Insert into book (bookid, quantity, date) Values (@bookid, @quantity, @date)";
                cmd.Parameters.AddWithValue("@bookid", addid.Text);
                cmd.Parameters.AddWithValue("@quantity", addq.Text);
                cmd.Parameters.AddWithValue("@date", now);  //It displays Only date value
                //cmd.Parameters.AddWithValue("@disabled", "Enabled");
                if ((addid.Text == "") && (addq.Text == ""))
                {
                    MessageBox.Show("Feild(s) cannot be blank!");
                }
                else
                {
                    cmd.Connection = con;
                    int a = cmd.ExecuteNonQuery();
                    if (a == 1)
                    {
                        MessageBox.Show("Sucess! Books were Added to Database.");
                    }
                    else
                        MessageBox.Show("FAILED: Books cant be Added!");
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ebtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow s = new MainWindow();
            s.Show();
            this.Close();
        }

        private void adds_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int en = 0; // disbled column is 0.
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True";
                con.Open();
                SqlCommand cmd = new SqlCommand();
                DateTime now = DateTime.Now;
                cmd.CommandText = "Insert into student (id, name, phone, adress, date, disabled) Values (@id, @name, @phone, @adress, @date, @enable)";
                cmd.Parameters.AddWithValue("@id", stid.Text);
                cmd.Parameters.AddWithValue("@name", stname.Text);
                cmd.Parameters.AddWithValue("@phone", stph.Text);
                cmd.Parameters.AddWithValue("@adress", stad.Text);
                cmd.Parameters.AddWithValue("@date", now);
                cmd.Parameters.AddWithValue("@enable", en);
                if ((stid.Text == "") || (stname.Text == "") || (stph.Text == "") || (stad.Text == ""))
                {
                    MessageBox.Show("Feild(s) cannot be blank!");
                }
                else
                {
                    cmd.Connection = con;
                    int a = cmd.ExecuteNonQuery();
                    if (a == 1)
                    {
                        MessageBox.Show("Sucess! Student was Added to Database.");
                    }
                    else
                        MessageBox.Show("FAILED: Student cant be Added. "); // If student ID exists display that message.
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void disable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int de = 1;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True";
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE student SET disabled = @disabled Where id = '"+did.Text+"'");
                cmd.Parameters.AddWithValue("@disabled", de); // 0 for disabling.
                cmd.Connection = con;
                int a = cmd.ExecuteNonQuery();
                if (a == 1)
                {
                    MessageBox.Show("Sucess! Student was disabled from Database.");
                }
                else
                    MessageBox.Show("FAILED: Try Again!");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
        //Staff_Loged_in: Window window1 = new Staff_Loged_in(studentid.Text);
            try
            {
                SqlConnection con3 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True");
                string query3 = "SELECT disabled from student where id = '" + isid.Text + "'";
                con3.Open();
                SqlCommand com3 = new SqlCommand(query3, con3);
                SqlDataReader reader3 = com3.ExecuteReader();
                reader3.Read();
                int dis = Convert.ToInt32(reader3.GetValue(0));
                reader3.Close();
                con3.Close();
                if (dis == 0)
                {
                    try
                    {
                        String j = studentid.Text;
                        //void isenabled(j);
                        String pq, cq = "0"; //pq for previous value of quantity and cq for changed quantity.
                        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True");
                        string query = "SELECT quantity from book where bookid = '" + studentid.Text + "'";
                        con.Open();
                        SqlCommand com = new SqlCommand(query, con);
                        SqlDataReader reader = com.ExecuteReader();
                        reader.Read();
                        pq = reader.GetValue(0).ToString();
                        reader.Close();
                        int x = Convert.ToInt32(studentq.Text);
                        int y = Convert.ToInt32(pq);
                        int z = Convert.ToInt32(cq);
                        z = y - x;
                        String s2 = Convert.ToString(z);
                        con.Close();
                        string query2 = "UPDATE book SET quantity = '" + s2 + "' WHERE bookid='" + studentid.Text + "'";
                        con.Open();
                        SqlCommand comm = new SqlCommand(query2, con);
                        SqlDataReader reader2 = comm.ExecuteReader();
                        reader2.Close();
                        MessageBox.Show("Issued! Please colect your book from 'COUNTER'. (" + s2 + ")");
                        con.Close();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(" Sorry! You are disabled. Please contct Librarian. ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ebtn1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.Show();
        }
        private void button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection con4 = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True");
                string query4 = "SELECT disabled from student where id = '" + isid2.Text + "'";
                con4.Open();
                SqlCommand com4 = new SqlCommand(query4, con4);
                SqlDataReader reader4 = com4.ExecuteReader();
                reader4.Read();
                int dis = Convert.ToInt32(reader4.GetValue(0));
                reader4.Close();
                con4.Close();
                if (dis == 0)
                {
                    try
                    {
                        String pq, cq = "0"; //pq for previous value of quantity and cq for changed quantity.
                        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True");
                        string query = "SELECT quantity from book where bookid = '" + rid.Text + "'";
                        con.Open();
                        SqlCommand com = new SqlCommand(query, con);
                        SqlDataReader reader = com.ExecuteReader();
                        reader.Read();
                        pq = reader.GetValue(0).ToString();
                        reader.Close();
                        int x = Convert.ToInt32(rq.Text);
                        int y = Convert.ToInt32(pq);
                        int z = Convert.ToInt32(cq);
                        z = y + x;
                        String s2 = Convert.ToString(z);
                        con.Close();



                        // Computing Fine:
                        // Updating database with new values after book returned. 
                        // And checking that wether consumer kept book for more than 8 days!

                        int fine;
                        string query2 = "UPDATE book SET quantity = '" + s2 + "' WHERE bookid='" + rid.Text + "'";
                        con.Open();
                        SqlCommand comm = new SqlCommand(query2, con);
                        SqlDataReader reader2 = comm.ExecuteReader();
                        reader2.Close();
                        con.Close();
                        string query3 = "SELECT date from book where bookid = '" + rid.Text + "'";
                        con.Open();
                        SqlCommand comm3 = new SqlCommand(query3, con);
                        SqlDataReader reader3 = comm3.ExecuteReader();
                        reader3.Read();
                        String fi = reader3.GetValue(0).ToString();
                        reader3.Close();
                        String now = DateTime.Now.ToShortDateString();
                        double d = (Convert.ToDateTime(now) - Convert.ToDateTime(fi)).TotalDays;
                        if (d > 8)  // for more than 8 days
                        {
                            fine = Convert.ToInt32(d * 10 * (Convert.ToInt32(rq.Text))); // Fine of Rs.10 per day! :-)
                            MessageBox.Show("Done! Please submit book at 'COUNTER'! Fine:");
                            MessageBox.Show(fine.ToString());
                        }
                        else
                        {
                            MessageBox.Show("Done! Please submit book at 'COUNTER'!");
                        }
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show(" Sorry! User is disabled. Please contct Librarian. ");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            /*SqlConnection con = new SqlConnection();
            con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=MC:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdfS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True";
            con.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM student WHERE id = '" + did.Text+"'");
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted!");
                con.Close();*/
                SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True");
                string query = "DELETE FROM student WHERE id = '" + did.Text + "'";
                con.Open();
                SqlCommand com = new SqlCommand(query, con);
                int a = com.ExecuteNonQuery();
                if (a == 1)
                {
                    MessageBox.Show("Sucess! Student was DELETED from Database.");
                }
                else
                    MessageBox.Show("FAILED: Try Again!");
                con.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void enable_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int en = 0; // enable=0, i.e disabled!
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\manju\Desktop\Engg._Study_Materials\III SEM\VAP\MS_Library_Services build_260916(UPDATED_DESIGN)\MS_Library_Services\dbinfo.mdf;Integrated Security=True;User Instance=True";
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE student SET disabled = @disabled Where id = '" + did.Text + "'");
                cmd.Parameters.AddWithValue("@disabled", en);
                cmd.Connection = con;
                int a = cmd.ExecuteNonQuery();
                if (a == 1)
                {
                    MessageBox.Show("Sucess! Student was Enabled in Database.");
                }
                else
                    MessageBox.Show("FAILED: Try Again!");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            this.Close();
            m.Show();
        }

        private void view_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
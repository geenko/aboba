using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace program
{
    public partial class Menu : Form
    {

        SqlConnection SqlConnection;
        public Menu(int result)
        {
            InitializeComponent();
        }



        private void label5_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void Menu_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Gaming\source\repos\program\program\Database1.mdf;Integrated Security=True";

            SqlConnection = new SqlConnection(connectionString);

            await SqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM[bilet]", SqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["id_bilet"]) + " " + Convert.ToString(sqlReader["number_train"]) + " " + Convert.ToString(sqlReader["date"]) + " " + Convert.ToString(sqlReader["route"]));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }



        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (label6.Visible)
                label6.Visible = false;

            if
           (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))


            {
                SqlCommand command = new SqlCommand("INSERT INTO [bilet] (number_train, date, route) VALUES (@number_train, @date, @route)", SqlConnection);
                command.Parameters.AddWithValue("number_train", textBox1.Text);
                command.Parameters.AddWithValue("date", textBox2.Text);
                command.Parameters.AddWithValue("route", textBox3.Text);
                int v = await command.ExecuteNonQueryAsync();
                _ = v;
            }
            else
            {
                label6.Visible = true;
                label6.Text = "Заполните все поля!";

            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            
            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM[bilet]", SqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    listBox1.Items.Add(Convert.ToString(sqlReader["id_bilet"]) + " " + Convert.ToString(sqlReader["number_train"]) + " " + Convert.ToString(sqlReader["date"]) + " " + Convert.ToString(sqlReader["route"]));
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        

    }
}

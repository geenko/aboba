using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace program
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(Size.Width, 34);
            

        }

       

      

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CloseButton_MouseEnter(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.DarkSlateGray;
        }

        private void CloseButton_MouseLeave(object sender, EventArgs e)
        {
            CloseButton.ForeColor = Color.White;
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_user FROM users WHERE login ='" + loginField.Text + "' and password = '" + passField.Text + "';";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            try
            { 
            conn.Open();
            int result = 0;
            result = Convert.ToInt32(cmDB.ExecuteScalar());
            if (result > 1)
            {
                Menu Win = new Menu(result);
                Win.Owner = this;
                this.Hide();
                Win.Show();
                loginField.Clear();
                passField.Clear();
            }
            else
                MessageBox.Show("Возникла ошибка авторизации!");
            conn.Close();
            
            }
            catch (Exception ex)
            {
                MessageBox.Show("Возникла непредвиденная ошибка!" + Environment.NewLine + ex.Message);
            }

        }
    }
}

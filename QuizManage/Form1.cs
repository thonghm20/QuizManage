using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizManage
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         
            wrongLabel.Visible = false;
        }

       
        private void checkBoxShowHide_CheckedChanged(object sender, EventArgs e)
        {
             if(checkBoxShowHide.Checked == true)
            {
                textPassword.PasswordChar = '\0';
                checkBoxShowHide.Text = "Hide Password";

            }
            else
            {
                textPassword.PasswordChar = '*';
                checkBoxShowHide.Text = "Show Password";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="btechdays" && textPassword.Text == "btechdays")
            {
                wrongLabel.Visible = false;
                Teacher te = new Teacher();
                te.Show();
                this.Hide();
            }
            else
            {
                wrongLabel.Visible = true;
            }
        }
    }
}

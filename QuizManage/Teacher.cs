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
    public partial class Teacher : Form
    {
        public Teacher()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Teacher_Load(object sender, EventArgs e)
        {
            uC_Addnewquestions1.Visible = false;
            uC_UpdateQuestions1.Visible = false;
            uC_ViewDelete1.Visible = false;
        }

        private void btnAddnewQuestion_Click(object sender, EventArgs e)
        {
            uC_Addnewquestions1.Visible = true;
            uC_Addnewquestions1.BringToFront();
        }

        private void uC_Addnewquestions1_Load(object sender, EventArgs e)
        {
           
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateQuestions_Click(object sender, EventArgs e)
        {
            uC_UpdateQuestions1.Visible = true;
            uC_UpdateQuestions1.BringToFront();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            uC_ViewDelete1.Visible = true;
            uC_ViewDelete1.BringToFront();
        }
    }
}

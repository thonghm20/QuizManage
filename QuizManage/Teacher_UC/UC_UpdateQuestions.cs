using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuizManage.Teacher_UC
{
    public partial class UC_UpdateQuestions : UserControl
    {
        connectdatabase fn = new connectdatabase();
        String query;
        public UC_UpdateQuestions()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void UC_UpdateQuestions_Load(object sender, EventArgs e)
        {
            comboSet.Items.Clear();
            query = "select distinct qset from questions";
            DataSet ds = fn.GetData(query);
            for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                comboSet.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void comboSet_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboQuestion.Items.Clear();
            query = "select qNo from questions where qset = '"+comboSet.Text+"'";
            DataSet ds = fn.GetData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count;i++)
            {
                comboQuestion.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void comboQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select question,optionA,optionB,optionC,optionD,ans from questions where qset = '" + comboSet.Text + "' and qNo = '" + comboQuestion.Text + "'";
            DataSet ds = fn.GetData(query);
            txtQuestion.Text = ds.Tables[0].Rows[0][0].ToString();
            txtOption1.Text = ds.Tables[0].Rows[0][1].ToString();
            txtOption2.Text = ds.Tables[0].Rows[0][2].ToString();
            txtOption3.Text = ds.Tables[0].Rows[0][3].ToString();
            txtOption4.Text = ds.Tables[0].Rows[0][4].ToString();
            txtAns.Text = ds.Tables[0].Rows[0][5].ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        public void ClearAll()
        {
            txtQuestion.Clear();
            txtOption1.Clear();
            txtOption2.Clear();
            txtOption3.Clear();
            txtOption4.Clear();
            txtAns.Clear();
            comboSet.SelectedIndex = -1;
            comboQuestion.SelectedIndex = -1;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(comboQuestion.SelectedIndex != -1)
            {
                String qset = comboSet.Text;
                String qNo = comboQuestion.Text;
                String question = txtQuestion.Text;
                String option1 = txtOption1.Text;
                String option2 = txtOption2.Text;
                String option3 = txtOption3.Text;
                String option4 = txtOption4.Text;
                String ans = txtAns.Text;
                query = "update questions set question='"+question+"',optionA= '"+option1+"',optionB= '"+option2+ "',optionC= '"+option3+"',optionD= '"+option4+"',ans = '"+ans+"' where qset = '"+qset+"' and qNo = '"+qNo+"'";
                fn.setData(query, "Question No: " + qNo + " \n Question Set:" + qset + "\n is updated");

            }
            else
            {
                MessageBox.Show("Select Question First.", "Message !!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            UC_UpdateQuestions_Load(this, null);
        }
    }
}

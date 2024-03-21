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
    public partial class UC_Addnewquestions : UserControl
    {
        connectdatabase fn = new connectdatabase();
        String query;
        DataSet ds;
        Int64 questionNo = 1;
        public UC_Addnewquestions()
        {
           
            InitializeComponent();
        }

        private void UC_Addnewquestions_Load(object sender, EventArgs e)
        {
            query = "select max(qset) from questions";
            ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows[0][0].ToString()!= "") 
            {
                Int64 id = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
                txtSet.Text = (id + 1).ToString();
            }
            else
            {
                txtSet.Text = "1";
            }
            QuestionsLabel.Text = questionNo.ToString();
            labelNoset.Visible = false;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            String qset = txtSet.Text;
            String qNo = questionNo.ToString();
            String question = txtQuestion.Text;
            String option1 = txtOption1.Text;
            String option2 = txtOption2.Text;
            String option3 = txtOption3.Text;
            String option4 = txtOption4.Text;
            String ans = txtAnswer.Text;
            query = "insert into questions (qset,qNo,question,optionA,optionB,optionC,optionD,ans) values ('" + qset + "','" + qNo + "','" + question + "','" + option1 + "','" + option2 + "','" + option3 + "','" + option4 + "','" + ans + "')";
            fn.setData(query, "Question Added.");
            clearAll();
            questionNo++;
            QuestionsLabel.Text = questionNo.ToString();

        }
        public void clearAll()
        {
            txtQuestion.Clear();
            txtOption1.Clear();
            txtOption2.Clear();
            txtOption3.Clear();
            txtOption4.Clear();
            txtAnswer.Clear();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data Will be Lost", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                clearAll();
            }


                   }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data Will be Changed", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                txtSet.Text = (Int64.Parse(txtSet.Text.ToString()) + 1).ToString();
                QuestionsLabel.Text = "1";
            }
        }

        private void txtSet_TextChanged(object sender, EventArgs e)
        {
            if (txtSet.Text != "")
            {
                query = "select qNo from questions where qset = '" + txtSet.Text + "'";
                ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count != 0 && ds.Tables[0].Rows[0][0].ToString() != "")
                {
                    QuestionsLabel.Text = (ds.Tables[0].Rows.Count + 1).ToString();
                    questionNo = Int64.Parse(QuestionsLabel.Text.ToString());
                    labelNoset.Visible = false; // Ẩn labelNoset khi có dữ liệu trong DataSet
                }
                else
                {
                    QuestionsLabel.Text = "1";
                    questionNo = Int64.Parse(QuestionsLabel.Text.ToString());
                    labelNoset.Visible = true; // Hiển thị labelNoset khi không có dữ liệu trong DataSet
                }
            }
            else
            {
                labelNoset.Visible = false; // Ẩn labelNoset khi không nhập vào textbox
            }
        }


        private void txtOption1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtOption4_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelNoset_Click(object sender, EventArgs e)
        {

        }
    }
}

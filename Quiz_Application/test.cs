using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz_Application
{
    public partial class test : Form
    {
        int i,score=0;
        string correctop;
        public test()
        {
            InitializeComponent();
        }
        returnclass rc = new returnclass();
        private void test_Load(object sender, EventArgs e)
        {
            label3.Text = score.ToString();

            i=Convert.ToInt32(rc.scalarReturn("select min(q_id) from questions"));
            label1.Text=rc.scalarReturn("select q_title from questions where q_id=" + i);
            radioButton1.Text = rc.scalarReturn("select q_opa from questions where q_id=" + i);
            radioButton2.Text = rc.scalarReturn("select q_opb from questions where q_id=" + i);
            radioButton3.Text = rc.scalarReturn("select q_opc from questions where q_id=" + i);
            radioButton4.Text = rc.scalarReturn("select q_opd from questions where q_id=" + i);

            correctop= rc.scalarReturn("select q_opcorrect from questions where q_id=" + i);
        }
        string s,selectedvalue;
        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                selectedvalue = radioButton1.Text;
            }
            else if(radioButton2.Checked == true)
            {
                selectedvalue = radioButton2.Text;
            }
            else if(radioButton3.Checked == true)
            {
                selectedvalue = radioButton3.Text;
            }
            else if(radioButton4.Checked == true)
            {
                selectedvalue = radioButton4.Text;
            }
            else
            {
                MessageBox.Show("Please select one option!");
            }
            if(selectedvalue.Equals(correctop))
            {
                score++;
                label3.Text = score.ToString();
            }

            s = rc.scalarReturn("select min(q_id) from questions where q_id>"+i);
            if (s.Equals(""))
            {
                MessageBox.Show("Quiz Over!");
                button1.Enabled = false;
            }
            else
            {
                i = Convert.ToInt32(s);

                label1.Text = rc.scalarReturn("select q_title from questions where q_id=" + i);
                radioButton1.Text = rc.scalarReturn("select q_opa from questions where q_id=" + i);
                radioButton2.Text = rc.scalarReturn("select q_opb from questions where q_id=" + i);
                radioButton3.Text = rc.scalarReturn("select q_opc from questions where q_id=" + i);
                radioButton4.Text = rc.scalarReturn("select q_opd from questions where q_id=" + i);

                correctop = rc.scalarReturn("select q_opcorrect from questions where q_id=" + i);
            }
            radiobtn();
        }
        public void radiobtn()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quiz_Application
{
    public partial class Studentlogin : Form
    {
        public static string exam_id;
        public Studentlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb, passworddb;

            returnclass rc = new returnclass();

            userdb = rc.scalarReturn("select count(std_id) from student_record where std_id=" + textBox1.Text);

            if (userdb.Equals("0"))
            {
                MessageBox.Show("Invalid User Name");
            }
            else
            {
                passworddb = rc.scalarReturn("select std_passward from student_record where std_id=" + textBox1.Text);
                if (passworddb.Equals(password))
                {

                    string val = rc.scalarReturn("select count(std_id) from student_record where std_id=(select stu_id_fk from set_exam where stu_id_fk="+textBox1.Text+" and exam_id_fk="+comboBox1.SelectedValue.ToString()+")");
                    if (userdb.Equals("0"))
                    {
                        exam_id = comboBox1.SelectedValue.ToString();
                        MessageBox.Show("No Exam Set");
                    }
                    else
                    {
                        test t = new test();
                        t.Show();
                        this.Hide();
                    }


                }
                else
                {
                    MessageBox.Show("Invalid Password");
                }
            }
        }

        private void Studentlogin_Load(object sender, EventArgs e)
        {

            SqlDataAdapter dadpter2 = new SqlDataAdapter("select * from exams", "Data Source=DESKTOP-153RETS;Initial Catalog=quiz_application;Integrated Security=True");
            DataSet dset2 = new DataSet();
            dadpter2.Fill(dset2);
            comboBox1.DataSource = dset2.Tables[0];
            comboBox1.DisplayMember = "exam_name";
            comboBox1.ValueMember = "ex_id";

        }
    }
}

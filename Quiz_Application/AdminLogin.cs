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
    public partial class AdminLogin : Form
    {
        public static string fk_ad;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string userdb, passworddb;

            returnclass rc = new returnclass();

            userdb = rc.scalarReturn("select count(ad_id) from admin where ad_user='" + user + "'");

            if(userdb.Equals("0"))
            {
                MessageBox.Show("Invalid User Name");
            }
            else
            {
                passworddb = rc.scalarReturn("select ad_passward from admin where ad_user='" + user + "'");
                if(passworddb.Equals(password))
                {
                    fk_ad = rc.scalarReturn("select ad_id from admin where ad_user='" + user + "'");

                    Form2 f = new Form2();
                    f.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Password");
                }
            }
        }
    }
}

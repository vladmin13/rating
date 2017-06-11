using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Рейтинг
{
    public partial class LoginForm : Form
    {
        private MainForm mainForm;

        public LoginForm()
        {
            InitializeComponent();
        }

        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        private void LoginForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e) {

            try
            {
                if (textBox1.TextLength > 4 && textBox2.TextLength > 5)
                {
                    if (await Server.Login(textBox1.Text, textBox2.Text) != null)
                        if (checkBox1.Checked)
                        {
                            Properties.Settings.Default.login = textBox1.Text;
                            Properties.Settings.Default.pass = textBox2.Text;
                            Properties.Settings.Default.loginSave = true;
                            Properties.Settings.Default.Save();
                            this.Close();
                        }
                        else
                        {
                            this.Close();
                        }
                }
                else
                {
                    MessageBox.Show("Введите корректные данные");
                }
            }
            catch {
                Application.Exit();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

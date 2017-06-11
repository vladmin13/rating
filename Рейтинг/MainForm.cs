using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Рейтинг.ProgClass;

namespace Рейтинг
{
    public partial class MainForm : Form
    {
        BindingList<Student> tmpclass = new BindingList<Student>();
        Group g;
        Lesson l;
        Predmet p;
        private BoolAll statBool = new BoolAll(false);
        Control[] T1;
        Control[] T2;



    public MainForm()
        {
            InitializeComponent();
            
            T1 = new Control[] { buttonViewAll, listBoxGroup, listBoxPredmet };
            T2 = new Control[] { button1, button2, button3,textBoxAddFormContr,buttonAddFormContr,dgv,dateTimePickerAddFormContr};
            creatDGV();

           // ToWord.StartWordOtchot();

        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            
                Properties.Settings.Default.loginOk = false;
            try
            {
                await Login();
                toolStripStatusLabel1.Text = Server.myInfo.getPersonString();
                await viewAll();
                //присваивание обработчику события метод
                Server.listISendToServer.UserEvent += viewMessages;
           
            }
            catch (System.Net.WebException)
            {

                MessageBox.Show("Невозможно подключится к интернет ресурсам! Проверте подключение к интернету и перезапустите программу.", "Ошибка подключения к интернету.....", MessageBoxButtons.OK,MessageBoxIcon.Error);
                Application.Exit();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка!(" + ex.GetType() + ") перезапустите программу. В случае повторения обратитесь к системному администратору");
                Application.Exit();

            }
            



          
           
           
        }



        public async Task Login()
        {

            if (!Properties.Settings.Default.loginOk)
            {
                if (Properties.Settings.Default.loginSave)
                {
                   await Server.Login(Properties.Settings.Default.login, Properties.Settings.Default.pass);
                   await Login();
                }
                else
                {
                    LoginForm lf = new LoginForm(this);
                    lf.ShowDialog();
                }

            }


        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.loginOk = false;
            Properties.Settings.Default.Save();
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.loginSave = false;
            Properties.Settings.Default.loginOk = false;
            Properties.Settings.Default.Save();
            Application.Exit();
        }




        private async void listBoxGroup_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            statBool.setGroup();
            Server.mylistLesson = new BindingList<Lesson>(Server.mylistLesson.Where(k => k.Group_id == ((Group)listBoxGroup.SelectedItem).Id).ToList());
            Server.mylistGroup = new BindingList<Group>(Server.mylistGroup.Where(k => k.Id == ((Group)listBoxGroup.SelectedItem).Id).ToList());
            Server.ItemPredmetSelect cp = (s1, s2) =>
            {
                BindingList<Predmet> ret = new BindingList<Predmet>();
                foreach (Predmet itemPredmet in s1)
                {
                    foreach (Lesson itemLesson in s2)
                    {
                        if (itemPredmet.Id == itemLesson.Predmet_id) ret.Add(itemPredmet);
                    }
                }
                return ret;
            };
            Server.mylistPredmet = cp(Server.mylistPredmet, Server.mylistLesson);
            SouresUP();
            if (statBool.gerStatusBool())
            {
                //начать работу с группой
            
               await goEdit();
               await viewAll();
                //отключение панельки слево
                StartBar();
                StopBar(false);
                
            }
        }

        private async void buttonViewAll_Click(object sender, EventArgs e)
        {
           await  viewAll();

        }

        public async Task viewAll()
        { 
            StartBar();
            await Server.GetInfo();
            SouresUP();
            statBool.clearAllBool();
            StopBar(true);
        }

        public void SouresUP()
        {
            listBoxGroup.DataSource = Server.mylistGroup;
            listBoxPredmet.DataSource = Server.mylistPredmet;

        }

        private async void listBoxPredmet_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            statBool.setPredmet();
            Server.mylistLesson = new BindingList<Lesson>(Server.mylistLesson.Where(k => k.Predmet_id == ((Predmet)listBoxPredmet.SelectedItem).Id).ToList());
            Server.mylistPredmet = new BindingList<Predmet>(Server.mylistPredmet.Where(k => k.Id == ((Predmet)listBoxPredmet.SelectedItem).Id).ToList());
            Server.ItemGroupSelect ig = (s1, s2) =>
            {
                BindingList<Group> ret = new BindingList<Group>();
                foreach (Group itemGroup in s1)
                {
                    foreach (Lesson itemLesson in s2)
                    {
                        if (itemGroup.Id == itemLesson.Group_id) ret.Add(itemGroup);
                    }
                }
                return ret;
            };
            Server.mylistGroup = ig(Server.mylistGroup, Server.mylistLesson);
            SouresUP();
            if (statBool.gerStatusBool())
            {
                //начало работы с группой
                
                await goEdit();
                await viewAll();
                StartBar();
                StopBar(false);
            }




        }

        public async Task goEdit()
        {
            StartBar();

            g = (Group)listBoxGroup.SelectedItem;
            p = (Predmet)listBoxPredmet.SelectedItem;
            l = Server.mylistLesson[0];
            labelPredmet.Text = p.Name;
            labelGroup.Text = g.ToString();
          
            tmpclass= await Server.getClass( g.Id);        

            await goDGV(l);



        }



        private async void button1_Click(object sender, EventArgs e)
        {
            StartBar();
             await Server.sendToServer();
            dgv.Dispose();
            creatDGV();
            await goDGV(l);
            StopBar(false);
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            StartBar();
            Server.listISendToServer.Clear();
            dgv.Dispose();
            creatDGV();
           await goDGV(l);
            StopBar(false);

        }

        private async void button3_Click(object sender, EventArgs e)
        {
            StartBar();
            await Server.sendToServer();
            dgv.Dispose();
            creatDGV();
            
            labelGroup.Text = "";
            labelPredmet.Text = "";

            await viewAll();

            StopBar(true);
        }

        public async Task goDGV(Lesson l)
        {
           
           

            //прогрузка занятий  
            await l.GetZanyatie();

            for (int i = 0; i < l.Zanatie.Count; i++)
            {
                dgv.Columns.Add(i.ToString(), l.Zanatie[i].ToCol());
                dgv.Columns[i].Width = 40;
            }

            dgv.RowCount = tmpclass.Count;
            for (int i = 0; i < tmpclass.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = tmpclass[i].getPersonString();
            }

            dgv.Columns.Add("srball", "Средний балл");
            dgv.RowHeadersWidth = 145;
            dgv.CellEndEdit += Dgv_CellEndEdit;


            //dgv.RowStateChanged += Dgv_RowStateChanged; 



          


            //загрузка оценок
            foreach (Zanatie item in l.Zanatie)
            {
                foreach (var itemDost in item.Dost)
                {
                    dgv.Rows[tmpclass.IndexOf(tmpclass.Where(x => x.Id == itemDost.Student_id).ToList()[0])].Cells[l.Zanatie.IndexOf(item)].Value = itemDost.Ocenka.ToString();
                }

            }
            sr_ball(dgv);
            StopBar(false);

        }

        private void Dgv_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && e.ColumnIndex != dgv.ColumnCount - 1)
            {
                if ((l.Zanatie[e.ColumnIndex].Dost.Where(x => x.Student_id == tmpclass[e.RowIndex].Id).ToList()).Count == 0)
                
                    l.Zanatie[e.ColumnIndex].Dost.Add(new Dostigenie(tmpclass[e.RowIndex].Id, l.Zanatie[e.ColumnIndex].Id, (String)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value));
                
                else
                    l.Zanatie[e.ColumnIndex].Dost.Where(x => x.Student_id == tmpclass[e.RowIndex].Id).ToList()[0].setNew((String)dgv.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                Server.listISendToServer.Add(  l.Zanatie[e.ColumnIndex].Dost.Where(x => x.Student_id == tmpclass[e.RowIndex].Id).ToList()[0]);
            }
            sr_ball((DataGridView)sender);
        }


        public void sr_ball(DataGridView data)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Cells[dgv.Columns.Count - 1].Style.BackColor = Color.Gray;
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int kol = 0;
                double srball = 0;
                for (int k = 0; k < data.ColumnCount - 1; k++)
                {
                    int temp;
                    if (data.Rows[i].Cells[k].Value != null)
                    {
                        if (Int32.TryParse(data.Rows[i].Cells[k].Value.ToString(), out temp))
                        {
                            kol++;
                            srball += temp;
                        }
                    }
                }
                if (kol > 0) {

                    data.Rows[i].Cells[data.ColumnCount - 1].Value = (srball / kol);
                    if(srball / kol<4) data.Rows[i].Cells[data.ColumnCount - 1].Style.BackColor = Color.Red;

                };


            }

        }

        private async void buttonAddFormContr_Click(object sender, EventArgs e)
        {
            StartBar();
            if ((MessageBox.Show("Внимание все внесённые изменения будут сохранены", "Предупреждение", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) == DialogResult.OK))
                if (textBoxAddFormContr.TextLength != 0)
                {

                    l.Zanatie.Add(new Zanatie(textBoxAddFormContr.Text, dateTimePickerAddFormContr.Value, l.Id));
                    DataGridViewColumn tcol = dgv.Columns[dgv.Columns.Count - 1];
                    dgv.Columns.Remove("srball");
                    dgv.Columns.Add((dgv.Columns.Count).ToString(), l.Zanatie[dgv.Columns.Count].ToCol());
                    dgv.Columns[dgv.Columns.Count - 1].Width = 40;
                    dgv.Columns.Add("srball", "Ср.балл");
                    
                    sr_ball(dgv);
                    textBoxAddFormContr.Text = "";

                    ////////добавить интерфейс
                    Server.listISendToServer.Add((ISendToServer)l.Zanatie.Last());
                    await Server.sendToServer();
                   
                }
                else MessageBox.Show("Введите коректные данные");
            StopBar(false);
        }
        private void creatDGV() {
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Enabled = false;
            this.dgv.Location = new System.Drawing.Point(221, 56);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(970, 528);
            this.dgv.TabIndex = 3;
            this.Controls.Add(this.dgv);
            T2[5] = dgv;

        }


        private void viewMessages(string text) {

            notifyIcon.ShowBalloonTip(5000, "Рейтин", text, ToolTipIcon.None);

        }

        private void сформироватьОтчётToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToWord.StartWordOtchot(g,p,l,tmpclass);
        }

        private void StartBar()
        {
            foreach (var item in T1)
            {
                item.Enabled = false;
            }
            foreach (var item in T2)
            {
                item.Enabled = false;
            }
            отчётыToolStripMenuItem.Enabled = false;
            toolStripProgressBar1.Visible = true;
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            toolStripProgressBar1.MarqueeAnimationSpeed = 30;
            toolStripStatusLabel2.Text = "Загрузка данных";

        }
        private void StopBar(bool t1)
        {
            if (t1)
            {
                foreach (var item in T1)
                {
                    item.Enabled = true;
                }
            }
            else
            {
                отчётыToolStripMenuItem.Enabled = true;
                foreach (var item in T2)
                {
                    item.Enabled = true;
                }
            }
            toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
            toolStripProgressBar1.MarqueeAnimationSpeed = 0;
          //  toolStripProgressBar1.Visible = false;
            toolStripStatusLabel2.Text = "Готово";

        }

    }
    

    
}

   


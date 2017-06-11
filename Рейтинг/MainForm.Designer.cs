namespace Рейтинг
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.студентыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сформироватьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.аккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.listBoxGroup = new System.Windows.Forms.ListBox();
            this.listBoxPredmet = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.buttonViewAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelGroup = new System.Windows.Forms.Label();
            this.labelPredmet = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAddFormContr = new System.Windows.Forms.TextBox();
            this.dateTimePickerAddFormContr = new System.Windows.Forms.DateTimePicker();
            this.buttonAddFormContr = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.студентыToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.аккаунтToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1288, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // студентыToolStripMenuItem
            // 
            this.студентыToolStripMenuItem.Name = "студентыToolStripMenuItem";
            this.студентыToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.студентыToolStripMenuItem.Text = "Студенты";
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сформироватьОтчётToolStripMenuItem});
            this.отчётыToolStripMenuItem.Enabled = false;
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // сформироватьОтчётToolStripMenuItem
            // 
            this.сформироватьОтчётToolStripMenuItem.Name = "сформироватьОтчётToolStripMenuItem";
            this.сформироватьОтчётToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.сформироватьОтчётToolStripMenuItem.Text = "Сформировать отчёт";
            this.сформироватьОтчётToolStripMenuItem.Click += new System.EventHandler(this.сформироватьОтчётToolStripMenuItem_Click);
            // 
            // аккаунтToolStripMenuItem
            // 
            this.аккаунтToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выйтиToolStripMenuItem});
            this.аккаунтToolStripMenuItem.Name = "аккаунтToolStripMenuItem";
            this.аккаунтToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.аккаунтToolStripMenuItem.Text = "Аккаунт";
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выйтиToolStripMenuItem.Text = "Выйти";
            this.выйтиToolStripMenuItem.Click += new System.EventHandler(this.выйтиToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Рейтин";
            this.notifyIcon.Visible = true;
            // 
            // listBoxGroup
            // 
            this.listBoxGroup.Enabled = false;
            this.listBoxGroup.FormattingEnabled = true;
            this.listBoxGroup.Location = new System.Drawing.Point(12, 229);
            this.listBoxGroup.Name = "listBoxGroup";
            this.listBoxGroup.Size = new System.Drawing.Size(183, 225);
            this.listBoxGroup.TabIndex = 1;
            this.listBoxGroup.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxGroup_MouseDoubleClick);
            // 
            // listBoxPredmet
            // 
            this.listBoxPredmet.Enabled = false;
            this.listBoxPredmet.FormattingEnabled = true;
            this.listBoxPredmet.Location = new System.Drawing.Point(12, 106);
            this.listBoxPredmet.Name = "listBoxPredmet";
            this.listBoxPredmet.Size = new System.Drawing.Size(183, 121);
            this.listBoxPredmet.TabIndex = 2;
            this.listBoxPredmet.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBoxPredmet_MouseDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 587);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1288, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Step = 5;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(98, 17);
            this.toolStripStatusLabel2.Text = "Загрузка данных";
            // 
            // buttonViewAll
            // 
            this.buttonViewAll.Enabled = false;
            this.buttonViewAll.Location = new System.Drawing.Point(13, 56);
            this.buttonViewAll.Name = "buttonViewAll";
            this.buttonViewAll.Size = new System.Drawing.Size(182, 23);
            this.buttonViewAll.TabIndex = 5;
            this.buttonViewAll.Text = "Отобразить все данные";
            this.buttonViewAll.UseVisualStyleBackColor = true;
            this.buttonViewAll.Click += new System.EventHandler(this.buttonViewAll_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(667, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Сохранить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(766, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Отменить";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelGroup
            // 
            this.labelGroup.AutoSize = true;
            this.labelGroup.Location = new System.Drawing.Point(218, 32);
            this.labelGroup.Name = "labelGroup";
            this.labelGroup.Size = new System.Drawing.Size(0, 13);
            this.labelGroup.TabIndex = 8;
            // 
            // labelPredmet
            // 
            this.labelPredmet.AutoSize = true;
            this.labelPredmet.Location = new System.Drawing.Point(320, 32);
            this.labelPredmet.Name = "labelPredmet";
            this.labelPredmet.Size = new System.Drawing.Size(0, 13);
            this.labelPredmet.TabIndex = 9;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(866, 26);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(247, 24);
            this.button3.TabIndex = 10;
            this.button3.Text = "Завершить редатирование и сохранить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 485);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Добавить форму контроля";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Название";
            // 
            // textBoxAddFormContr
            // 
            this.textBoxAddFormContr.Enabled = false;
            this.textBoxAddFormContr.Location = new System.Drawing.Point(75, 509);
            this.textBoxAddFormContr.Name = "textBoxAddFormContr";
            this.textBoxAddFormContr.Size = new System.Drawing.Size(140, 20);
            this.textBoxAddFormContr.TabIndex = 13;
            // 
            // dateTimePickerAddFormContr
            // 
            this.dateTimePickerAddFormContr.Enabled = false;
            this.dateTimePickerAddFormContr.Location = new System.Drawing.Point(15, 535);
            this.dateTimePickerAddFormContr.Name = "dateTimePickerAddFormContr";
            this.dateTimePickerAddFormContr.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerAddFormContr.TabIndex = 14;
            // 
            // buttonAddFormContr
            // 
            this.buttonAddFormContr.Enabled = false;
            this.buttonAddFormContr.Location = new System.Drawing.Point(31, 561);
            this.buttonAddFormContr.Name = "buttonAddFormContr";
            this.buttonAddFormContr.Size = new System.Drawing.Size(141, 23);
            this.buttonAddFormContr.TabIndex = 15;
            this.buttonAddFormContr.Text = "Добавить";
            this.buttonAddFormContr.UseVisualStyleBackColor = true;
            this.buttonAddFormContr.Click += new System.EventHandler(this.buttonAddFormContr_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Выберите группу и предмет";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1288, 609);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonAddFormContr);
            this.Controls.Add(this.dateTimePickerAddFormContr);
            this.Controls.Add(this.textBoxAddFormContr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.labelPredmet);
            this.Controls.Add(this.labelGroup);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonViewAll);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.listBoxPredmet);
            this.Controls.Add(this.listBoxGroup);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Рейтинг";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ListBox listBoxGroup;
        private System.Windows.Forms.ListBox listBoxPredmet;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ToolStripMenuItem студентыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem аккаунтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button buttonViewAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelGroup;
        private System.Windows.Forms.Label labelPredmet;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAddFormContr;
        private System.Windows.Forms.DateTimePicker dateTimePickerAddFormContr;
        private System.Windows.Forms.Button buttonAddFormContr;
        protected System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem сформироватьОтчётToolStripMenuItem;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}


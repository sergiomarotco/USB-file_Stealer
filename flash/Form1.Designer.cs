namespace USBfileStealer
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.показатьОкноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.принудительноЗапустьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьУкраденныеФайлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 16;
            this.listBox2.Location = new System.Drawing.Point(16, 15);
            this.listBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(491, 468);
            this.listBox2.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(516, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 165);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open\r\nleaked\r\nfiles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 494);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ожидаю новое USB-устройство";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(525, 183);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(45, 17);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "About";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "USB-file stealer";
            this.notifyIcon1.BalloonTipTitle = "USB-file stealer";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Tag = "USB-file stealer";
            this.notifyIcon1.Text = "USB-file stealer";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.показатьОкноToolStripMenuItem,
            this.принудительноЗапустьToolStripMenuItem,
            this.открытьУкраденныеФайлыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(281, 136);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // показатьОкноToolStripMenuItem
            // 
            this.показатьОкноToolStripMenuItem.Name = "показатьОкноToolStripMenuItem";
            this.показатьОкноToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.показатьОкноToolStripMenuItem.Text = "Показать окно";
            this.показатьОкноToolStripMenuItem.Click += new System.EventHandler(this.показатьОкноToolStripMenuItem_Click);
            // 
            // принудительноЗапустьToolStripMenuItem
            // 
            this.принудительноЗапустьToolStripMenuItem.Name = "принудительноЗапустьToolStripMenuItem";
            this.принудительноЗапустьToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.принудительноЗапустьToolStripMenuItem.Text = "Принудительный поиск";
            this.принудительноЗапустьToolStripMenuItem.Click += new System.EventHandler(this.принудительноЗапустьToolStripMenuItem_Click);
            // 
            // открытьУкраденныеФайлыToolStripMenuItem
            // 
            this.открытьУкраденныеФайлыToolStripMenuItem.Name = "открытьУкраденныеФайлыToolStripMenuItem";
            this.открытьУкраденныеФайлыToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.открытьУкраденныеФайлыToolStripMenuItem.Text = "Открыть украденные файлы";
            this.открытьУкраденныеФайлыToolStripMenuItem.Click += new System.EventHandler(this.открытьУкраденныеФайлыToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(280, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(591, 15);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(647, 468);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1255, 517);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USB-file stealer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem принудительноЗапустьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem показатьОкноToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьУкраденныеФайлыToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}


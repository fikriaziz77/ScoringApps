namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.name12 = new System.Windows.Forms.Label();
            this.name22 = new System.Windows.Forms.Label();
            this.name11 = new System.Windows.Forms.Label();
            this.name21 = new System.Windows.Forms.Label();
            this.instansi1 = new System.Windows.Forms.Label();
            this.instansi2 = new System.Windows.Forms.Label();
            this.score1 = new System.Windows.Forms.Label();
            this.score2 = new System.Windows.Forms.Label();
            this.set1 = new System.Windows.Forms.Label();
            this.set2 = new System.Windows.Forms.Label();
            this.round = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.event_name = new System.Windows.Forms.Label();
            this.event_loct = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // name12
            // 
            this.name12.BackColor = System.Drawing.Color.Transparent;
            this.name12.Font = new System.Drawing.Font("Arial Narrow", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name12.ForeColor = System.Drawing.Color.Lime;
            this.name12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.name12.Location = new System.Drawing.Point(3, 5);
            this.name12.Name = "name12";
            this.name12.Size = new System.Drawing.Size(826, 115);
            this.name12.TabIndex = 1;
            this.name12.Text = "Pemain 2";
            this.name12.Click += new System.EventHandler(this.name12_Click);
            // 
            // name22
            // 
            this.name22.BackColor = System.Drawing.Color.Transparent;
            this.name22.Font = new System.Drawing.Font("Arial Narrow", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name22.ForeColor = System.Drawing.Color.Gold;
            this.name22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.name22.Location = new System.Drawing.Point(3, 625);
            this.name22.Name = "name22";
            this.name22.Size = new System.Drawing.Size(826, 115);
            this.name22.TabIndex = 3;
            this.name22.Text = "Pemain 4";
            // 
            // name11
            // 
            this.name11.BackColor = System.Drawing.Color.Transparent;
            this.name11.Font = new System.Drawing.Font("Arial Narrow", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name11.ForeColor = System.Drawing.Color.Lime;
            this.name11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.name11.Location = new System.Drawing.Point(3, 124);
            this.name11.Name = "name11";
            this.name11.Size = new System.Drawing.Size(826, 115);
            this.name11.TabIndex = 4;
            this.name11.Text = "Pemain 1";
            this.name11.Click += new System.EventHandler(this.name11_Click);
            // 
            // name21
            // 
            this.name21.BackColor = System.Drawing.Color.Transparent;
            this.name21.Font = new System.Drawing.Font("Arial Narrow", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name21.ForeColor = System.Drawing.Color.Gold;
            this.name21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.name21.Location = new System.Drawing.Point(3, 504);
            this.name21.Name = "name21";
            this.name21.Size = new System.Drawing.Size(826, 115);
            this.name21.TabIndex = 5;
            this.name21.Text = "Pemain 3";
            // 
            // instansi1
            // 
            this.instansi1.BackColor = System.Drawing.Color.Transparent;
            this.instansi1.Font = new System.Drawing.Font("Arial Narrow", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instansi1.ForeColor = System.Drawing.Color.Lime;
            this.instansi1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.instansi1.Location = new System.Drawing.Point(14, 243);
            this.instansi1.Name = "instansi1";
            this.instansi1.Size = new System.Drawing.Size(936, 84);
            this.instansi1.TabIndex = 6;
            this.instansi1.Text = "PB. Banda Baru";
            this.instansi1.Click += new System.EventHandler(this.instansi1_Click);
            // 
            // instansi2
            // 
            this.instansi2.BackColor = System.Drawing.Color.Transparent;
            this.instansi2.Font = new System.Drawing.Font("Arial Narrow", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instansi2.ForeColor = System.Drawing.Color.Gold;
            this.instansi2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.instansi2.Location = new System.Drawing.Point(13, 425);
            this.instansi2.Name = "instansi2";
            this.instansi2.Size = new System.Drawing.Size(936, 73);
            this.instansi2.TabIndex = 7;
            this.instansi2.Text = "PB. Banda Baru";
            // 
            // score1
            // 
            this.score1.BackColor = System.Drawing.Color.Lime;
            this.score1.Font = new System.Drawing.Font("Arial Narrow", 219.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score1.ForeColor = System.Drawing.Color.Black;
            this.score1.Location = new System.Drawing.Point(956, -1);
            this.score1.Name = "score1";
            this.score1.Size = new System.Drawing.Size(415, 375);
            this.score1.TabIndex = 8;
            this.score1.Text = "30";
            this.score1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // score2
            // 
            this.score2.BackColor = System.Drawing.Color.Transparent;
            this.score2.Font = new System.Drawing.Font("Arial Narrow", 219.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score2.ForeColor = System.Drawing.Color.Gold;
            this.score2.Location = new System.Drawing.Point(956, 374);
            this.score2.Name = "score2";
            this.score2.Size = new System.Drawing.Size(415, 375);
            this.score2.TabIndex = 12;
            this.score2.Text = "18";
            this.score2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // set1
            // 
            this.set1.BackColor = System.Drawing.Color.Transparent;
            this.set1.Font = new System.Drawing.Font("Arial Narrow", 100.25F);
            this.set1.ForeColor = System.Drawing.Color.White;
            this.set1.Location = new System.Drawing.Point(832, 5);
            this.set1.Name = "set1";
            this.set1.Size = new System.Drawing.Size(118, 234);
            this.set1.TabIndex = 13;
            this.set1.Text = "1";
            this.set1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // set2
            // 
            this.set2.BackColor = System.Drawing.Color.Transparent;
            this.set2.Font = new System.Drawing.Font("Arial Narrow", 100.25F);
            this.set2.ForeColor = System.Drawing.Color.White;
            this.set2.Location = new System.Drawing.Point(832, 504);
            this.set2.Name = "set2";
            this.set2.Size = new System.Drawing.Size(118, 236);
            this.set2.TabIndex = 14;
            this.set2.Text = "2";
            this.set2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // round
            // 
            this.round.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.round.BackColor = System.Drawing.Color.Transparent;
            this.round.Font = new System.Drawing.Font("Arial Narrow", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.round.ForeColor = System.Drawing.Color.White;
            this.round.Location = new System.Drawing.Point(445, 333);
            this.round.Name = "round";
            this.round.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.round.Size = new System.Drawing.Size(504, 88);
            this.round.TabIndex = 15;
            this.round.Text = "FINAL";
            this.round.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // event_name
            // 
            this.event_name.BackColor = System.Drawing.Color.Transparent;
            this.event_name.Font = new System.Drawing.Font("Arial Narrow", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_name.ForeColor = System.Drawing.Color.White;
            this.event_name.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.event_name.Location = new System.Drawing.Point(11, 390);
            this.event_name.Name = "event_name";
            this.event_name.Size = new System.Drawing.Size(1346, 173);
            this.event_name.TabIndex = 16;
            this.event_name.Text = "SIRNAS PBSI BATAM 2023";
            this.event_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // event_loct
            // 
            this.event_loct.BackColor = System.Drawing.Color.Transparent;
            this.event_loct.Font = new System.Drawing.Font("Arial Narrow", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.event_loct.ForeColor = System.Drawing.Color.White;
            this.event_loct.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.event_loct.Location = new System.Drawing.Point(11, 573);
            this.event_loct.Name = "event_loct";
            this.event_loct.Size = new System.Drawing.Size(1346, 84);
            this.event_loct.TabIndex = 17;
            this.event_loct.Text = "EVENT LOKASI";
            this.event_loct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(293, 69);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(783, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.score1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.event_loct);
            this.Controls.Add(this.event_name);
            this.Controls.Add(this.round);
            this.Controls.Add(this.set2);
            this.Controls.Add(this.set1);
            this.Controls.Add(this.score2);
            this.Controls.Add(this.instansi2);
            this.Controls.Add(this.instansi1);
            this.Controls.Add(this.name21);
            this.Controls.Add(this.name11);
            this.Controls.Add(this.name22);
            this.Controls.Add(this.name12);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(1370, 0);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Score Panel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label name12;
        private System.Windows.Forms.Label name22;
        private System.Windows.Forms.Label name11;
        private System.Windows.Forms.Label name21;
        private System.Windows.Forms.Label instansi1;
        private System.Windows.Forms.Label instansi2;
        private System.Windows.Forms.Label score1;
        private System.Windows.Forms.Label score2;
        private System.Windows.Forms.Label set1;
        private System.Windows.Forms.Label set2;
        private System.Windows.Forms.Label round;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label event_name;
        private System.Windows.Forms.Label event_loct;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


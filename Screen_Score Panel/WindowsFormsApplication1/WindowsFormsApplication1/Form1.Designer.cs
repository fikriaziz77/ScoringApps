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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.plus1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.min1 = new System.Windows.Forms.Button();
            this.min2 = new System.Windows.Forms.Button();
            this.plus2 = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // name12
            // 
            this.name12.Font = new System.Drawing.Font("Arial Narrow", 65.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name12.Location = new System.Drawing.Point(3, 0);
            this.name12.Name = "name12";
            this.name12.Size = new System.Drawing.Size(791, 121);
            this.name12.TabIndex = 1;
            this.name12.Text = "Pemain 1";
            this.name12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.name12.Click += new System.EventHandler(this.name12_Click);
            // 
            // name22
            // 
            this.name22.Font = new System.Drawing.Font("Arial Narrow", 65.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name22.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name22.Location = new System.Drawing.Point(3, 591);
            this.name22.Name = "name22";
            this.name22.Size = new System.Drawing.Size(791, 121);
            this.name22.TabIndex = 3;
            this.name22.Text = "Pemain 4";
            this.name22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name11
            // 
            this.name11.Font = new System.Drawing.Font("Arial Narrow", 65.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name11.Location = new System.Drawing.Point(3, 130);
            this.name11.Name = "name11";
            this.name11.Size = new System.Drawing.Size(791, 121);
            this.name11.TabIndex = 4;
            this.name11.Text = "Pemain 2";
            this.name11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // name21
            // 
            this.name21.Font = new System.Drawing.Font("Arial Narrow", 65.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name21.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name21.Location = new System.Drawing.Point(3, 474);
            this.name21.Name = "name21";
            this.name21.Size = new System.Drawing.Size(791, 121);
            this.name21.TabIndex = 5;
            this.name21.Text = "Pemain 3";
            this.name21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // instansi1
            // 
            this.instansi1.Font = new System.Drawing.Font("Arial Narrow", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instansi1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instansi1.Location = new System.Drawing.Point(13, 253);
            this.instansi1.Name = "instansi1";
            this.instansi1.Size = new System.Drawing.Size(781, 63);
            this.instansi1.TabIndex = 6;
            this.instansi1.Text = "PB. ";
            this.instansi1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // instansi2
            // 
            this.instansi2.Font = new System.Drawing.Font("Arial Narrow", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instansi2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.instansi2.Location = new System.Drawing.Point(13, 411);
            this.instansi2.Name = "instansi2";
            this.instansi2.Size = new System.Drawing.Size(781, 63);
            this.instansi2.TabIndex = 7;
            this.instansi2.Text = "PB. ";
            this.instansi2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // score1
            // 
            this.score1.BackColor = System.Drawing.Color.Transparent;
            this.score1.Font = new System.Drawing.Font("Arial Narrow", 159.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score1.ForeColor = System.Drawing.Color.Lime;
            this.score1.Location = new System.Drawing.Point(986, 0);
            this.score1.Name = "score1";
            this.score1.Size = new System.Drawing.Size(316, 360);
            this.score1.TabIndex = 8;
            this.score1.Text = "00";
            this.score1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // score2
            // 
            this.score2.BackColor = System.Drawing.Color.Transparent;
            this.score2.Font = new System.Drawing.Font("Arial Narrow", 159.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score2.ForeColor = System.Drawing.Color.Gold;
            this.score2.Location = new System.Drawing.Point(986, 363);
            this.score2.Name = "score2";
            this.score2.Size = new System.Drawing.Size(316, 360);
            this.score2.TabIndex = 12;
            this.score2.Text = "00";
            this.score2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // set1
            // 
            this.set1.Font = new System.Drawing.Font("Arial Narrow", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set1.ForeColor = System.Drawing.Color.White;
            this.set1.Location = new System.Drawing.Point(1233, 276);
            this.set1.Name = "set1";
            this.set1.Size = new System.Drawing.Size(69, 84);
            this.set1.TabIndex = 13;
            this.set1.Text = "1";
            this.set1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // set2
            // 
            this.set2.Font = new System.Drawing.Font("Arial Narrow", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.set2.ForeColor = System.Drawing.Color.White;
            this.set2.Location = new System.Drawing.Point(1233, 363);
            this.set2.Name = "set2";
            this.set2.Size = new System.Drawing.Size(67, 88);
            this.set2.TabIndex = 14;
            this.set2.Text = "1";
            this.set2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // plus1
            // 
            this.plus1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.plus1.Font = new System.Drawing.Font("Arial Narrow", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plus1.Location = new System.Drawing.Point(800, 27);
            this.plus1.Name = "plus1";
            this.plus1.Size = new System.Drawing.Size(180, 150);
            this.plus1.TabIndex = 16;
            this.plus1.Text = "+";
            this.plus1.UseVisualStyleBackColor = true;
            this.plus1.Click += new System.EventHandler(this.plus1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(484, 219);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(0, 0);
            this.button2.TabIndex = 18;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // min1
            // 
            this.min1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.min1.Font = new System.Drawing.Font("Arial Narrow", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min1.Location = new System.Drawing.Point(800, 183);
            this.min1.Name = "min1";
            this.min1.Size = new System.Drawing.Size(180, 150);
            this.min1.TabIndex = 19;
            this.min1.Text = "-";
            this.min1.UseVisualStyleBackColor = true;
            this.min1.Click += new System.EventHandler(this.min1_Click);
            // 
            // min2
            // 
            this.min2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.min2.Font = new System.Drawing.Font("Arial Narrow", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.min2.Location = new System.Drawing.Point(800, 544);
            this.min2.Name = "min2";
            this.min2.Size = new System.Drawing.Size(180, 150);
            this.min2.TabIndex = 21;
            this.min2.Text = "-";
            this.min2.UseVisualStyleBackColor = true;
            this.min2.Click += new System.EventHandler(this.min2_Click);
            // 
            // plus2
            // 
            this.plus2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.plus2.Font = new System.Drawing.Font("Arial Narrow", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plus2.Location = new System.Drawing.Point(800, 388);
            this.plus2.Name = "plus2";
            this.plus2.Size = new System.Drawing.Size(180, 150);
            this.plus2.TabIndex = 20;
            this.plus2.Text = "+";
            this.plus2.UseVisualStyleBackColor = true;
            this.plus2.Click += new System.EventHandler(this.plus2_Click);
            // 
            // next
            // 
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.next.Font = new System.Drawing.Font("Arial Narrow", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next.Location = new System.Drawing.Point(531, 319);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(263, 89);
            this.next.TabIndex = 22;
            this.next.Text = "NEXT";
            this.next.UseVisualStyleBackColor = true;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 35.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(10, 484);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1276, 63);
            this.label1.TabIndex = 24;
            this.label1.Text = "PENGPROV PBSI KEPRI";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Panel_ScoreSet.Properties.Resources.Logo_PBSI;
            this.pictureBox1.Location = new System.Drawing.Point(473, 121);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(350, 350);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.VisibleChanged += new System.EventHandler(this.pictureBox1_VisibleChanged);
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1300, 721);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.next);
            this.Controls.Add(this.min2);
            this.Controls.Add(this.plus2);
            this.Controls.Add(this.min1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.plus1);
            this.Controls.Add(this.set2);
            this.Controls.Add(this.set1);
            this.Controls.Add(this.score2);
            this.Controls.Add(this.score1);
            this.Controls.Add(this.instansi2);
            this.Controls.Add(this.instansi1);
            this.Controls.Add(this.name21);
            this.Controls.Add(this.name11);
            this.Controls.Add(this.name22);
            this.Controls.Add(this.name12);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Score Panel";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.VisibleChanged += new System.EventHandler(this.show);
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
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button plus1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button min1;
        private System.Windows.Forms.Button min2;
        private System.Windows.Forms.Button plus2;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}


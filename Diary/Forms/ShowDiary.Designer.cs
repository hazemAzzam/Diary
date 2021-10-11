
namespace Diary.Forms
{
    partial class ShowDiary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowDiary));
            this.dateLBL = new System.Windows.Forms.Label();
            this.contentTEXT = new System.Windows.Forms.RichTextBox();
            this.finishTimeLBL = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.startTimeLBL = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.titleLBL = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateLBL
            // 
            this.dateLBL.AutoSize = true;
            this.dateLBL.Location = new System.Drawing.Point(12, 9);
            this.dateLBL.Name = "dateLBL";
            this.dateLBL.Size = new System.Drawing.Size(167, 29);
            this.dateLBL.TabIndex = 15;
            this.dateLBL.Text = "YYYY-MM-DD";
            // 
            // contentTEXT
            // 
            this.contentTEXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTEXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(67)))), ((int)(((byte)(29)))));
            this.contentTEXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contentTEXT.Font = new System.Drawing.Font("Frutiger LT Arabic 55 Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentTEXT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.contentTEXT.Location = new System.Drawing.Point(12, 133);
            this.contentTEXT.Name = "contentTEXT";
            this.contentTEXT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contentTEXT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.contentTEXT.Size = new System.Drawing.Size(671, 442);
            this.contentTEXT.TabIndex = 14;
            this.contentTEXT.Text = "";
            this.contentTEXT.TextChanged += new System.EventHandler(this.contentTEXT_TextChanged);
            // 
            // finishTimeLBL
            // 
            this.finishTimeLBL.AutoSize = true;
            this.finishTimeLBL.Location = new System.Drawing.Point(437, 96);
            this.finishTimeLBL.Name = "finishTimeLBL";
            this.finishTimeLBL.Size = new System.Drawing.Size(131, 29);
            this.finishTimeLBL.TabIndex = 12;
            this.finishTimeLBL.Text = "HH:MM:SS";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(121)))), ((int)(((byte)(65)))));
            this.label5.Location = new System.Drawing.Point(285, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 29);
            this.label5.TabIndex = 11;
            this.label5.Text = "Finish Time:";
            // 
            // startTimeLBL
            // 
            this.startTimeLBL.AutoSize = true;
            this.startTimeLBL.Location = new System.Drawing.Point(148, 96);
            this.startTimeLBL.Name = "startTimeLBL";
            this.startTimeLBL.Size = new System.Drawing.Size(131, 29);
            this.startTimeLBL.TabIndex = 10;
            this.startTimeLBL.Text = "HH:MM:SS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(121)))), ((int)(((byte)(65)))));
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 9;
            this.label2.Text = "Start Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(121)))), ((int)(((byte)(65)))));
            this.label1.Location = new System.Drawing.Point(12, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 29);
            this.label1.TabIndex = 8;
            this.label1.Text = "Title:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.dateLBL);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 51);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(636, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 51);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(67)))), ((int)(((byte)(29)))));
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.Location = new System.Drawing.Point(573, 54);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(111, 34);
            this.deleteButton.TabIndex = 17;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // titleLBL
            // 
            this.titleLBL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.titleLBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleLBL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.titleLBL.Location = new System.Drawing.Point(85, 54);
            this.titleLBL.Name = "titleLBL";
            this.titleLBL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.titleLBL.Size = new System.Drawing.Size(446, 28);
            this.titleLBL.TabIndex = 18;
            this.titleLBL.TextChanged += new System.EventHandler(this.contentTEXT_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(67)))), ((int)(((byte)(29)))));
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.Location = new System.Drawing.Point(573, 94);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(111, 34);
            this.saveButton.TabIndex = 19;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // ShowDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.ClientSize = new System.Drawing.Size(692, 582);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.titleLBL);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contentTEXT);
            this.Controls.Add(this.finishTimeLBL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startTimeLBL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "ShowDiary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShowDiary";
            this.Load += new System.EventHandler(this.ShowDiary_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label dateLBL;
        private System.Windows.Forms.RichTextBox contentTEXT;
        private System.Windows.Forms.Label finishTimeLBL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label startTimeLBL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox titleLBL;
        private System.Windows.Forms.Button saveButton;
    }
}
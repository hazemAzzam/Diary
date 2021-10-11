
namespace Diary.User_Controls
{
    partial class AddNewDiary
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleTXT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.contentTXT = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // titleTXT
            // 
            this.titleTXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(67)))), ((int)(((byte)(29)))));
            this.titleTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.titleTXT.Font = new System.Drawing.Font("Frutiger LT Arabic 55 Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTXT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.titleTXT.Location = new System.Drawing.Point(81, 5);
            this.titleTXT.Multiline = true;
            this.titleTXT.Name = "titleTXT";
            this.titleTXT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.titleTXT.Size = new System.Drawing.Size(283, 33);
            this.titleTXT.TabIndex = 1;
            this.titleTXT.Text = "ضع عنوان";
            this.titleTXT.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.titleTXT.Enter += new System.EventHandler(this.textBox1_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "Title:";
            // 
            // contentTXT
            // 
            this.contentTXT.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTXT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(67)))), ((int)(((byte)(29)))));
            this.contentTXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.contentTXT.Font = new System.Drawing.Font("Frutiger LT Arabic 55 Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contentTXT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.contentTXT.Location = new System.Drawing.Point(0, 42);
            this.contentTXT.Name = "contentTXT";
            this.contentTXT.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.contentTXT.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.contentTXT.Size = new System.Drawing.Size(742, 476);
            this.contentTXT.TabIndex = 4;
            this.contentTXT.Text = "اكتب هنا";
            this.contentTXT.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.contentTXT.Enter += new System.EventHandler(this.richTextBox1_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(0, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(742, 43);
            this.button1.TabIndex = 5;
            this.button1.Text = "Insert";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatAppearance.BorderSize = 0;
            this.checkBox1.Location = new System.Drawing.Point(570, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(117, 32);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "English";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // AddNewDiary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(0)))), ((int)(((byte)(1)))));
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.contentTXT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titleTXT);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "AddNewDiary";
            this.Size = new System.Drawing.Size(742, 562);
            this.Load += new System.EventHandler(this.AddNewDiary_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox titleTXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox contentTXT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

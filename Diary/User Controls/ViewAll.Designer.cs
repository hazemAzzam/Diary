
namespace Diary.User_Controls
{
    partial class ViewAll
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewAll));
            this.panel4 = new System.Windows.Forms.Panel();
            this.ScrollUp = new System.Windows.Forms.Button();
            this.ScrollDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.panel4.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F);
            this.panel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(617, 582);
            this.panel4.TabIndex = 5;
            this.panel4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // ScrollUp
            // 
            this.ScrollUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScrollUp.BackgroundImage")));
            this.ScrollUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ScrollUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.ScrollUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScrollUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScrollUp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(0)))));
            this.ScrollUp.Location = new System.Drawing.Point(0, 0);
            this.ScrollUp.Name = "ScrollUp";
            this.ScrollUp.Size = new System.Drawing.Size(24, 26);
            this.ScrollUp.TabIndex = 0;
            this.ScrollUp.UseVisualStyleBackColor = true;
            this.ScrollUp.Click += new System.EventHandler(this.button1_Click);
            // 
            // ScrollDown
            // 
            this.ScrollDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("ScrollDown.BackgroundImage")));
            this.ScrollDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ScrollDown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ScrollDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScrollDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ScrollDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(246)))), ((int)(((byte)(0)))));
            this.ScrollDown.Location = new System.Drawing.Point(0, 556);
            this.ScrollDown.Name = "ScrollDown";
            this.ScrollDown.Size = new System.Drawing.Size(24, 26);
            this.ScrollDown.TabIndex = 6;
            this.ScrollDown.UseVisualStyleBackColor = true;
            this.ScrollDown.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ScrollDown);
            this.panel1.Controls.Add(this.ScrollUp);
            this.panel1.Location = new System.Drawing.Point(790, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(24, 582);
            this.panel1.TabIndex = 7;
            this.panel1.Visible = false;
            // 
            // ViewAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(203)))), ((int)(((byte)(189)))));
            this.Margin = new System.Windows.Forms.Padding(7);
            this.Name = "ViewAll";
            this.Size = new System.Drawing.Size(693, 582);
            this.Load += new System.EventHandler(this.ViewAll_Load);
            this.Resize += new System.EventHandler(this.ViewAll_Resize);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ScrollUp;
        private System.Windows.Forms.Button ScrollDown;
        private System.Windows.Forms.Panel panel1;
    }
}

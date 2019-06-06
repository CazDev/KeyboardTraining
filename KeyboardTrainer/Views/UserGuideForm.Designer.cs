namespace KeyboardTrainer.Views
{
    partial class UserGuideForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGuideForm));
            this.tab1_Nextbtn = new System.Windows.Forms.Button();
            this.tab1_Title = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.tab1Text = new System.Windows.Forms.RichTextBox();
            this.tab2 = new System.Windows.Forms.TabPage();
            this.tab2_Exitbtn = new System.Windows.Forms.Button();
            this.tab2Text = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.tab1.SuspendLayout();
            this.tab2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1_Nextbtn
            // 
            this.tab1_Nextbtn.Location = new System.Drawing.Point(516, 299);
            this.tab1_Nextbtn.Name = "tab1_Nextbtn";
            this.tab1_Nextbtn.Size = new System.Drawing.Size(75, 23);
            this.tab1_Nextbtn.TabIndex = 0;
            this.tab1_Nextbtn.Text = "Next >>";
            this.tab1_Nextbtn.UseVisualStyleBackColor = true;
            // 
            // tab1_Title
            // 
            this.tab1_Title.AutoSize = true;
            this.tab1_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.tab1_Title.Location = new System.Drawing.Point(7, 17);
            this.tab1_Title.Name = "tab1_Title";
            this.tab1_Title.Size = new System.Drawing.Size(95, 25);
            this.tab1_Title.TabIndex = 1;
            this.tab1_Title.Text = "Welcome";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab1);
            this.tabControl.Controls.Add(this.tab2);
            this.tabControl.Location = new System.Drawing.Point(1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(605, 354);
            this.tabControl.TabIndex = 2;
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.tab1Text);
            this.tab1.Controls.Add(this.tab1_Title);
            this.tab1.Controls.Add(this.tab1_Nextbtn);
            this.tab1.Location = new System.Drawing.Point(4, 22);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(597, 328);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "1";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // tab1Text
            // 
            this.tab1Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tab1Text.Location = new System.Drawing.Point(6, 45);
            this.tab1Text.Name = "tab1Text";
            this.tab1Text.Size = new System.Drawing.Size(585, 248);
            this.tab1Text.TabIndex = 2;
            this.tab1Text.Text = resources.GetString("tab1Text.Text");
            // 
            // tab2
            // 
            this.tab2.Controls.Add(this.tab2Text);
            this.tab2.Controls.Add(this.tab2_Exitbtn);
            this.tab2.Location = new System.Drawing.Point(4, 22);
            this.tab2.Name = "tab2";
            this.tab2.Padding = new System.Windows.Forms.Padding(3);
            this.tab2.Size = new System.Drawing.Size(597, 328);
            this.tab2.TabIndex = 1;
            this.tab2.Text = "2";
            this.tab2.UseVisualStyleBackColor = true;
            // 
            // tab2_Exitbtn
            // 
            this.tab2_Exitbtn.Location = new System.Drawing.Point(516, 299);
            this.tab2_Exitbtn.Name = "tab2_Exitbtn";
            this.tab2_Exitbtn.Size = new System.Drawing.Size(75, 23);
            this.tab2_Exitbtn.TabIndex = 0;
            this.tab2_Exitbtn.Text = "Exit";
            this.tab2_Exitbtn.UseVisualStyleBackColor = true;
            // 
            // tab2Text
            // 
            this.tab2Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tab2Text.Location = new System.Drawing.Point(6, 6);
            this.tab2Text.Name = "tab2Text";
            this.tab2Text.Size = new System.Drawing.Size(585, 287);
            this.tab2Text.TabIndex = 1;
            this.tab2Text.Text = "Lessons - here you can learn step by step.\nMy results - here you can train typing" +
    " words.\nManual - here you can read some info.";
            // 
            // UserGuideForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 357);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserGuideForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User guide";
            this.tabControl.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.tab2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tab1_Nextbtn;
        private System.Windows.Forms.Label tab1_Title;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab1;
        private System.Windows.Forms.TabPage tab2;
        private System.Windows.Forms.RichTextBox tab1Text;
        private System.Windows.Forms.Button tab2_Exitbtn;
        private System.Windows.Forms.RichTextBox tab2Text;
    }
}
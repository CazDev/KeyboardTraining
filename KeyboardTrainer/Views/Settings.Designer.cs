namespace KeyboardTrainer.Views
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.checkbx_Sound = new System.Windows.Forms.CheckBox();
            this.lbl_title = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_redTheme = new System.Windows.Forms.Button();
            this.btn_lightTheme = new System.Windows.Forms.Button();
            this.btn_darkTheme = new System.Windows.Forms.Button();
            this.btn_wipeData = new System.Windows.Forms.Button();
            this.btn_greenTheme = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkbx_Sound
            // 
            this.checkbx_Sound.AutoSize = true;
            this.checkbx_Sound.Location = new System.Drawing.Point(19, 29);
            this.checkbx_Sound.Name = "checkbx_Sound";
            this.checkbx_Sound.Size = new System.Drawing.Size(62, 17);
            this.checkbx_Sound.TabIndex = 0;
            this.checkbx_Sound.Text = "Sounds";
            this.checkbx_Sound.UseVisualStyleBackColor = true;
            this.checkbx_Sound.CheckedChanged += new System.EventHandler(this.Checkbx_Sound_CheckedChanged);
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lbl_title.Location = new System.Drawing.Point(159, 16);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(83, 25);
            this.lbl_title.TabIndex = 1;
            this.lbl_title.Text = "Settings";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.groupBox2);
            this.groupBox.Controls.Add(this.btn_wipeData);
            this.groupBox.Controls.Add(this.checkbx_Sound);
            this.groupBox.Location = new System.Drawing.Point(12, 57);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(370, 279);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_greenTheme);
            this.groupBox2.Controls.Add(this.btn_redTheme);
            this.groupBox2.Controls.Add(this.btn_lightTheme);
            this.groupBox2.Controls.Add(this.btn_darkTheme);
            this.groupBox2.Location = new System.Drawing.Point(12, 52);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(106, 144);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Themes";
            // 
            // btn_redTheme
            // 
            this.btn_redTheme.Location = new System.Drawing.Point(13, 82);
            this.btn_redTheme.Name = "btn_redTheme";
            this.btn_redTheme.Size = new System.Drawing.Size(75, 23);
            this.btn_redTheme.TabIndex = 2;
            this.btn_redTheme.Text = "Red";
            this.btn_redTheme.UseVisualStyleBackColor = true;
            // 
            // btn_lightTheme
            // 
            this.btn_lightTheme.Location = new System.Drawing.Point(13, 53);
            this.btn_lightTheme.Name = "btn_lightTheme";
            this.btn_lightTheme.Size = new System.Drawing.Size(75, 23);
            this.btn_lightTheme.TabIndex = 1;
            this.btn_lightTheme.Text = "Light";
            this.btn_lightTheme.UseVisualStyleBackColor = true;
            // 
            // btn_darkTheme
            // 
            this.btn_darkTheme.Location = new System.Drawing.Point(13, 24);
            this.btn_darkTheme.Name = "btn_darkTheme";
            this.btn_darkTheme.Size = new System.Drawing.Size(75, 23);
            this.btn_darkTheme.TabIndex = 0;
            this.btn_darkTheme.Text = "Dark";
            this.btn_darkTheme.UseVisualStyleBackColor = true;
            // 
            // btn_wipeData
            // 
            this.btn_wipeData.ForeColor = System.Drawing.Color.Black;
            this.btn_wipeData.Location = new System.Drawing.Point(6, 236);
            this.btn_wipeData.Name = "btn_wipeData";
            this.btn_wipeData.Size = new System.Drawing.Size(112, 37);
            this.btn_wipeData.TabIndex = 1;
            this.btn_wipeData.Text = "Wipe all data";
            this.btn_wipeData.UseVisualStyleBackColor = true;
            this.btn_wipeData.Click += new System.EventHandler(this.Btn_wipeData_Click);
            // 
            // btn_greenTheme
            // 
            this.btn_greenTheme.Location = new System.Drawing.Point(13, 111);
            this.btn_greenTheme.Name = "btn_greenTheme";
            this.btn_greenTheme.Size = new System.Drawing.Size(75, 23);
            this.btn_greenTheme.TabIndex = 3;
            this.btn_greenTheme.Text = "Green";
            this.btn_greenTheme.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 350);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.lbl_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkbx_Sound;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btn_wipeData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_lightTheme;
        private System.Windows.Forms.Button btn_darkTheme;
        private System.Windows.Forms.Button btn_redTheme;
        private System.Windows.Forms.Button btn_greenTheme;
    }
}
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
            this.gb_themes = new System.Windows.Forms.GroupBox();
            this.rb_Green = new System.Windows.Forms.RadioButton();
            this.rb_Red = new System.Windows.Forms.RadioButton();
            this.rb_Light = new System.Windows.Forms.RadioButton();
            this.rb_Dark = new System.Windows.Forms.RadioButton();
            this.btn_wipeData = new System.Windows.Forms.Button();
            this.btn_done = new System.Windows.Forms.Button();
            this.groupBox.SuspendLayout();
            this.gb_themes.SuspendLayout();
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
            this.groupBox.Controls.Add(this.gb_themes);
            this.groupBox.Controls.Add(this.btn_wipeData);
            this.groupBox.Controls.Add(this.checkbx_Sound);
            this.groupBox.Location = new System.Drawing.Point(12, 57);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(370, 246);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Settings";
            // 
            // gb_themes
            // 
            this.gb_themes.Controls.Add(this.rb_Green);
            this.gb_themes.Controls.Add(this.rb_Red);
            this.gb_themes.Controls.Add(this.rb_Light);
            this.gb_themes.Controls.Add(this.rb_Dark);
            this.gb_themes.Location = new System.Drawing.Point(19, 52);
            this.gb_themes.Name = "gb_themes";
            this.gb_themes.Size = new System.Drawing.Size(87, 118);
            this.gb_themes.TabIndex = 3;
            this.gb_themes.TabStop = false;
            this.gb_themes.Text = "Themes";
            // 
            // rb_Green
            // 
            this.rb_Green.AutoSize = true;
            this.rb_Green.Location = new System.Drawing.Point(6, 91);
            this.rb_Green.Name = "rb_Green";
            this.rb_Green.Size = new System.Drawing.Size(54, 17);
            this.rb_Green.TabIndex = 3;
            this.rb_Green.Text = "Green";
            this.rb_Green.UseVisualStyleBackColor = true;
            // 
            // rb_Red
            // 
            this.rb_Red.AutoSize = true;
            this.rb_Red.Location = new System.Drawing.Point(6, 68);
            this.rb_Red.Name = "rb_Red";
            this.rb_Red.Size = new System.Drawing.Size(45, 17);
            this.rb_Red.TabIndex = 2;
            this.rb_Red.Text = "Red";
            this.rb_Red.UseVisualStyleBackColor = true;
            // 
            // rb_Light
            // 
            this.rb_Light.AutoSize = true;
            this.rb_Light.Location = new System.Drawing.Point(6, 45);
            this.rb_Light.Name = "rb_Light";
            this.rb_Light.Size = new System.Drawing.Size(48, 17);
            this.rb_Light.TabIndex = 1;
            this.rb_Light.Text = "Light";
            this.rb_Light.UseVisualStyleBackColor = true;
            // 
            // rb_Dark
            // 
            this.rb_Dark.AutoSize = true;
            this.rb_Dark.Location = new System.Drawing.Point(6, 22);
            this.rb_Dark.Name = "rb_Dark";
            this.rb_Dark.Size = new System.Drawing.Size(48, 17);
            this.rb_Dark.TabIndex = 0;
            this.rb_Dark.Text = "Dark";
            this.rb_Dark.UseVisualStyleBackColor = true;
            // 
            // btn_wipeData
            // 
            this.btn_wipeData.ForeColor = System.Drawing.Color.Black;
            this.btn_wipeData.Location = new System.Drawing.Point(6, 203);
            this.btn_wipeData.Name = "btn_wipeData";
            this.btn_wipeData.Size = new System.Drawing.Size(112, 37);
            this.btn_wipeData.TabIndex = 1;
            this.btn_wipeData.Text = "Wipe all data";
            this.btn_wipeData.UseVisualStyleBackColor = true;
            this.btn_wipeData.Click += new System.EventHandler(this.Btn_wipeData_Click);
            // 
            // btn_done
            // 
            this.btn_done.Location = new System.Drawing.Point(307, 309);
            this.btn_done.Name = "btn_done";
            this.btn_done.Size = new System.Drawing.Size(82, 29);
            this.btn_done.TabIndex = 3;
            this.btn_done.Text = "Done";
            this.btn_done.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 350);
            this.Controls.Add(this.btn_done);
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
            this.gb_themes.ResumeLayout(false);
            this.gb_themes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkbx_Sound;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button btn_wipeData;
        private System.Windows.Forms.GroupBox gb_themes;
        private System.Windows.Forms.RadioButton rb_Green;
        private System.Windows.Forms.RadioButton rb_Red;
        private System.Windows.Forms.RadioButton rb_Light;
        private System.Windows.Forms.RadioButton rb_Dark;
        private System.Windows.Forms.Button btn_done;
    }
}
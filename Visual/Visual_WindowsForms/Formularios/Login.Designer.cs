namespace Visual_WindowsForms.Formularios
{
    partial class Login
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
            label1 = new Label();
            Username = new Label();
            label3 = new Label();
            btn_Login = new Button();
            btn_Cancel = new Button();
            txt_User = new TextBox();
            Txt_Pass = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(358, 19);
            label1.Name = "label1";
            label1.Size = new Size(103, 46);
            label1.TabIndex = 0;
            label1.Text = "Login";
            // 
            // Username
            // 
            Username.AutoSize = true;
            Username.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Username.Location = new Point(120, 127);
            Username.Name = "Username";
            Username.Size = new Size(99, 28);
            Username.TabIndex = 1;
            Username.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(126, 189);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 2;
            label3.Text = "Password";
            // 
            // btn_Login
            // 
            btn_Login.Location = new Point(230, 282);
            btn_Login.Name = "btn_Login";
            btn_Login.Size = new Size(132, 40);
            btn_Login.TabIndex = 3;
            btn_Login.Text = "Login";
            btn_Login.UseVisualStyleBackColor = true;
            btn_Login.Click += btn_Login_Click;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Location = new Point(491, 282);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(132, 40);
            btn_Cancel.TabIndex = 4;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btn_Cancel_Click;
            // 
            // txt_User
            // 
            txt_User.Location = new Point(274, 127);
            txt_User.Name = "txt_User";
            txt_User.Size = new Size(277, 23);
            txt_User.TabIndex = 5;
            // 
            // Txt_Pass
            // 
            Txt_Pass.Location = new Point(274, 194);
            Txt_Pass.Name = "Txt_Pass";
            Txt_Pass.Size = new Size(277, 23);
            Txt_Pass.TabIndex = 6;
            Txt_Pass.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.RosyBrown;
            ClientSize = new Size(800, 450);
            Controls.Add(Txt_Pass);
            Controls.Add(txt_User);
            Controls.Add(btn_Cancel);
            Controls.Add(btn_Login);
            Controls.Add(label3);
            Controls.Add(Username);
            Controls.Add(label1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label Username;
        private Label label3;
        private Button btn_Login;
        private Button btn_Cancel;
        private TextBox txt_User;
        private TextBox Txt_Pass;
    }
}
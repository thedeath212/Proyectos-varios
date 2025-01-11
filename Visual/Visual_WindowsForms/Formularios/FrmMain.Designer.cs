namespace Visual_WindowsForms.Formularios
{
    partial class FrmMain
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
            gbUsuario = new DataGridView();
            btn_Eliminar = new Button();
            btn_Modificar = new Button();
            btn_Guardar = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            combo = new ComboBox();
            label6 = new Label();
            txtNombre = new TextBox();
            txt_Usuario = new TextBox();
            Txt_Contraseña = new TextBox();
            txt_Apellido = new TextBox();
            txtEmail = new TextBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)gbUsuario).BeginInit();
            SuspendLayout();
            // 
            // gbUsuario
            // 
            gbUsuario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gbUsuario.Location = new Point(12, 12);
            gbUsuario.Name = "gbUsuario";
            gbUsuario.RowTemplate.Height = 25;
            gbUsuario.Size = new Size(894, 175);
            gbUsuario.TabIndex = 0;
            gbUsuario.CellClick += gbUsuario_CellContentClick;
            gbUsuario.CellContentClick += gbUsuario_CellContentClick_1;
            // 
            // btn_Eliminar
            // 
            btn_Eliminar.Location = new Point(713, 340);
            btn_Eliminar.Name = "btn_Eliminar";
            btn_Eliminar.Size = new Size(193, 39);
            btn_Eliminar.TabIndex = 2;
            btn_Eliminar.Text = "Eliminar";
            btn_Eliminar.UseVisualStyleBackColor = true;
            btn_Eliminar.Click += btn_Eliminar_Click;
            // 
            // btn_Modificar
            // 
            btn_Modificar.Location = new Point(713, 295);
            btn_Modificar.Name = "btn_Modificar";
            btn_Modificar.Size = new Size(193, 39);
            btn_Modificar.TabIndex = 3;
            btn_Modificar.Text = "Modificar";
            btn_Modificar.UseVisualStyleBackColor = true;
            btn_Modificar.Click += btn_Modificar_Click;
            // 
            // btn_Guardar
            // 
            btn_Guardar.Location = new Point(713, 244);
            btn_Guardar.Name = "btn_Guardar";
            btn_Guardar.Size = new Size(193, 39);
            btn_Guardar.TabIndex = 4;
            btn_Guardar.Text = "Guardar";
            btn_Guardar.UseVisualStyleBackColor = true;
            btn_Guardar.Click += btn_Guardar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(43, 323);
            label1.Name = "label1";
            label1.Size = new Size(86, 28);
            label1.TabIndex = 5;
            label1.Text = "Apellido";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(44, 382);
            label2.Name = "label2";
            label2.Size = new Size(59, 28);
            label2.TabIndex = 6;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(44, 255);
            label3.Name = "label3";
            label3.Size = new Size(85, 28);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(356, 255);
            label4.Name = "label4";
            label4.Size = new Size(79, 28);
            label4.TabIndex = 8;
            label4.Text = "Usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(343, 323);
            label5.Name = "label5";
            label5.Size = new Size(110, 28);
            label5.TabIndex = 9;
            label5.Text = "Contraseña";
            // 
            // combo
            // 
            combo.FormattingEnabled = true;
            combo.Location = new Point(484, 387);
            combo.Name = "combo";
            combo.Size = new Size(197, 23);
            combo.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(372, 383);
            label6.Name = "label6";
            label6.Size = new Size(40, 28);
            label6.TabIndex = 11;
            label6.Text = "Rol";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(147, 263);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(166, 23);
            txtNombre.TabIndex = 12;
            // 
            // txt_Usuario
            // 
            txt_Usuario.Location = new Point(484, 263);
            txt_Usuario.Name = "txt_Usuario";
            txt_Usuario.Size = new Size(197, 23);
            txt_Usuario.TabIndex = 13;
            // 
            // Txt_Contraseña
            // 
            Txt_Contraseña.Location = new Point(484, 324);
            Txt_Contraseña.Name = "Txt_Contraseña";
            Txt_Contraseña.Size = new Size(197, 23);
            Txt_Contraseña.TabIndex = 14;
            // 
            // txt_Apellido
            // 
            txt_Apellido.Location = new Point(147, 324);
            txt_Apellido.Name = "txt_Apellido";
            txt_Apellido.Size = new Size(166, 23);
            txt_Apellido.TabIndex = 15;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(109, 387);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(204, 23);
            txtEmail.TabIndex = 16;
            // 
            // button1
            // 
            button1.Location = new Point(713, 395);
            button1.Name = "button1";
            button1.Size = new Size(193, 34);
            button1.TabIndex = 17;
            button1.Text = "Limpiar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FloralWhite;
            ClientSize = new Size(933, 450);
            Controls.Add(button1);
            Controls.Add(txtEmail);
            Controls.Add(txt_Apellido);
            Controls.Add(Txt_Contraseña);
            Controls.Add(txt_Usuario);
            Controls.Add(txtNombre);
            Controls.Add(label6);
            Controls.Add(combo);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btn_Guardar);
            Controls.Add(btn_Modificar);
            Controls.Add(btn_Eliminar);
            Controls.Add(gbUsuario);
            Name = "FrmMain";
            Text = "FrmMain";
            Load += FrmMain_Load;
            ((System.ComponentModel.ISupportInitialize)gbUsuario).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView gbUsuario;
        private Button btn_Eliminar;
        private Button btn_Modificar;
        private Button btn_Guardar;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private ComboBox combo;
        private Label label6;
        private TextBox txtNombre;
        private TextBox txt_Usuario;
        private TextBox Txt_Contraseña;
        private TextBox txt_Apellido;
        private TextBox txtEmail;
        private Button button1;
    }
}
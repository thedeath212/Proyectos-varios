using Visual_Logica;

namespace Visual_WindowsForms.Formularios
{
    public partial class Login : Form
    {
        //Costructor
        public Login()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(Login_FormClosing);
        }

        private void SingUp()
        {
            string username = txt_User.Text.TrimStart().TrimEnd();
            string password = Txt_Pass.Text;

            var resultLogin = LogicaUser.getUsersByLogin(username, password);
            if (resultLogin != null)
            {
                MessageBox.Show("Bienvenido al sistema \n" +
                    resultLogin.usu_name + "" + resultLogin.usu_lastname + "\n" +
                    "Rol: " + resultLogin.Rol.rol_description,
                    "Sistema Medico ", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LogicaUser.RestablecerIntentosFallidos(username);

                FrmMain frmain = new FrmMain();
                frmain.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show(" Usuario o contraseña incorrectos",
                   "Sistema Medico XYZ", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);

                // Llamar a la función para actualizar intentos fallidos
                LogicaUser.ActualizarIntentosFallidos(username, password);

                // Obtener el número actual de intentos fallidos
                int intentosFallidos = LogicaUser.ObtenerIntentosFallidos(username);

                // Puedes mostrar un mensaje adicional o realizar acciones específicas según el número de intentos fallidos
                if (intentosFallidos >= 3)
                {
                    MessageBox.Show("Has alcanzado el límite de intentos. Tu cuenta está bloqueada.",
                        "Sistema Medico XYZ", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SingUp();
        }


        private void btn_Cancel_Click(object sender, EventArgs e)
        {

        }

        private void Login_FormClosing(object? sender, FormClosingEventArgs e)
        {
            // Reiniciar el contador de intentos fallidos al cerrar la aplicación
            string username = txt_User.Text.TrimStart().TrimEnd();
            LogicaUser.RestablecerIntentosFallidos(username);
        }

    }
}
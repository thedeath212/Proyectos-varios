using System.Data;
using VisualExamen;
using Visual_Logica;
namespace Visual_WindowsForms.Formularios
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            loadUser();
            loadRol();
        }

        private void loadUser()
        {
            var usuarios = LogicaUser.getAllUsers();
            if (usuarios != null && usuarios.Count > 0)
            {
                gbUsuario.DataSource = usuarios.Select(data => new
                {
                    Id = data.usu_id,
                    Apellido = data.usu_lastname,
                    Nombre = data.usu_name,
                    Correo = data.usu_email,
                    UsuarioNombre = data.usu_username,
                    Contraseña = data.usu_password,
                    Estado = data.usu_status,
                    Rol = data.Rol.rol_description
                }).ToList();
            }
        }

        private void loadRol()
        {
            try
            {
                var roles = LogicaRoles.getAllRols();
                if (roles != null && roles.Count > 0)
                {
                    combo.DataSource = roles;
                    combo.DisplayMember = "rol_description";
                    combo.ValueMember = "rol_id";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar roles: {ex.Message}",
                                "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void guardar()
        {
            if (ValidarCampos())
            {
                try
                {
                    String lastname = txt_Apellido.Text;
                    String Name = txtNombre.Text;
                    String email = txtEmail.Text;
                    String usuario = txt_Usuario.Text;
                    String password = Visual_Logica.Complementos.Encriptar.GetSHA1(Txt_Contraseña.Text);
                    int rolId = (int)combo.SelectedValue;

                    User user = new User()
                    {
                        usu_lastname = lastname,
                        usu_name = Name,
                        usu_email = email,
                        usu_username = usuario,
                        usu_password = password,
                        rol_id = rolId
                    };
                    var resultadoGuardado = LogicaUser.saveUser(user, usuario);
                    if (resultadoGuardado)
                    {
                        MessageBox.Show("Usuario guardado correctamente",
                            "Éxito", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        LimpiarControles();
                        loadUser();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el usuario",
                            "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}",
                        "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Guardar_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void btn_Modificar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    if (gbUsuario.SelectedRows.Count > 0)
                    {
                        DataGridViewRow filaSeleccionada = gbUsuario.SelectedRows[0];
                        int idUsuario = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);
                        User usuarioSeleccionado = LogicaUser.getUsersById(idUsuario);

                        usuarioSeleccionado.usu_lastname = txt_Apellido.Text.Trim();
                        usuarioSeleccionado.usu_name = txtNombre.Text.Trim();
                        usuarioSeleccionado.usu_email = txtEmail.Text.Trim();
                        usuarioSeleccionado.usu_username = txt_Usuario.Text.Trim();
                        usuarioSeleccionado.usu_password = Visual_Logica.Complementos.Encriptar.GetSHA1(Txt_Contraseña.Text.Trim());

                        if (combo.SelectedItem != null && combo.SelectedValue != null)
                        {
                            // Obtener tanto el valor como la descripción seleccionados
                            int rolId = (int)combo.SelectedValue;
                            string rolDescripcion = ((Rol)combo.SelectedItem).rol_description;

                            usuarioSeleccionado.rol_id = rolId;
                            string nombreUsuario = "NombreDelUsuarioQueRealizaLaActualizacion";
                            bool resultadoActualizacion = LogicaUser.updateUser(usuarioSeleccionado, nombreUsuario);


                            if (resultadoActualizacion)
                            {
                                MessageBox.Show("Usuario modificado correctamente",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LimpiarControles();

                                loadUser();

                                // Actualizar la descripción del rol en el ComboBox
                                combo.Text = rolDescripcion;
                                loadRol();
                            }
                            else
                            {
                                MessageBox.Show("Error al modificar el usuario",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Por favor, seleccione un rol válido",
                                "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Por favor, seleccione un usuario para modificar",
                            "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al modificar el usuario: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void gbUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = gbUsuario.Rows[e.RowIndex];
                int idUsuario = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);
                User usuarioSeleccionado = LogicaUser.getUsersById(idUsuario);

                txt_Apellido.Text = usuarioSeleccionado.usu_lastname;
                txtNombre.Text = usuarioSeleccionado.usu_name;
                txtEmail.Text = usuarioSeleccionado.usu_email;
                txt_Usuario.Text = usuarioSeleccionado.usu_username;
                Txt_Contraseña.Text = usuarioSeleccionado.usu_password;
                combo.SelectedValue = usuarioSeleccionado.rol_id;
            }
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gbUsuario.SelectedRows.Count > 0)
                {
                    DataGridViewRow filaSeleccionada = gbUsuario.SelectedRows[0];
                    int idUsuario = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);
                    User usuarioSeleccionado = LogicaUser.getUsersById(idUsuario);
                    DialogResult resultado = MessageBox.Show("¿Estás seguro de que deseas eliminar este usuario?",
                                                              "Confirmar Eliminación",
                                                              MessageBoxButtons.YesNo,
                                                              MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        bool resultadoEliminacion = LogicaUser.deleteUser(usuarioSeleccionado, "NombreDelUsuarioQueRealizaLaEliminacion");

                        if (resultadoEliminacion)
                        {
                            MessageBox.Show("Usuario eliminado correctamente",
                                            "Éxito", MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);
                            LimpiarControles();
                            loadUser();
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el usuario",
                                            "Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un usuario para eliminar",
                                    "Advertencia", MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                                "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void LimpiarControles()
        {
            txt_Apellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txt_Usuario.Text = string.Empty;
            Txt_Contraseña.Text = string.Empty;
            combo.SelectedIndex = -1;
        }

        private bool ValidarCampos()
        {
            string apellido = txt_Apellido.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string email = txtEmail.Text.Trim();
            string usuario = txt_Usuario.Text.Trim();
            string contraseña = Txt_Contraseña.Text.Trim();

            if (string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(usuario) ||
                string.IsNullOrEmpty(contraseña) ||
                combo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, complete todos los campos",
                                "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            if (!EsSoloLetras(apellido) || !EsSoloLetras(nombre))
            {
                MessageBox.Show("El nombre y el apellido deben contener solo letras",
                                "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            if (apellido.Length > 10 || nombre.Length > 10)
            {
                MessageBox.Show("El nombre y el apellido deben tener una longitud máxima de 10 caracteres",
                                "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            if (!EsFormatoEmailValido(email))
            {
                MessageBox.Show("El formato del correo electrónico no es válido, debe contener un @ y un .com",
                                "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            if (!EsAlfanumerico(usuario) || usuario.Length > 10)
            {
                MessageBox.Show("El nombre de usuario debe contener solo letras y números, y tener una longitud máxima de 10 caracteres",
                                "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            if (!EsContraseñaValida(contraseña))
            {
                MessageBox.Show("La contraseña debe contener al menos una mayúscula, un número y un carácter especial, y tener una longitud de al menos 8 caracteres",
                                "Advertencia", MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private bool EsSoloLetras(string input)
        {
            return input.All(char.IsLetter);
        }

        private bool EsFormatoEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool EsAlfanumerico(string input)
        {
            return input.All(char.IsLetterOrDigit);
        }

        private bool EsContraseñaValida(string contraseña)
        {
            return contraseña.Any(char.IsUpper) &&
                   contraseña.Any(char.IsDigit) &&
                   contraseña.Any(ch => !char.IsLetterOrDigit(ch)) &&
                   contraseña.Length >= 8;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }

        private void gbUsuario_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

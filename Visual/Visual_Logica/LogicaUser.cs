using System;
using System.Windows.Forms;
using MessageBox = System.Windows.Forms.MessageBox;
using MindboxRefreshMode = Mindbox.Data.Linq.RefreshMode;
using VisualExamen;
using System.Linq;
using System.Collections.Generic;

namespace Visual_Logica
{
    public class LogicaUser
    {
        private static DCClinicaDataContext dc = new DCClinicaDataContext();


        public static User getUsersByLogin(string username, string password)
        {
            try
            {
                var user = dc.User
                    .Where(data => data.usu_status.Equals("A")
                                   && data.usu_username.Equals(username)
                                   && data.usu_password.Equals(password));

                var foundUser = user.FirstOrDefault();

                if (foundUser != null)
                {
                    // Verificar el estado del usuario
                    if (foundUser.usu_status.Equals("B"))
                    {
                        throw new InvalidOperationException("Tu usuario está bloqueado.");
                    }

                    // Si el usuario no está bloqueado, devolverlo
                    return foundUser;
                }

                // Si no se encuentra el usuario, retornar null o manejar según sea necesario
                return null;
            }
            catch
            {
                throw new ArgumentException("Error en login");
            }
        }

        public static List<User> getAllUsers()
        {
            try
            {
                var lista = dc.User
                    .Where(data => data.usu_status.Equals("A"));
                return lista.ToList();
            }
            catch
            {
                throw new ArgumentException("Error en login");
                //Aqui podriamos conectarnos a la api externa
            }
        }

        public static User getUsersById(int idUser)
        {
            try
            {
                var users = dc.User
                    .Where(data => data.usu_status.Equals("A")
                                   && data.usu_id.Equals(idUser));


                return users.FirstOrDefault();
            }
            catch
            {
                throw new ArgumentException("Error en login");
            }
        }

        public static bool saveUser(User user, string nombreUsuario)
        {
            try
            {
                user.usu_status = 'A';
                user.usu_add = DateTime.Now;
                dc.User.InsertOnSubmit(user);
                dc.SubmitChanges();

                // Insertar en la tabla de auditoría para la operación de Inserción
                LogicaAuditoria.InsertarAuditoria('I', user.usu_id, nombreUsuario, 'A');

                return true;
            }
            catch
            {
                return false;
            }
        }


        public static bool updateUserPs(List<User> lista_user)
        {
            try
            {
                foreach (var user in lista_user)
                {
                    user.usu_update = DateTime.Now;
                    dc.Refresh(MindboxRefreshMode.OverwriteCurrentValues, user);
                    dc.SubmitChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool deleteUser(User user, string nombreUsuario)
        {
            try
            {
                user.usu_delete = DateTime.Now;
                user.usu_status = 'I';

                // Guardar cambios en la base de datos
                dc.SubmitChanges();

                // Insertar en la tabla de auditoría para la operación de Eliminación
                LogicaAuditoria.InsertarAuditoria('E', user.usu_id, nombreUsuario, 'A');

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool updateUser(User user, string nombreUsuario)
        {
            try
            {
                var existingUser = dc.User.FirstOrDefault(u => u.usu_id == user.usu_id);

                if (existingUser != null)
                {
                    // Actualizar las propiedades necesarias
                    existingUser.usu_lastname = user.usu_lastname;
                    existingUser.usu_name = user.usu_name;
                    existingUser.usu_email = user.usu_email;
                    existingUser.usu_username = user.usu_username;
                    existingUser.usu_password = user.usu_password;
                    existingUser.rol_id = user.rol_id;
                    existingUser.usu_update = DateTime.Now;

                    // Guardar los cambios en la base de datos
                    dc.SubmitChanges();

                    // Insertar en la tabla de auditoría para la operación de Modificación
                    LogicaAuditoria.InsertarAuditoria('M', user.usu_id, nombreUsuario, 'A');

                    return true;
                }
                else
                {
                    // El usuario no existe en la base de datos
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar usuario: {ex.Message}");
                return false;
            }
        }
        public static bool updateUserId(User user, int rolId)
        {
            try
            {
                dc = new DCClinicaDataContext();
                dc.ExecuteCommand("Update User SET usu_username ={0}," +
                                   "usu_password ={1}, " +
                                   "usu_username={2} ," +
                                   "usu_lastname={3}, " +
                                   "usu_email={4}, " +
                                   "rol_id={5} " +  // Elimina la coma después de {5}
                                   "WHERE usu_id={6}", new object[]
                                   {
                            user.usu_username,
                            user.usu_password,
                            user.usu_name,
                            user.usu_lastname,
                            user.usu_email,
                            rolId,  // Usar el valor pasado como parámetro
                            user.usu_id  // Agregar usu_id para la cláusula WHERE
                                    });

                // Actualice los datos en el contexto
                // Commit
                dc.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static void ActualizarIntentosFallidos(string username, string password)
        {
            try
            {
                using (var dc = new DCClinicaDataContext())
                {
                    var user = dc.User
                        .Where(data => data.usu_status.Equals("A") && data.usu_username.Equals(username))
                        .FirstOrDefault();

                    if (user != null)
                    {
                        if (user.usu_password.Equals(password))
                        {
                            // Si las credenciales son correctas, reiniciar el contador
                            user.usu_intentos = 0;
                        }
                        else
                        {
                            user.usu_intentos += 1;


                            if (user.usu_intentos >= 3)
                            {
                                // Bloquear al usuario cambiando su estado a 'B'
                                user.usu_status = 'B';


                                dc.SubmitChanges();

                                MessageBox.Show("Usuario bloqueado. Has excedido el límite de intentos.",
                                    "Sistema Medico XYZ", MessageBoxButtons.OK, MessageBoxIcon.Error);


                                user.usu_intentos = 0;
                            }
                        }
                        // Guardar el cambio en el contador de intentos en la base de datos
                        dc.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar intentos fallidos: {ex.Message}");
                throw;
            }
        }

        public static int ObtenerIntentosFallidos(string username)
        {
            try
            {
                var user = dc.User
                    .Where(data => data.usu_status.Equals("A") && data.usu_username.Equals(username))
                    .FirstOrDefault();

                // Devolver el número de intentos fallidos o 0 si el usuario no existe
                return user?.usu_intentos ?? 0;
            }
            catch
            {
                throw new ArgumentException("Error al obtener intentos fallidos");
            }
        }
        public static void RestablecerIntentosFallidos(string username)
        {
            try
            {
                var user = dc.User
                    .Where(data => data.usu_status.Equals("A") && data.usu_username.Equals(username))
                    .FirstOrDefault();

                if (user != null)
                {
                    dc.Refresh(MindboxRefreshMode.OverwriteCurrentValues, user);
                    user.usu_intentos = 0;
                    dc.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al restablecer intentos fallidos: {ex.Message}");
                throw;
            }
        }
    }
}

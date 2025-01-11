using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using VisualExamen;

namespace Visual_Logica
{
    public class LogicaRoles
    {
        private static DCClinicaDataContext dc = new DCClinicaDataContext();

        public static List<Rol> getAllRols()
        {

            try
            {
                var roles = dc.Rol
                            .Where(data => data.rol_status.Equals("A"))
                            .ToList();

                return roles;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener roles: {ex.Message}",
                                "Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                return null;
            }
        }

    }

}

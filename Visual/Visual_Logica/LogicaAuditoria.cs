using System;
using VisualExamen;


namespace Visual_Logica
{
    public class LogicaAuditoria
    {
        private static DCClinicaDataContext dc = new DCClinicaDataContext();

        public static void InsertarAuditoria(char tipoOperacion, int usuarioId, string nombreUsuario, char estadoRegistro)
        {
            try
            {
                Auditoria auditoria = new Auditoria
                {
                    Audi_Id = '0',
                    Audi_Tipo = tipoOperacion,
                    Audi_CodigoRegistro = usuarioId,
                    Audi_Usuario = nombreUsuario,
                    Audi_Estado = estadoRegistro,
                    Audi_Fecha = DateTime.Now
                };

                dc.Auditoria.InsertOnSubmit(auditoria);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al insertar registro de auditoría: {ex.Message}");
            }
        }
    }
}
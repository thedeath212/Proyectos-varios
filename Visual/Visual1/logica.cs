namespace Visual1
{
    internal class logica : vehiculo
    {
        public static decimal calcularIva(decimal precio, decimal iva)
        {
            return (precio * iva) / 100;
        }
    }
}
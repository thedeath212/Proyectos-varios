using System;
using System.Collections.Generic;
using System.Linq;

namespace Visual1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Como leer dato por teclado
            //int valor1;

            //valor1 = int.Parse( Console.ReadLine()); 

            vehiculo vehiculo1 = new vehiculo();
            vehiculo1.Codigo = 1;
            vehiculo1.Placa = "PHY876";
            vehiculo1.Marca = "Mazda";
            vehiculo1.Modelo = "C3";
            vehiculo1.Color = "Plomo";
            vehiculo1.Precio = 23000;

            vehiculo vehiculo2 = new vehiculo();
            vehiculo2.Codigo = 2;
            vehiculo2.Placa = "POO876";
            vehiculo2.Marca = "TOYOTA";
            vehiculo2.Modelo = "Yaris";
            vehiculo2.Color = "Rojo";
            vehiculo2.Precio = 40000;

            vehiculo vehiculo3 = new vehiculo();
            vehiculo3.Codigo = 3;
            vehiculo3.Placa = "PCC111";
            vehiculo3.Marca = "Audi";
            vehiculo3.Modelo = "Q3";
            vehiculo3.Color = "Rojo";
            vehiculo3.Precio = 50000;


            var listaVehiculos = new List<vehiculo>();

            listaVehiculos.Add(vehiculo1);
            listaVehiculos.Add(vehiculo2);
            listaVehiculos.Add(vehiculo3);

            foreach (var item in
                listaVehiculos.Where
                (data => data.Color.Equals("Rojo")
                //&& data.Codigo.Equals(2)
                ).OrderByDescending(data => data.Codigo))
            {
                Console.WriteLine("Codigo:" + item.Codigo);
                Console.WriteLine("Placa:" + item.Placa);
                Console.WriteLine("Marca:" + item.Marca);
                Console.WriteLine("Modelo:" + item.Modelo);
                Console.WriteLine("Color:" + item.Color);
                Console.WriteLine("Precio:" + item.Precio);
                var iva = logica.calcularIva(item.Precio, 12);
                Console.WriteLine("Iva:" + iva);
                Console.WriteLine("Total:" + (item.Precio + iva));
                Console.WriteLine("\n");
            }

            Console.WriteLine();
            Console.ReadLine();

        }
    }
}


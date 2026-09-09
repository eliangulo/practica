using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace practica
{
    public class ArchivoJson
    {
        static string ruta = @"C:\itsc\practica\productos.json";
        static string origen = @"C:\itsc\Beagle-cordoba.webp";
        static string destino = @"C:\itsc\practica\Beagle-cordoba.webp";

        public static void ManejoJson()
        {
            var productos = new List<Producto>()
            {
                new Producto { Id = 1, Nombre = "Teléfonos", Precio = 10, Stock = 6 },
                new Producto { Id = 2, Nombre = "Computadoras portátiles", Precio = 200000, Stock = 20 },
                new Producto { Id = 3, Nombre = "Impresoras 3D", Precio = 200000, Stock = 2 },
                new Producto { Id = 4, Nombre = "Relojes inteligentes ", Precio = 4000, Stock = 8 },
            };

            var jsonString = JsonSerializer.Serialize(productos);
            File.WriteAllText(ruta, jsonString);

            var contenedor = File.ReadAllText(ruta);
            var productosLeidos = JsonSerializer.Deserialize<List<Producto>>(contenedor);

            foreach (var producto in productosLeidos)
            {
                Console.WriteLine($"Id: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.Stock}");
            }
        }

        public static void MostrarProductosPorStock()
        {
            var contenido = File.ReadAllText(ruta);
            var productos2 = JsonSerializer.Deserialize<List<Producto>>(contenido);

            var productosFiltrados = productos2.Where(p => p.Stock < 10).ToList();

            foreach (var producto in productosFiltrados)
            {
                Console.WriteLine($"Id: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Stock: {producto.Stock}");
            }
        }

        public static void CopiarArchivo()
        {
            if (!Directory.Exists(@"C:\itsc\practica"))
            {
                Directory.CreateDirectory(@"C:\itsc\practica");
            }

            File.Copy(origen, destino, overwrite: true);

            var registro = new RegistroCopia
            {
                NombreArchivo = "Beagle-cordoba.webp",
                RutaDestino = destino
            };

            var rutaRegistro = @"C:\itsc\practica\registro.json";
            var jsonRegistro = JsonSerializer.Serialize(registro);
            File.WriteAllText(rutaRegistro, jsonRegistro);
        }

       

    }


    public class RegistroCopia
    {
        public string NombreArchivo { get; set; }
        public string RutaDestino { get; set; }
    }
}
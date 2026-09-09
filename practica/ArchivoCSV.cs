using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace practica
{
    public class ArchivoCSV
    {
        static string ruta = @"C:\itsc\practica\productos.csv";
        static string rutaTxt = @"C:\itsc\practica\Nombres.txt";

        static string rutaMil = @"C:\itsc\practica\productosMil.csv";




        public static void ListaProductos()
        {
            //verifico si el archivo existe, si no existe lo creo y agrego la cabecera
            if (!File.Exists(ruta))
            {
                using (var archivo = new StreamWriter(ruta, append: false, Encoding.UTF8))
                {
                    archivo.WriteLine("Id,Nombre,Precio,Stock");
                }
            }
            var producto = new List<Producto>()
            {
                new Producto {Id = 1, Nombre = "Teléfonos", Precio = 10, Stock = 6 },
                new Producto {Id = 2, Nombre = "Computadoras portátiles",Precio = 200000, Stock = 20},
                new Producto {Id = 3, Nombre = "Impresoras 3D", Precio = 200000, Stock = 2},
                new Producto {Id = 4,Nombre = "Relojes inteligentes ",Precio = 4000, Stock = 8},
            };

            var stringbuilde = new StringBuilder();

            foreach (var productos in producto)
            {
                stringbuilde.AppendLine($"{productos.Id},{productos.Nombre},{productos.Precio},{productos.Stock}");
            }

            using (var archivoNuevo = new StreamWriter(ruta, append: true, Encoding.UTF8))
            {
                archivoNuevo.Write(stringbuilde.ToString());
            }

        }
        public static void CargarProductosPorConsola()
        {
            Console.WriteLine("¿Cuántos productos querés cargar?");
            int cantidad = int.Parse(Console.ReadLine());
            
            var productos = new List<Producto>();

            for (int i = 0; i < cantidad; i++)
            {
                Console.WriteLine($"--- Producto {i + 1} ---");

                Console.WriteLine("Id:");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine("Nombre:");
                string nombre = Console.ReadLine();

                Console.WriteLine("Precio:");
                int precio = int.Parse(Console.ReadLine());

                Console.WriteLine("Stock:");
                int stock = int.Parse(Console.ReadLine());

                // Paso 1: crear el objeto con los datos que acabás de leer
                var nuevoProducto = new Producto { Id = id, Nombre = nombre, Precio = precio, Stock = stock };

                // Paso 2: agregarlo a la lista
                productos.Add(nuevoProducto);

            }
            var stringBuilder = new StringBuilder();

            foreach (var producto in productos)
            {
                stringBuilder.AppendLine($"{producto.Id},{producto.Nombre},{producto.Precio},{producto.Stock}");
            }
            using (var archivo = new StreamWriter(ruta, append: true, Encoding.UTF8))
            {
                archivo.Write(stringBuilder.ToString());
            };
        }

        public static void LeerCSV()
        {
            using (var lector = new StreamReader(ruta))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
        }

        public static void LeerNombres()
        {
            using (var leerTxt = new StreamReader(rutaTxt))
            {
                string lineas;
                while ((lineas = leerTxt.ReadLine()) != null)
                {
                    Console.WriteLine(lineas);
                }
            }
        }

        public static void ContarLineas()
        {
            int contador = 0;

            using(var leerTxt = new StreamReader(rutaTxt))
            {
                string lineas;
                while ((lineas = leerTxt.ReadLine()) != null)
                {
                    contador ++;
                }
            }

            Console.WriteLine($"El archivo tiene {contador} líneas.");
        }

        public static void CompararTiempos()
        {
            var sw = new Stopwatch();
            sw.Start();

            LeerCSV();

            sw.Stop();

            Console.WriteLine($"Tiempo de ejecución: {sw.ElapsedMilliseconds} ms");

            sw.Restart();

            var contenido = File.ReadAllText(ruta);

            sw.Stop();

            Console.WriteLine($"Contenido: {sw.ElapsedMilliseconds} ms");
        }
        public static void GenerarMilProductos()
        {
            var sw = new Stopwatch();

            sw.Start();
            var productosNuevos = new List<Producto>();
            for (int i = 0; i <= 1000; i++)
            {
                var producto = new Producto
                {
                    Id = i + 1,
                    Nombre = $"Producto {i}",
                    Precio = i * 100,
                    Stock = i % 20
                };
                productosNuevos.Add(producto);
            }

            var stringBuilder = new StringBuilder();
            foreach (var producto in productosNuevos)
            {
                stringBuilder.AppendLine($"{producto.Id},{producto.Nombre},{producto.Precio},{producto.Stock}");
            }

            using (var archivo = new StreamWriter(rutaMil, append: false, Encoding.UTF8))
            {
                archivo.Write(stringBuilder.ToString());
            }

            sw.Stop();

            Console.WriteLine($"Generar el CSV tardó: {sw.ElapsedMilliseconds} ms");


            sw.Restart();

            using (var lector = new StreamReader(rutaMil))
            {
                string linea;
                while ((linea = lector.ReadLine()) != null)
                {
                    Console.WriteLine(linea);
                }
            }
            sw.Stop();
            Console.WriteLine($"Leer el CSV tardó: {sw.ElapsedMilliseconds} ms");


        }

    }
}

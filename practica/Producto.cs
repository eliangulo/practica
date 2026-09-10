using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace practica
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Precio { get; set; }
        public int Stock { get; set; }


        public class ProdExamen
        {
            static string ruta = @"C:\itsc\practica\archivoProductosExam.csv";

            public static List<Producto> ListarProductos()
            {
                var listaProductos = new List<Producto>()
                {
                     new Producto() { Id = 1, Nombre = "Telefono", Precio = 250, Stock = 50 },
                     new Producto() { Id = 2, Nombre = "Auriculares", Precio = 55, Stock = 10 },
                };
                return listaProductos; 
            }
            
            public static void Crear()
            {
                if(!File.Exists(ruta))
                {
                    using(var contenido = new StreamWriter(ruta, append: true, Encoding.UTF8))
                    {
                        contenido.WriteLine("Id, Nombre, Precio, Stock");
                    }
                }

                var listaProducto = ListarProductos();
                var stringBuilder = new StringBuilder();

                foreach(var Producto in listaProducto)
                {
                    stringBuilder.AppendLine($"{Producto.Id}," +
                        $" {Producto.Nombre}, {Producto.Precio}, {Producto.Stock}");
                }

                using (var archivo = new StreamWriter(ruta, append: true, Encoding.UTF8))
                {
                    archivo.Write(stringBuilder.ToString());
                }

            }
        }
    }


}

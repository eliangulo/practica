using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public decimal PrecioConDescuento { get; set; }


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

        public static List<Producto> ListarTodos()
        {
            var listaProd = new List<Producto>()
            {
                new Producto() {Id = 1,Nombre="Producto1", Precio=12, Stock = 4, PrecioConDescuento = 0},
                new Producto() {Id = 2,Nombre="Producto2", Precio=16, Stock = 16},
                new Producto() {Id = 3,Nombre="Producto3", Precio=102, Stock = 10},
                new Producto() {Id = 4,Nombre="Producto4", Precio=235, Stock = 1},
                new Producto() {Id = 5,Nombre="Producto5", Precio=422, Stock = 5},
            };

            return listaProd;
        }
        public static void AplicarDescuento()
        {
            var listaProd = ListarTodos();
            var sw = new Stopwatch();
            sw.Start();
            Parallel.For(0,listaProd.Count, i =>
            {
                listaProd[i].PrecioConDescuento = listaProd[i].Precio * 0.8m;
                Console.WriteLine($"{listaProd[i].Nombre} - Precio: {listaProd[i].Precio} -" +
                    $" Con descuento: {listaProd[i].PrecioConDescuento} -" +
                    $" Hilo: {Thread.CurrentThread.ManagedThreadId}");
            });
            sw.Stop();
            Console.WriteLine($"El tiempo es de {sw.ElapsedMilliseconds} ms");
           
        }
    }


}

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Text;

namespace practica
{
    public class Peliculas
    {
        public string? Title { get; set; }
        public int Year { get; set; }

        static string ruta = @"C:\itsc\practica\peliculas.csv";

        public static List<Peliculas> ListarPeliculas()
        {
            var listaPelicula = new List<Peliculas>()
            {
                new Peliculas() { Title = "Rapido y Furioso", Year = 2000},
                new Peliculas() { Title = "Terminator 2: Juicio final", Year = 1991},
                new Peliculas() { Title = "Duro de matar", Year = 1988},

            };
            return listaPelicula;
        }

        public static void CrearCSVPeliculas()
        {
            var listarPelicula = ListarPeliculas();
            var stringBuilder = new StringBuilder();

            foreach (var peliculas in listarPelicula)
            {
                stringBuilder.AppendLine($"{peliculas.Title},{peliculas.Year}");
            }

            using(var contenido = new StreamWriter(ruta, append: true, Encoding.UTF8))
            {
                contenido.Write(stringBuilder.ToString());
            }
        }
        public static async Task TareaA()
        {
            await Task.Delay(500);
            Console.WriteLine("TareaA terminada");
        }

        public static async Task TareaB()
        {
            await Task.Delay(500);
            Console.WriteLine("TareaB terminada");
        }

        


        public static async Task Secuencial()
        {
            Console.WriteLine("--Secuencial--");
            var sw = new Stopwatch();

            sw.Start();

            await TareaA();
            await TareaB();

            sw.Stop();
           
            Console.WriteLine($"El tiempo total es {sw.ElapsedMilliseconds}sg");
        }

        public static async Task Paralelo()
        {
            Console.WriteLine("--Paralelo--");
            var sw = new Stopwatch();
            sw.Start();

            var listaTareas = new List<Task>
            {
         
                TareaA(),
                TareaB()
            };

            await Task.WhenAll(listaTareas);
            sw.Stop();
            Console.WriteLine($"El tiempo total es {sw.ElapsedMilliseconds}sg");
           
        }
    }
}

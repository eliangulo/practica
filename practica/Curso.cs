using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace practica
{
    public class Curso
    {
        public List<Alumno> alumnos;
        public Curso()
        {
            alumnos = new List<Alumno>()
            {
                new Alumno() {Nombre = "Eliana", Edad = 26},
                new Alumno() { Nombre = "Gabriela", Edad = 30 },
                new Alumno() {Nombre = "Griselda", Edad = 21},
                new Alumno() { Nombre = "Sofia", Edad = 18 },

            };

            var curso1 = new Curso();
            foreach (var alumno in alumnos)
            {
                Console.WriteLine($"{alumno.Nombre} - {alumno.Edad}");
            }
        }

        static string ruta = @"C:\itsc\practica\peliculas.csv";

        public static async Task LeerLineas()
        {
            var sw = new Stopwatch();
            sw.Start();
            using (var contenido = new StreamReader(ruta))
            {
                int contador = 0;
                while(contenido.ReadLine() != null)
                {
                    contador++;
                }

                Console.WriteLine($"Cantidad de líneas: {contador}");
            }
           sw.Stop();
          

            Console.WriteLine($"El tiempo {sw.ElapsedMilliseconds}ms");
            var sw2 = new Stopwatch();
            sw2.Start();

            var texto = File.ReadAllText(ruta);

            sw2.Stop();
            Console.WriteLine($"File.ReadAllText tardó: {sw2.ElapsedMilliseconds} ms");

        }

       
        
    }
}

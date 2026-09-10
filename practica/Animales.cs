using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace practica
{
    public class Animales
    {
        static string ruta = @"C:\itsc\practica\animales.csv";
      
        public static List<Animal> ListarAnimales()
        {
            var listaAnimales = new List<Animal>()
            {
                new Animal() { Id = 1, Nombre = "Leon", URL = "" },
                new Animal() { Id = 2, Nombre = "Tigre", URL = "" },
            };

            return listaAnimales;
        }


        public static void CrearCsvAnimales()
        {

            var listaAnimales = ListarAnimales(); 
            var stringBuilder = new StringBuilder();
            

            foreach (var animal in listaAnimales)
            {
                stringBuilder.AppendLine($"{animal.Id}, {animal.Nombre}, {animal.URL}");
            }

            using (var archivo = new StreamWriter(ruta, append: true, Encoding.UTF8))
            {
                archivo.Write(stringBuilder.ToString());
            }
        }
       
    }

    public class Animal()
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? URL { get; set; }

    }
}

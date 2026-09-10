using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace practica
{
    public class Libro
    {
        public string  Titulo { get; set; }
        public string Autor { get; set; }
        public int Paginas { get; set; }

        public static List<Libro> ListarLibros()
        {
            var listaLibros = new List<Libro>()
            {
                 new Libro() {Titulo = "Nuestra parte de noche", Autor = "Mariana Enriquez", Paginas = 680 },
                 new Libro() {Titulo = "Rayuela", Autor = "Julio Cortázar", Paginas = 600 },
                 new Libro() {Titulo = "El Aleph", Autor = "Jorge Luis Borges", Paginas = 180 },
                 new Libro() {Titulo = "Sobre héroes y tumbas", Autor = "Ernesto Sabato", Paginas = 510 },
                 new Libro() {Titulo = "El túnel", Autor = "Ernesto Sabato", Paginas = 160 },
            };
            return listaLibros;
        }

       
    }
    public class EjercicioLibro() 
    {
        static string ruta = @"C:\itsc\practica\Libros.json";

        public static void GuardarLibros()
        {
            var listalibro = Libro.ListarLibros();

            var JsonString = JsonSerializer.Serialize(listalibro);
            File.WriteAllText(ruta, JsonString);
        }

        public static void FiltrarLibros()
        {
            var contenido = File.ReadAllText(ruta);
            var libros = JsonSerializer.Deserialize<List<Libro>>(contenido);

            var librosFiltrados = libros.Where(p => p.Paginas > 300).ToList();

            foreach (var libro in librosFiltrados)
            {
                Console.WriteLine($"{libro.Titulo} - {libro.Autor} - {libro.Paginas} páginas");
            }
        }
    }

}

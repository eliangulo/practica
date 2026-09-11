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
            File.WriteAllText(ruta, JsonString, new UTF8Encoding(true));
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
        public static void AgregarLibros()
        {
            var ruta = @"C:\itsc\practica\Libros.json";
            var contenido = File.ReadAllText(ruta);
            var librosExistentes = JsonSerializer.Deserialize<List<Libro>>(contenido);

            var listaNueva = new List<Libro>
           {
              new Libro() {Titulo = "Puentes de Madison", Autor = "Madison", Paginas = 680 },
              new Libro() {Titulo = "Comer, rezar, amar", Autor = "Julia Roberts", Paginas = 600 },
           };

            foreach (var libro in listaNueva)
            {
                librosExistentes.Add(libro);
            }

            var JsonString = JsonSerializer.Serialize(librosExistentes);
            File.WriteAllText(ruta, JsonString);

        }
        //Lee el json existente y agrega nuevos libros a ese archivo.
        public static void LeerArchivo()
        {
            var rutaLectura = @"C:\itsc\practica\Libros.json";

            var texto = File.ReadAllText(rutaLectura);
            var nuevoArchivo = JsonSerializer.Deserialize<List<Libro>>(texto);

            var nuevosLibros = new List<Libro>
            {
                new Libro() { Titulo = "libro 1", Autor = "autor1", Paginas =100 },
                new Libro() { Titulo = "libro 2", Autor = "autor2", Paginas =120 },
            };

            foreach (var libro in nuevosLibros)
            {
                nuevoArchivo.Add(libro);
            }

            var JsonString = JsonSerializer.Serialize(nuevoArchivo);
            File.WriteAllText(rutaLectura, JsonString);

        }

        public static void MasLibros()
        {
            var leerLibro = File.ReadAllText(ruta);
            var agregar = JsonSerializer.Deserialize<List<Libro>>(leerLibro);

            var librosNuevos = new List<Libro>
            {
                new Libro() {Titulo = "Libro 3", Autor = "Autor3", Paginas = 125},
                new Libro() {Titulo = "Libro 4", Autor = "Autor4", Paginas = 220},
            };

            foreach (var libro in librosNuevos)
            {
                agregar.Add(libro);
            }

            var JsonString = JsonSerializer.Serialize(agregar);
            File.WriteAllText(ruta, JsonString, new UTF8Encoding(true));
        }
    } 

}

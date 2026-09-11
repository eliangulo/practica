using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace practica
{
    public class Imagen
    {
        public string NombreArchivo { get; set; }
        public string URL { get; set; }

        private static HttpClient http = new HttpClient();

        public static List<Imagen> ListarImagenes()
        {
            var lista = new List<Imagen>()
            {
                new Imagen() { NombreArchivo = "Imagen1-Mapache.jpg", URL = "https://www.aaha.org/wp-content/uploads/2024/03/b5e516f1655346558958c939e85de37a-1000x682.jpg" },
                new Imagen() { NombreArchivo = "Imagen2-Leon.jpg", URL = "https://www.anipedia.net/imagenes/animal-salvaje-el-leon.jpg" },
                new Imagen() { NombreArchivo = "Imagen3-Oso.jpg", URL = "https://es.gizmodo.com/app/uploads/2025/09/explore-org-960x640.jpg" }
            };

            return lista;
        }

        private static async Task DescargarImagen(string url, string nombreArchivo)
        {
            var directorio = @"C:\itsc\practica";
            var ruta = Path.Combine(directorio, nombreArchivo);

            if (!Directory.Exists(directorio))
            {
                Directory.CreateDirectory(directorio);
            }

            var bytes = await http.GetByteArrayAsync(url);
            await File.WriteAllBytesAsync(ruta, bytes);

            Console.WriteLine($"{nombreArchivo} descargada correctamente");
        }

        public static async Task Descargar()
        {
            var imagenes = ListarImagenes();
            var descargar = new List<Task>();

            var sw = new Stopwatch();
            sw.Start();

            foreach (var imagen in imagenes)
            {
                descargar.Add(DescargarImagen(imagen.URL, imagen.NombreArchivo));
            }

            await Task.WhenAll(descargar);

            sw.Stop();
            Console.WriteLine($"Descarga total: {sw.ElapsedMilliseconds}ms");
        }
    }
}

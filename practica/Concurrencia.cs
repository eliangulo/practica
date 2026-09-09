using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace practica
{
    public class Concurrencia
    {

        public static async Task<int> CalcularEdad (int aNacimiento)
        {
            await Task.Delay(1000); 

            int edad = DateTime.Now.Year - aNacimiento;

            return edad;
        }

        public static async Task Calcular()
        {
            var edad = await CalcularEdad(2000);

            Console.WriteLine($"La edad es: {edad} años");
        }

        public static async Task ProcesoA()
        {
            await Task.Delay(1000);
            Console.WriteLine("Proceso A completado");
        }
        public static async Task ProcesoB()
        {
            await Task.Delay(1000);
            Console.WriteLine("Proceso B completado");
        }

        public static async Task ProcesoC()
        {
            await Task.Delay(1000);
            Console.WriteLine ("Proceso C completado");
        }

        public static async Task ProcesoD()
        {
            await Task.Delay(1000);
            Console.WriteLine("Proceso D completado");
        }

        public static async Task EjecutarSecuencial()
        {
            var sw = new Stopwatch();

            sw.Start();
            await ProcesoA();
            await ProcesoB();
            await ProcesoC();
            await ProcesoD();
            sw.Stop();

            Console.WriteLine($"Tiempo total: {sw.ElapsedMilliseconds} ms");
        }

        //Paralelo
        public static async Task EjecucionParalela()
        {
            var sw = new Stopwatch();
            sw.Start();

            var Lista = new List<Task>
            {
                ProcesoA(),
                ProcesoB(),
                ProcesoC(),
                ProcesoD()
            };
            await Task.WhenAll(Lista);
            sw.Stop();

            Console.WriteLine($"Tiempo total: {sw.ElapsedMilliseconds} ms");
        }

        public static async Task<int>NumerosSecuenciales(List<int> numeros)
        {
            int suma = 0;
            foreach (var numero in numeros)
            {
                await Task.Delay(500);
                suma += numero;
            }
            Console.WriteLine($"El resultado es:{suma}" );
            return suma;
         
        }

        public static async Task ProbarNumeroSecuenciales()
        {
            var numeros = new List<int> { 10, 20, 30, 40, 50, 60 };

            var sw = new Stopwatch();

            sw.Start();

           var resultado = await NumerosSecuenciales(numeros);

            sw.Stop();

            Console.WriteLine($"El tiempo: {sw.ElapsedMilliseconds} ms");

            GuardarResultadosJson(numeros, resultado, sw.ElapsedMilliseconds);

        }

        public static void GuardarResultadosJson(List<int> numeros, int total, long tiempoMs)
        {
            var resultados = new ResultadoSuma
            {
                Numeros = numeros,
                Total = total,
                TiempoMs = tiempoMs,

            };
            var rutaJson = @"C:\itsc\practica\resultadoSuma.json";

            var jsonString = JsonSerializer.Serialize(resultados);
            File.WriteAllText(rutaJson, jsonString);

        }

        //Consigna: Escribí un método async Task GuardarProductoAsync(Producto p)
        //que "simule" guardar un producto (con Task.Delay(1000)) y después lo escriba en un archivo JSON.
        //Llamalo para una lista de 5 productos usando Task.WhenAll, de forma que los 5 se "guarden" en paralelo.

        public static async Task GuardarProductoAsync(Producto p)
        {
            await Task.Delay(1000);
            Console.WriteLine($"Producto {p.Nombre} guardado");
        }
        public static async Task GuardarProductosEnParalelo()
        {
            var productos = new List<Producto>()
         {
            new Producto { Id = 1, Nombre = "Teléfonos", Precio = 100, Stock = 6 },
            new Producto { Id = 2, Nombre = "Notebooks", Precio = 200000, Stock = 20 },
            new Producto { Id = 3, Nombre = "Impresoras", Precio = 150000, Stock = 2 },
            new Producto { Id = 4, Nombre = "Relojes", Precio = 4000, Stock = 8 },
            new Producto { Id = 5, Nombre = "Auriculares", Precio = 15000, Stock = 30 },
         };

            var sw = new Stopwatch();
            sw.Start();

            // guardar cada producto "en paralelo" (simulado)
            var listaTareas = new List<Task>();
            foreach (var producto in productos)
            {
                listaTareas.Add(GuardarProductoAsync(producto));
            }
            await Task.WhenAll(listaTareas);

            sw.Stop();
            Console.WriteLine($"Tiempo total: {sw.ElapsedMilliseconds} ms");

            //  guardar la lista completa en un JSON (una sola vez, al final)
            var rutaJson = @"C:\itsc\practica\productosGuardados.json";
            var jsonString = JsonSerializer.Serialize(productos);
            File.WriteAllText(rutaJson, jsonString);
        }
    } 
}

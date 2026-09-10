using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace practica
{
    public class TareasConcurrencias
    {
        public static async Task Tarea1()
        {
            await Task.Delay(5000);
            Console.WriteLine("Tarea 1: Completada ...");
        }
        public static async Task Tarea2()
        {
            await Task.Delay(200);
            Console.WriteLine("Tarea 2: Completada ...");
        }
        public static async Task Tarea3()
        {
            await Task.Delay(1500);
            Console.WriteLine("Tarea 3: Completada ...");
        }
        public static async Task Tarea4()
        {
            await Task.Delay(1999);
            Console.WriteLine("Tarea 4: Completada ...");
        }

        public static async Task ProcesoSecuencial()
        {
            var sw = new Stopwatch();

            sw.Start();

            await Tarea1();
            await Tarea2();
            await Tarea3();
            await Tarea4();

            sw.Stop();
            Console.WriteLine($"El Proceso duro:{sw.ElapsedMilliseconds}ms");
        }
         
        public static async Task ProcesoParalelo()
        {
            var sw = new Stopwatch();
            sw.Start();

            var lista = new List<Task>
            {
                Tarea1(),
                Tarea2(),
                Tarea3(),
                Tarea4()
            };
            await Task.WhenAll(lista);
            sw.Stop();

            Console.WriteLine($"El proceso duro: {sw.ElapsedMilliseconds}ms");
        }

        //parallelFor
        public static void ProcesoConParallelFor()
        {
            var sw = new Stopwatch();
            sw.Start();

            Parallel.For(0, 20, i =>
            {
                Thread.Sleep(200); // simula trabajo pesado
                Console.WriteLine($"Procesando item {i} en hilo {Thread.CurrentThread.ManagedThreadId}");
            });

            sw.Stop();
            Console.WriteLine($"Parallel.For duró: {sw.ElapsedMilliseconds}ms");
        }

        public static void ProcesoConForNormal()
        {
            var sw = new Stopwatch();
            sw.Start();

            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(200); // simula trabajo pesado
                Console.WriteLine($"Procesando item {i}");
            }

            sw.Stop();
            Console.WriteLine($"For normal duró: {sw.ElapsedMilliseconds}ms");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace practica
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int Precio { get; set; }
        public int Stock { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Stock
    {
        public int ProductoID { get; set; }

        public int SucursalID { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }
}

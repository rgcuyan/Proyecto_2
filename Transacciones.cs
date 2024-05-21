namespace Proyecto_2
{
    class Transacciones
    {
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public string? tipoOperacion { get; set; } // "Débito" o "Crédito"

        int i = 0;
        List<string[]> transacciones = new List<string[]>();

        public Transacciones() { }

        public void IngresoDatos(DateTime fecha, string monto, string tipoOperacion)
        {
            transacciones.Add(new string[] { i.ToString(), fecha.ToString(), monto, tipoOperacion });
            i++;
        }

        public void MostrarTransacciones()
        {
            Console.WriteLine("\n*------------LISTA TRANSACCIONES------------*");
            Console.WriteLine("{0,-5} {1,-25} {2,-15} {3,-15}", "ID", "FECHA", "MONTO", "DEBITO/CREDITO");

            foreach (var transaccion in transacciones)
            {
                Console.WriteLine("{0,-5} {1,-25} {2,-15:C} {3,-15}", transaccion[0], transaccion[1], "Q" + transaccion[2], transaccion[3]);
            }
        }
    }
}
namespace Proyecto_2
{
    public class CuentaBancaria
    {
        int idCueta { get; set; }
        string tipoCuenta { get; set; } = "";
        string nombre { get; set; } = "";
        string dpi { get; set; } = "";
        string direccion { get; set; } = "";
        int telefono { get; set; }
        decimal saldo { get; set; }

        int i = 0;
        static List<string[]> cuentas = new List<string[]>();

        public CuentaBancaria() { }

        public void IngresoDatos(string tipoCuenta, string nombre, string dpi, string direccion, int telefono, decimal saldo)
        {
            cuentas.Add(new string[] { i.ToString(), tipoCuenta, nombre, dpi, direccion, telefono.ToString(), saldo.ToString() });
            i++;
        }

        public void ShowCuentaBancaria()
        {
            System.Console.WriteLine($"\n*---------------INFORMACION DE CUENTAS--------------*");
            int contador = 1;
            foreach (var cuenta in cuentas)
            {
                System.Console.WriteLine($"\nCUENTA {contador}");
                Console.WriteLine($"{"ID Cuenta:",-20} {cuenta[0]}");
                Console.WriteLine($"{"Nombre:",-20} {cuenta[2]}");
                Console.WriteLine($"{"Tipo de la cuenta:",-20} {cuenta[1]}");
                Console.WriteLine($"{"DPI:",-20} {cuenta[3]}");
                Console.WriteLine($"{"Dirección:",-20} {cuenta[4]}");
                Console.WriteLine($"{"Teléfono:",-20} {cuenta[5]}");
                Console.WriteLine($"{"Saldo:",-20} Q{cuenta[6]}");
                contador++;
            }
        }

        public int BuscarCuenta(int id)
        {
            foreach (var cuenta in cuentas)
            {
                if (cuenta[0] == id.ToString())
                {
                    return 1;
                }
            }
            return 0;
        }

        public void EditarCuenta(int id, string nombre, string dpi, string direccion, int telefono)
        {
            var cuenta = cuentas[id];

            // Actualizar los valores de la cuenta
            cuenta[2] = nombre;
            cuenta[3] = dpi;
            cuenta[4] = direccion;
            cuenta[5] = telefono.ToString();

            Console.WriteLine($"Cuenta numero {id + 1} actualizada:");
            Console.WriteLine($"Tipo de la cuenta: {cuenta[1]}");
            Console.WriteLine($"Nombre: {cuenta[2]}");
            Console.WriteLine($"DPI: {cuenta[3]}");
            Console.WriteLine($"Dirección: {cuenta[4]}");
            Console.WriteLine($"Teléfono: {cuenta[5]}");
        }

        public void EliminarCuenta(int id)
        {
            if (id >= 0 && id < cuentas.Count)
            {
                cuentas.RemoveAt(id);

                // Reasignar IDs para mantener secuencia sin saltos
                for (int j = 0; j < cuentas.Count; j++)
                {
                    cuentas[j][0] = j.ToString();
                }

                i = cuentas.Count; // Ajustar el valor de 'i' para reflejar el número actual de cuentas

                Console.WriteLine($"Cuenta en índice {id + 1} eliminada exitosamente.");
            }
            else
            {
                Console.WriteLine("Índice fuera de rango");
            }
        }

        public decimal ObtenerSaldo(int indice)
        {
            if (indice >= 0 && indice < cuentas.Count)
            {
                return decimal.Parse(cuentas[indice][6]); // Convertir la cadena de saldo a decimal
            }
            else
            {
                throw new ArgumentOutOfRangeException("El índice está fuera de rango");
            }
        }

        public void ActualizarSaldo(int indice, string nuevoSaldo)
        {
            if (indice >= 0 && indice < cuentas.Count)
            {
                cuentas[indice][6] = nuevoSaldo; // Actualizar el saldo en la lista
            }
            else
            {
                throw new ArgumentOutOfRangeException("El índice está fuera de rango");
            }
        }
    }
}
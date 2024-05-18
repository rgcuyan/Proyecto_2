namespace Proyecto_2
{
    public class CuentaBancaria
    {
        int idCueta { get; set; }
        string tipoCuenta { get; set; }
        string nombre { get; set; }
        string dpi { get; set; }
        string direccion { get; set; }
        int telefono { get; set; }
        decimal saldo { get; set; }

        int i = 0;
        List<string[]> cuentas = new List<string[]>();
        public CuentaBancaria() { }

        public CuentaBancaria(int idCueta, string tipoCuenta, string nombre, string dpi, string direccion, int telefono, decimal saldo)
        {
            this.idCueta = idCueta;
            this.tipoCuenta = tipoCuenta;
            this.nombre = nombre;
            this.dpi = dpi;
            this.direccion = direccion;
            this.telefono = telefono;
            this.saldo = saldo;
        }

        public void IngresoDatos(string tipoCuenta, string nombre, string dpi, string direccion, int telefono, decimal saldo)
        {
            cuentas.Add(new string[] { i.ToString(), tipoCuenta, nombre, dpi, direccion, telefono.ToString(), saldo.ToString() });
            i++;
        }

        public void ShowCuentaBancaria()
        {
            foreach (var cuenta in cuentas)
            {
                Console.WriteLine($"ID Cuenta: {cuenta[0]}");
                Console.WriteLine($"Nombre: {cuenta[2]}");
                Console.WriteLine($"Tipo de la cuenta: {cuenta[1]}");
                Console.WriteLine($"DPI: {cuenta[3]}");
                Console.WriteLine($"Direccion: {cuenta[4]}");
                Console.WriteLine($"Telefono: {cuenta[5]}");
                Console.WriteLine($"Saldo: {cuenta[6]}");
            }
        }

        public string BuscarCuenta(string id)
        {
            foreach (var cuenta in cuentas)
            {
                if (cuenta[0] == id)
                {
                    return $"ID Cuenta: {cuenta[0]}\nNombre: {cuenta[2]}\nTipo de la cuenta: {cuenta[1]}\nDPI: {cuenta[3]}\nDireccion: {cuenta[4]}\nTelefono: {cuenta[5]}\nSaldo: {cuenta[6]}";
                }
            }
            return "Cuenta no encontrada";
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
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

        string[,] cuentas = new string[10, 7];
        int i = 0;

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
            cuentas[i, 0] = i.ToString();
            cuentas[i, 1] = tipoCuenta;
            cuentas[i, 2] = nombre;
            cuentas[i, 3] = dpi;
            cuentas[i, 4] = direccion;
            cuentas[i, 5] = telefono.ToString();
            cuentas[i, 6] = saldo.ToString();

            i++;
        }

        public void ShowCuentaBancaria()
        {
            System.Console.WriteLine($"Id: {this.idCueta}\nTipo de Cuenta: {this.tipoCuenta}\nNombre: {this.nombre}\nDPI: {this.dpi}\nDireccion: {this.direccion}\nTelefono: {this.telefono}\nSaldo: {this.saldo}");
        }
    }
}
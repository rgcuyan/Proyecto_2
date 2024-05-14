public class CuentaBancaria
{
    int idCueta { get; set; }
    string tipoCuenta { get; set; }
    string nombre { get; set; }
    string dpi { get; set; }
    string direccion { get; set; }
    int telefono { get; set; }
    decimal saldo { get; set; }

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

    public CuentaBancaria(int idCueta, string nombre, string dpi, string direccion, int telefono, decimal saldo)
    {
        this.idCueta = idCueta;
        this.nombre = nombre;
        this.dpi = dpi;
        this.direccion = direccion;
        this.telefono = telefono;
        this.saldo = saldo;
    }

    public void showCuentaBancaria()
    {
        System.Console.WriteLine($"Id: {this.idCueta}\nTipo de Cuenta: {this.tipoCuenta}\nNombre: {this.nombre}\nDPI: {this.dpi}\nDireccion: {this.direccion}\nTelefono: {this.telefono}\n Saldo: {this.saldo}");
    }
}
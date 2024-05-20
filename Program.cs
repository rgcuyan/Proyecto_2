using System;
using System.Reflection.Metadata;
using System.Text.RegularExpressions;
using Proyecto_2;
class Program
{
    static CuentaBancaria cuenta = new CuentaBancaria();
    static Transacciones transaccion = new Transacciones();
    public static void Main(string[] args)
    {
        Login();
        menu();
    }

    public static void menu()
    {
        bool validacion = true;

        do
        {
            System.Console.WriteLine("");
            System.Console.WriteLine("\n----------------MENU-----------------");
            System.Console.WriteLine("1. Ver información de la cuenta\n2. Compra de producto financiero\n3. Venta de producto financiero\n4. Abonar a cuenta\n5. Simular paso del tiempo\n6. Operaciones de cuenta\n7. Transferencia\n8. Pago de Servicios\n9. Informe de transacciones\n10. Salir");
            string? opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    {
                        cuenta.ShowCuentaBancaria();
                        break;
                    }
                case "2":
                    {
                        CompraProductoFinanciero();
                        break;
                    }
                case "3":
                    {
                        VentaProductoFinanciero();
                        break;
                    }
                case "4":
                    {
                        AbonarCuenta();
                        break;
                    }
                case "5":
                    {
                        SimularPasoTiempo();
                        break;
                    }
                case "6":
                    {
                        //creacion, edicion o eliminacion de cuentas
                        OperacionesCuentas();
                        break;
                    }
                case "7":
                    {
                        //Transferencias a otras cuentas
                        TransferenciaCuentas();
                        break;
                    }
                case "8":
                    {
                        //Pago de servicios
                        PagoServicios();
                        break;
                    }
                case "9":
                    {
                        transaccion.MostrarTransacciones();
                        break;
                    }
                case "10":
                    {
                        System.Console.WriteLine("Que tenga un lindo dia!");
                        validacion = false;
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Opcion invalida porfavor intentelo de nuevo");
                        break;
                    }
            }
        } while (validacion);
    }

    public static void PagoServicios()
    {
        System.Console.WriteLine("");
        Console.WriteLine("\n*------------PAGO DE SERVICIOS------------*");
        System.Console.WriteLine("Ingrese el servicio a pagar");
        System.Console.WriteLine("\n1.Agua\n2. Luz\n3. Telefono");
        char opcion = Console.ReadKey().KeyChar;

        switch (opcion)
        {
            case '1':
            case '2':
            case '3':
                {
                    System.Console.WriteLine("\nIngrese monto a pagar");
                    decimal monto = decimal.Parse(Console.ReadLine());
                    decimal saldo = cuenta.ObtenerSaldo(0);
                    if (saldo > monto)
                    {
                        saldo = saldo - monto;
                        cuenta.ActualizarSaldo(0, saldo.ToString("N2"));
                        
                        transaccion.IngresoDatos(DateTime.Now, monto.ToString("N2"), "Debito");

                        System.Console.WriteLine("Servicio pagado!");
                    }
                    else
                    {
                        System.Console.WriteLine("Saldo Insuficiente!");
                    }
                    break;
                }
            default:
                {
                    Console.WriteLine("\nLa opcion que usted realizo no es valida");
                    break;
                }
        }

    }

    public static void TransferenciaCuentas()
    {
        System.Console.WriteLine("");
        Console.WriteLine("\n*------------TRANSFERIR A OTRA CUENTA------------*");
        System.Console.WriteLine("Porfavor ingresa el id de la cuenta a transferir");
        int id = Int32.Parse(Console.ReadLine());

        int cuentaBuscada = cuenta.BuscarCuenta(id);
        if (cuentaBuscada == 1 && id != 0)
        {
            System.Console.WriteLine("\nIngrese monto a transferir");
            decimal monto = decimal.Parse(Console.ReadLine());
            if (monto >= 200 && monto <= 2000)
            {

                decimal saldo = cuenta.ObtenerSaldo(id);
                saldo = saldo + monto;
                cuenta.ActualizarSaldo(id, saldo.ToString("N2"));

                decimal saldoPrincipal = cuenta.ObtenerSaldo(0);
                saldoPrincipal = saldoPrincipal - monto;
                cuenta.ActualizarSaldo(0, saldoPrincipal.ToString("N2"));

                transaccion.IngresoDatos(DateTime.Now, monto.ToString("N2"), "Debito");

                System.Console.WriteLine("Transferencia Exitosa!");
            }
            else
            {
                System.Console.WriteLine("Solo se puede transferir en un rango de Q200 a Q2,000");
            }
        }
        else
        {
            System.Console.WriteLine("La cuenta que ingreso no existe!");
        }
    }

    public static void OperacionesCuentas()
    {
        bool validacion = true;

        do
        {
            Console.WriteLine("\n*------------OPERACION DE CUENTA-------------*");
            System.Console.WriteLine("1. Crear nueva cuenta\n2. Editar cuenta\n3. Eliminar cuenta\n4. Salir");
            char opcion = Console.ReadKey().KeyChar;

            switch (opcion)
            {
                case '1':
                    {
                        IngresoDatos();
                        break;
                    }
                case '2':
                    {
                        EditarCuenta();
                        break;
                    }
                case '3':
                    {
                        EliminarCuenta();
                        break;
                    }
                case '4':
                    {
                        validacion = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("\nLa opcion que usted realizo no es valida");
                        break;
                    }
            }
        } while (validacion);
    }

    private static void EliminarCuenta()
    {
        System.Console.WriteLine("");
        Console.WriteLine("\n*------------EDITAR CUENTA------------*");
        System.Console.WriteLine("Porfavor ingresa el id de la cuenta a editar");
        int id = Int32.Parse(Console.ReadLine());
        cuenta.EliminarCuenta(id);
    }

    public static void EditarCuenta()
    {
        System.Console.WriteLine("");
        Console.WriteLine("\n*------------EDITAR CUENTA------------*");
        System.Console.WriteLine("Porfavor ingresa el id de la cuenta a editar");
        int id = Int32.Parse(Console.ReadLine());

        int cuentaBuscada = cuenta.BuscarCuenta(id);
        System.Console.WriteLine($"\n{cuentaBuscada}");

        if (cuentaBuscada == 1)
        {
            System.Console.WriteLine("\nIngrese su nombre");
            string? nombre = Console.ReadLine();

            string dpi = "";
            for (int i = 1; i == 1;)
            {
                System.Console.WriteLine("\nIngrese su DPI");
                dpi = Console.ReadLine();
                if (dpi.Length == 5)
                {
                    i = 0;
                }
                else
                {
                    System.Console.WriteLine("\nDPI invalido, intentelo de nuevo!");
                    i = 1;
                }
            }

            System.Console.WriteLine("\nIngrese su direccion");
            string? direccion = Console.ReadLine();

            System.Console.WriteLine("\nIngrese su numero de telefono");
            int telefono = Int32.Parse(Console.ReadLine());

            cuenta.EditarCuenta(id, nombre, dpi, direccion, telefono);
        }
        else
        {
            System.Console.WriteLine("La cuenta que ingreso no existe!");
        }
    }

    public static void SimularPasoTiempo()
    {
        decimal saldoActual = cuenta.ObtenerSaldo(0);

        //Solicitamos el periodo de capitalizacion (Una vez al mes o dos veces al mes)
        Console.WriteLine("\n*------------PERIODO DE CAPITALIZACION------------*");
        Console.WriteLine("Ingrese el periodo de capitalizacion");
        Console.WriteLine("1. Una vez al mes\n2. Dos veces al mes\n3. Salir");
        char opcion3 = Console.ReadKey().KeyChar;

        //Validamos la accion que desea realizar el usuario 
        switch (opcion3)
        {
            case '1':
                {

                    //Realizamos la accion de capitalizacion (Una vez al mes)
                    Console.WriteLine("\n-----------------------------------------");
                    decimal nuevoSaldo = saldoActual + (saldoActual * 0.02m);
                    decimal monto = saldoActual * 0.02m;

                    transaccion.IngresoDatos(DateTime.Now, monto.ToString("N2"), "Credito");

                    Console.WriteLine($"Su saldo actual por el interes de 1 mes es de: Q{nuevoSaldo}");
                    break;
                }
            case '2':
                {
                    //Realizamos la accion de capitalizacion (Dos veces al mes)
                    Console.WriteLine("\n-----------------------------------------");
                    decimal nuevoSaldo = saldoActual + (saldoActual * 2);
                    decimal monto = saldoActual * 2;

                    transaccion.IngresoDatos(DateTime.Now, monto.ToString("N2"), "Credito");

                    Console.WriteLine($"Su saldo actual por el interes de 2 meses es de: Q{nuevoSaldo}");
                    break;
                }
            case '3':
                {
                    break;
                }
            default:
                {
                    //Si no se cumplen los criterios de la accion que quiere realizar el usuario se muestran mensajes
                    Console.WriteLine("\n-----------------------------------------");
                    Console.WriteLine("La opcion que usted realizo no es valida");
                    break;
                }
        }
    }

    public static void AbonarCuenta()
    {

        decimal saldoActual = cuenta.ObtenerSaldo(0);

        for (int i = 0; i <= 1;)
        {

            //Solicitamos si quiere abonar a una cuenta
            Console.WriteLine("");
            Console.WriteLine("\n*------------ABONAR CUENTA-------------*");
            Console.WriteLine("¿Desea abonar?");
            Console.WriteLine("1.Si\n2.No");
            char opcion3 = Console.ReadKey().KeyChar;


            //Validamos la accion que quiere realizar el usuario
            switch (opcion3)
            {
                case '1':
                    {

                        //Validamos que el saldo sea mayor a Q500
                        if (saldoActual > 500)
                        {

                            //Abonamos a la cuenta del usuario
                            decimal nuevoSaldo = saldoActual * 2;
                            decimal monto = saldoActual;

                            cuenta.ActualizarSaldo(0, nuevoSaldo.ToString("N2"));
                            transaccion.IngresoDatos(DateTime.Now, monto.ToString("N2"), "Credito");
                            Console.WriteLine("");
                            Console.WriteLine($"Su saldo actual es de Q{nuevoSaldo}");
                            i++;


                        }
                        else
                        {

                            //Si no se cumplen los criterios del saldo se muestran mensajes
                            Console.WriteLine("\nNo puede realizar esta accion debido a que su saldo es menor a Q500");
                            Console.WriteLine("\nPresiona Enter para continuar.");

                        }
                        break;
                    }
                case '2':
                    {
                        //Se finaliza la accion de Abono
                        i = 2;
                        break;
                    }
                default:
                    {
                        //Si no se cumplen los criterios de la accion que quiere realizar el usuario se muestran mensajes
                        Console.WriteLine("\nLa opcion que usted realizo no es valida");
                        Console.WriteLine("\nPresiona Enter para continuar.");
                        break;
                    }
            }
        }
    }

    public static void VentaProductoFinanciero()
    {
        Console.WriteLine("\n*------------VENTA DE PRODUCTO FINANCIERO-------------*");
        Console.WriteLine("Usted realizo una compra de un producto financiero!");

        decimal saldoActual = cuenta.ObtenerSaldo(0);

        decimal nuevoSaldo = saldoActual + (saldoActual * 0.11m);
        decimal monto = saldoActual * 0.10m;

        // Actualizar el saldo en la cuenta
        cuenta.ActualizarSaldo(0, nuevoSaldo.ToString("N2"));

        // Mostrar el saldo actualizado
        Console.WriteLine($"El nuevo saldo es: Q{nuevoSaldo.ToString("N2")}");

        transaccion.IngresoDatos(DateTime.Now, monto.ToString("N2"), "Credito");

        Console.ReadKey();
    }

    public static void CompraProductoFinanciero()
    {
        Console.WriteLine("\n*--------------COMPRA DE PRODUCTO FINANCIERO------------*");
        Console.WriteLine("Usted realizo una compra de un producto financiero!");

        decimal saldoActual = cuenta.ObtenerSaldo(0);

        decimal nuevoSaldo = saldoActual - (saldoActual * 0.10m);

        decimal monto = saldoActual * 0.10m;


        // Actualizar el saldo en la cuenta
        cuenta.ActualizarSaldo(0, nuevoSaldo.ToString("N2"));

        // Mostrar el saldo actualizado
        Console.WriteLine($"El nuevo saldo es: Q{nuevoSaldo.ToString("N2")}");

        transaccion.IngresoDatos(DateTime.Now, monto.ToString("N2"), "Debito");

        Console.ReadKey();
    }

    public static void Login()
    {
        string user = "a";
        string password = "1";
        for (int i = 0; i == 0;)
        {
            Console.WriteLine("\n----------------------------");
            Console.WriteLine("Ingrese su usuario: ");
            string? userlogin = Console.ReadLine();

            Console.WriteLine("Ingrese su contraseña: ");
            string? passwordLogin = Console.ReadLine();
            if (userlogin == user && passwordLogin == password)
            {
                Console.WriteLine("\n-------------------------");
                Console.WriteLine("INICIO DE SESION EXITOSO!");
                Console.WriteLine("-------------------------");
                Console.ReadKey();
                IngresoDatos();
                i = 1;
            }
            else
            {
                Console.WriteLine("El usuario o contraseña es incorrecta, Porfavor intentelo de nuevo.");
                Console.ReadKey();
                i = 0;
            }
        }
    }
    public static bool EsAlfabetico(string input)
    {
        // Expresión regular para verificar que la cadena solo contenga caracteres alfabéticos
        string patron = @"^[a-zA-Z]+$";
        return Regex.IsMatch(input, patron);
    }
    public static void IngresoDatos()
    {
        Console.WriteLine("\n---------------------------------------------");
        System.Console.WriteLine("Porfavor introduzca la siguiente informacion.");

        System.Console.WriteLine("\nIngrese su nombre completo");
        string? nombre = Console.ReadLine();

        string tipoCuenta = "";
        for (string i = "0"; i == "0";)
        {
            System.Console.WriteLine("\nIngrese su tipo de cuenta:\na. Ahorro\nb. Monetaria");
            string? opcion = Console.ReadLine();
            tipoCuenta = tipoCuentaValidation(opcion);
            i = tipoCuenta;
        }

        string dpi = "";
        for (int i = 1; i == 1;)
        {
            System.Console.WriteLine("\nIngrese su DPI");
            dpi = Console.ReadLine();
            if (dpi.Length == 5)
            {
                i = 0;
            }
            else
            {
                System.Console.WriteLine("\nDPI invalido, intentelo de nuevo!");
                i = 1;
            }
        }

        System.Console.WriteLine("\nIngrese su direccion");
        string? direccion = Console.ReadLine();

        System.Console.WriteLine("\nIngrese su numero de telefono");
        int telefono = Int32.Parse(Console.ReadLine());


        cuenta.IngresoDatos(tipoCuenta, nombre, dpi, direccion, telefono, 2500.00m);
    }

    public static string tipoCuentaValidation(string opcion)
    {
        string cuenta = "";

        if (opcion == "a")
        {
            cuenta = "Ahorro";
        }
        else if (opcion == "b")
        {
            cuenta = "Monetaria";
        }
        else
        {
            System.Console.WriteLine("Opcion Inalida!. Porfavor intentelo de nuevo");
            cuenta = "0";
        }
        return cuenta;
    }
}
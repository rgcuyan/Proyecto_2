using System;
    class Program
    {

        public static void Main(string[] args)
        {
            //Login();
            menu();
        }

        public static void menu()
        {
            System.Console.WriteLine("\n----------------MENU-----------------");
            System.Console.WriteLine("\na. Ver información de la cuenta\nb. Compra de producto financiero\nc. Venta de producto financiero\nd. Abonar a cuenta\ne. Simular paso del tiempo\ne. ");
            string opcion = Console.ReadLine();
            System.Console.WriteLine(opcion);
            switch (switch_on)
            {
                
                default:
            }
        }

        public static void Login()
        {
            string user = "a";
            string password = "1";
            for (int i = 0; i == 0;)
            {
                Console.WriteLine("\n----------------------------");
                Console.WriteLine("Ingrese su usuario: ");
                string userlogin = Console.ReadLine();

                Console.WriteLine("Ingrese su contraseña: ");
                string passwordLogin = Console.ReadLine();
                if (userlogin == user && passwordLogin == password)
                {
                    Console.WriteLine("\n-------------------------");
                    Console.WriteLine("INICIO DE SESION EXITOSO!");
                    Console.WriteLine("-------------------------");
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


        public static void IngresoDatos()
        {
            Console.WriteLine("\n---------------------------------------------");
            System.Console.WriteLine("Porfavor introduzca la siguiente informacion.");

            System.Console.WriteLine("\nIngrese su nombre completo");
            string nombre = Console.ReadLine();

            string tipoCuenta = "";
            for (string i = "0"; i == "0";)
            {
                System.Console.WriteLine("\nIngrese su tipo de cuenta:\na. Ahorro\nb. Monetaria");
                string opcion = Console.ReadLine();
                tipoCuenta = tipoCuentaValidation(opcion);
                i = tipoCuenta;
            }

            string dpi = "";
            for (int i = 1; i == 1;)
            {
                System.Console.WriteLine("\nIngrese su DPI");
                dpi = Console.ReadLine();
                if (dpi.Length == 13)
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
            string direccion = Console.ReadLine();

            System.Console.WriteLine("\nIngrese su numero de telefono");
            int telefono = Int32.Parse(Console.ReadLine());


<<<<<<< HEAD
            CuentaBancaria cuenta = new CuentaBancaria(1, tipoCuenta, nombre, dpi, direccion, telefono, 2500.00m);
=======
            CuentaBancaria cuenta = new CuentaBancaria(1, tipoCuenta, nombre, dpi, direccion, telefono, 2500.00m);   

            cuenta.showCuentaBancaria();

>>>>>>> 9b3705efd6d3c6cf115c036bb4dbdca026159f3d
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

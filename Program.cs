using System;

namespace Proyecto_2
{
    class Program
    {



        public static void Main(string[] args)
        {
            Login();
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
            Console.WriteLine("\n----------------------------");
            System.Console.WriteLine("Porfavor introduzca la siguiente informacion.");
            System.Console.WriteLine("Ingrese su nombre completo");
            string nombre = Console.ReadLine();

            string cuenta = "";
            bool validacion = false;

            do
            {
                System.Console.WriteLine("Ingrese su tipo de cuenta:\na. Ahorro\nb. Monetaria");
                string opcion = Console.ReadLine();

                if(opcion == "a"){
                    cuenta = "Ahorro";
                }else if (opcion == "b")
                {
                    cuenta = "Monetaria";
                } else
                {
                    System.Console.WriteLine("Opcion Inalida!. Porfavor intentelo de nuevo");
                    validacion = true;
                }
            } while (validacion);

            System.Console.WriteLine("Ingrese su ");
            //CuentaBancaria cuenta = new CuentaBancaria(1, nombre);
        }
    }
}
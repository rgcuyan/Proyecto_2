using System;

namespace Proyecto_2
{
    class Program
    {

        static string user = "a";
        static int password = 1;


        public static void Main(string[] args)
        {
            Login();
        }

        public static void Login()
        {
            for (int i = 0; i == 0;)
            {
                Console.WriteLine("Ingrese su usuario: ");
                string userlogin = Console.ReadLine();
                try
                {
                    Console.WriteLine("Ingrese su contraseña: ");
                    int passwordLogin = Int32.Parse(Console.ReadLine());
                    if (userlogin == user && passwordLogin == password)
                    {
                        Console.WriteLine("Ingrese su nombre completo:");
                        string nombreP = Console.ReadLine();
                        Console.WriteLine($"\nBienvenido {nombreP}");
                        i = 1;
                    }
                }
                catch (System.FormatException e)
                {
                    Console.WriteLine("El usuario o contraseña es incorrecta.");
                    Console.ReadKey();
                    i = 0;
                }
            }
        }

        
    }
}
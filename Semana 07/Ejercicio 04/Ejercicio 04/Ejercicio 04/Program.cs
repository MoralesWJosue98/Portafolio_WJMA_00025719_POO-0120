using System;


namespace Ejercicio_04
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            bool continuar = true;
            do{
                Console.Write(menu());
                int opcion = Convert.ToInt32(Console.ReadLine());
            
                switch(opcion){
                    case 1:

                        try
                        {
                            Banco.registrarTarjeta();
                        }
                        catch (WrongRegisterException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        
                        break;
                    
                    case 2: 
                        Banco.consultarTarjetas(); 
                        break;
                    case 3:

                        try
                        {
                            ConsolaJuegos.comprarJuego();
                        }
                        catch (ExistingGameException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        break;
                    case 4: 
                        ConsolaJuegos.jugar(); 
                        break;
                    case 5: 
                        continuar = false; 
                        break;
                    default: 
                        Console.WriteLine("Opcion errónea!");
                        break;
                }
            }while(continuar);
            Console.WriteLine("\nTenga un buen día!");
        }
        static string menu(){
            return "\nBienvenido:\n" +
                   "1) Registrar tarjeta (banco).\n" +
                   "2) Consultar tarjetas (banco).\n" +
                   "3) Comprar videojuego (consola).\n" +
                   "4) Jugar videojuego (consola).\n" +
                   "5) Salir.\n" +
                   "Opción elegida: ";
        }
    }
}
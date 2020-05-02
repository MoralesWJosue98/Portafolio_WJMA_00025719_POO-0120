using System;
using System.Diagnostics;

namespace Ejercicio_04
{
    public static class Banco
    {
        
        public static void registrarTarjeta()
        {
            try
            {
                Console.Write("Número de tarjeta: ");
                string numero = Console.ReadLine();

                if (GestorArchivos.Buscar("Tarjetas.txt", numero))
                {
                    throw new WrongRegisterException("Numero de tarjeta ya registrado!");
                }

                GestorArchivos.Anexar("Tarjetas.txt", numero);

                Console.WriteLine("Tarjeta creada exitosamente!");
            }
            catch (WrongRegisterException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
        
        public static void consultarTarjetas(){
            Console.WriteLine(GestorArchivos.Leer("Tarjetas.txt"));
        }
        
        
        public static bool realizarCompras(string tarjeta){
            return GestorArchivos.Buscar("Tarjetas.txt", tarjeta);
        }
        
        

    }
    
}
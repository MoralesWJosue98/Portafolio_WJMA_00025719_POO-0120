using System;

namespace Ejercicio_04
{
    public class WrongRegisterException : Exception
    {
        public WrongRegisterException(string message) : base(message)
        {
        }
    }
}
using System;

namespace Ejercicio_04
{
    public class ExistingGameException : Exception
    {
        public ExistingGameException(string message) : base(message)
        {
        }
    }
}
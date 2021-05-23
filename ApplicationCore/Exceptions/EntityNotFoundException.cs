using System;

namespace Airlines.ApplicationCore.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException() : base()
        {
        }
        
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}
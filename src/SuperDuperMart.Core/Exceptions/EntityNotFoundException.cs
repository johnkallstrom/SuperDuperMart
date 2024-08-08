using System.Runtime.Serialization;

namespace SuperDuperMart.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string? message) : base(message)
        {
        }

        public EntityNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public EntityNotFoundException(string entity, int id) : base($"{entity} with identifier {id} could not be found")
        {
        }
    }
}

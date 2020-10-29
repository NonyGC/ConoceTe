using System;
using System.Collections.Generic;
using System.Text;

namespace ConoceTe.Citas.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class CitasDomainException : Exception
    {
        public CitasDomainException()
        { }

        public CitasDomainException(string message)
            : base(message)
        { }

        public CitasDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}

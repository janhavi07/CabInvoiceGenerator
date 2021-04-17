using System;
using System.Runtime.Serialization;

namespace CabInvoiceTesting
{
    [Serializable]
    public class CustomException : Exception
    {
        ExceptionType type;
        public enum ExceptionType
        {
            NULLVALUE
        }

        public CustomException(string message, ExceptionType type) : base(message)
        {
            this.type = type;
        }

    }
}
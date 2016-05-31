using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentXUnit
{
    public class XAssertionFailedException : Exception
    {
        public XAssertionFailedException()
        {
        }

        public XAssertionFailedException(string message)
            : base(message)
        {
        }

        public XAssertionFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected XAssertionFailedException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
            : base(info, context)
        {
        }
    }
}
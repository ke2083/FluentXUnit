using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Runtime.Serialization;

namespace FluentXUnit
{

    /// <summary>
    /// Provides a fluent Assert syntax for the xUnit test framework.
    /// </summary>
    /// <seealso cref="Xunit.Assert" />
    public class XAssert : Assert
    {
        private readonly dynamic expected;

        /// <summary>
        /// Initializes a new instance of the <see cref="XAssert"/> class.
        /// </summary>
        private XAssert(dynamic expected)
        {
            this.expected = expected;
        }

        /// <summary>
        /// Asserts that the expected value meets with the specified criteria.
        /// </summary>
        /// <typeparam name="T">The type of the expected value.</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="operation">The operation to evaluate the expected value for correctness.</param>
        /// <param name="message">The message to display if the assertion fails.</param>
        /// <exception cref="Exception">Thrown if the assertion is not true.</exception>
        public static XAssert That<T>
        (T expected, Func<T, bool> operation, string message = "Test failed")
        {
            if (!operation(expected))
                throw new XAssertionFailedException(message);

            return new XAssert(expected);
        }

        public XAssert And<T>(Func<T, bool> operation, string message = "Test failed")
        {
            if (!operation(expected))
                throw new XAssertionFailedException(message);

            return this;
        }
    }
}

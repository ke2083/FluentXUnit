using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FluentXUnit
{
    /// <summary>
    /// Provides a fluent Assert syntax for the xUnit test framework.
    /// </summary>
    /// <seealso cref="Xunit.Assert" />
    public class XAssert : Assert
    {
        /// <summary>
        /// Asserts that the expected value meets with the specified criteria.
        /// </summary>
        /// <typeparam name="T">The type of the expected value.</typeparam>
        /// <param name="expected">The expected value.</param>
        /// <param name="operation">The operation to evaluate the expected value for correctness.</param>
        /// <param name="message">The message to display if the assertion fails.</param>
        /// <exception cref="Exception">Thrown if the assertion is not true.</exception>
        public static void That<T>
            (T expected, Func<T, bool> operation, string message = "Test failed")
        {
            if (!operation(expected))
                throw new Exception(message);
        }
    }
}

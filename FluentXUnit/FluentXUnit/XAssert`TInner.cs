using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentXUnit
{
    public class XAssert<TInner>
    {
        private readonly TInner Inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="XAssert"/> class.
        /// </summary>
        internal XAssert(TInner inner)
        {
            Inner = inner;
        }

        public XAssert<TInner> And(Func<TInner, bool> operation, string message = "Test failed")
        {
            if (!operation(Inner))
                throw new XAssertionFailedException(message);

            return this;
        }

        public XAssert<TInner> And<S>(Func<TInner, S> transform, Func<S, bool> operation, string message = "Test failed")
        {
            if (!operation(transform(Inner)))
                throw new XAssertionFailedException(message);

            return this;
        }
    }
}

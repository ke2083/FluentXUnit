using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentXUnit
{
    public class XAssertInner<TInner>
    {
        private readonly TInner Inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="XAssert"/> class.
        /// </summary>
        internal XAssertInner(TInner inner)
        {
            Inner = inner;
        }

        public XAssertInner<TInner> And(Func<TInner, XAssertionOperationResult> operation, string message = "Test failed")
        {
            if (!operation(Inner).Result)
                throw new XAssertionFailedException(message);

            return this;
        }

        public XAssertInner<TInner> And<S>(Func<TInner, S> transform, Func<S, XAssertionOperationResult> operation, string message = "Test failed")
        {
            if (!operation(transform(Inner)).Result)
                throw new XAssertionFailedException(message);

            return this;
        }
    }
}

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
            var result = operation(Inner);
            if (!result.Result)
                throw new XAssertionFailedException(string.Format("{0} - {1}", message, result.Detail));

            return this;
        }

        public XAssertInner<TInner> And<S>(Func<TInner, S> transform, Func<S, XAssertionOperationResult> operation, string message = "Test failed")
        {
            var result = operation(transform(Inner));
            if (!result.Result)
                throw new XAssertionFailedException(string.Format("{0} - {1}", message, result.Detail));

            return this;
        }
    }
}

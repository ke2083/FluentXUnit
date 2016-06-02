using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluentXUnit
{
    public struct XAssertionOperationResult
    {
        private string detail;
        private bool result;

        public XAssertionOperationResult(bool result, string detail)
        {
            this.result = result;
            this.detail = detail;
        }

        public bool Result
        {
            get
            {
                return result;
            }
            internal set
            {
                result = value;
            }
        }

        public string Detail
        {
            get
            {
                return detail;
            }
            internal set
            {
                detail = value;
            }
        }
    }
}

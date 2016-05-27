using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentXUnit
{
    public static class Is
    {
        public static Func<T, bool> EqualTo<T>(T actual)
        {
            return (expected) => expected.Equals(actual);
        }

        public static Func<T, bool> LessThan<T>(T actual) where T : struct
        {
            return (expected) => GreaterThan(expected)(actual) == true;
        }

        public static Func<T, bool> GreaterThan<T>(T actual) where T : struct
        {
            return (expected) =>
            {
                var actualParsed = double.Parse(actual.ToString());
                var expectedParsed = double.Parse(expected.ToString());
                return expectedParsed > actualParsed;
            };
        }

        public static Func<string, bool> EmptyString()
        {
            return (expected) => string.IsNullOrEmpty(expected.ToString());
        }

        public static Func<object, bool> Null()
        {
            return (a) => a == null;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;

namespace FluentXUnit
{
    public static class IsNot
    {
        public static Func<T, bool> EqualTo<T>(T actual)
        {
            return (expected) => Is.EqualTo(actual)(expected) == false;
        }

        public static Func<T, bool> LessThan<T>(T actual) where T : struct
        {
            return (expected) => Is.LessThan(actual)(expected) == false;
        }

        public static Func<T, bool> GreaterThan<T>(T actual) where T : struct
        {
            return (expected) => Is.GreaterThan(actual)(expected) == false;
        }

        public static Func<string, bool> EmptyString()
        {
            return (expected) => Is.EmptyString()(expected) == false;
        }

        public static Func<object, bool> Null()
        {
            return (expected) => Is.Null()(expected) == false;
        }
    }
}


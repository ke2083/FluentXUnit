using System;
using System.Collections;
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

        public static Func<bool, bool> False()
        {
            return (expected) => !Is.False()(expected);
        }

        public static Func<T, bool> LessThan<T>(T actual)
            where T: struct
        {
            return (expected) => Is.LessThan(actual)(expected) == false;
        }

        public static Func<T, bool> GreaterThan<T>(T actual)
            where T: struct
        {
            return (expected) => Is.GreaterThan(actual)(expected) == false;
        }

        public static Func<string, bool> EmptyString()
        {
            return (expected) => Is.EmptyString()(expected) == false;
        }

        public static Func<string, bool> MatchFor(string actual)
        {
            return (expected) => !Is.MatchFor(actual)(expected);
        }

        public static Func<string, bool> MatchFor(System.Text.RegularExpressions.Regex pattern)
        {
            return (expected) => !Is.MatchFor(pattern)(expected);
        }

        public static Func<T, bool> Null<T>()
            where T: class
        {
            return (expected) => Is.Null<T>()(expected) == false;
        }

        public static Func<IEnumerable, bool> Empty()
        {
            return (expected) => !Is.Empty()(expected);
        }

        public static Func<IEnumerable, bool> EmptyOrNull()
        {
            return (expected) => !Is.EmptyOrNull()(expected);
        }

        public static Func<object, bool> Null()
        {
            return (expected) => !Is.Null()(expected);
        }

        public static Func<IEnumerable<T>, bool> Storing<T>(T item)
        {
            return (expected) => !Is.Storing(item)(expected);
        }

        public static Func<IEnumerable<T>, bool> Storing<T>(Func<T, bool> query)
        {
            return (expected) => !Is.Storing(query)(expected);
        }

        public static Func<bool, bool> True()
        {
            return (expected) => !Is.True()(expected);
        }

        public static Func<Action, bool> ErroringWith<T>()
            where T: Exception
        {
            return (method) => !Is.ErroringWith<T>()(method);
        }
    }
}


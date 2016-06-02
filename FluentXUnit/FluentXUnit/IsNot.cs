using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FluentXUnit
{
    public static class IsNot
    {
        private static XAssertionOperationResult Negate(XAssertionOperationResult result, string message)
        {
            result.Result = !result.Result;
            result.Detail = message;
            return result;
        }

        public static Func<T, XAssertionOperationResult> EqualTo<T>(T actual)
        {
            return (expected) =>
                Negate(Is.EqualTo(actual)(expected), string.Format("{0} is equal to {1}", expected , actual));
        }

        public static Func<bool, XAssertionOperationResult> False()
        {
            return (expected) => Negate(Is.False()(expected), string.Format("{0} is false", expected));
        }

        public static Func<T, XAssertionOperationResult> LessThan<T>(T actual)
            where T: struct
        {
            return (expected) => Negate(Is.LessThan(actual)(expected), string.Format("{0} is less than{1}", expected, actual));
        }

        public static Func<T, XAssertionOperationResult> GreaterThan<T>(T actual)
            where T: struct
        {
            return (expected) => Negate(Is.GreaterThan(actual)(expected), string.Format("{0} is greater than {1}", expected, actual));
        }

        public static Func<string, XAssertionOperationResult> EmptyString()
        {
            return (expected) => Negate(Is.EmptyString()(expected), string.Format("{0} is empty string", expected));
        }

        public static Func<string, XAssertionOperationResult> MatchFor(string actual)
        {
            return (expected) => Negate(Is.MatchFor(actual)(expected), string.Format("{0} is matched by {1}", expected, actual));
        }

        public static Func<string, XAssertionOperationResult> MatchFor(System.Text.RegularExpressions.Regex pattern)
        {
            return (expected) => Negate(Is.MatchFor(pattern)(expected), string.Format("{0} is matched by pattern {1}", expected, pattern));
        }

        public static Func<T, XAssertionOperationResult> Null<T>()
            where T: class
        {
            return (expected) => Negate(Is.Null<T>()(expected), string.Format("{0} is null", expected));
        }

        public static Func<IEnumerable, XAssertionOperationResult> Empty()
        {
            return (expected) => Negate(Is.Empty()(expected), string.Format("{0} is empty", expected));
        }

        public static Func<IEnumerable, XAssertionOperationResult> EmptyOrNull()
        {
            return (expected) => Negate(Is.EmptyOrNull()(expected), expected + " is empty or null");
        }

        public static Func<object, XAssertionOperationResult> Null()
        {
            return (expected) => Negate(Is.Null()(expected), string.Format("{0} is null", expected));
        }

        public static Func<IEnumerable<T>, XAssertionOperationResult> Storing<T>(T item)
        {
            return (expected) => Negate(Is.Storing(item)(expected), string.Format("{0} does not contain element {1}", expected, item));
        }

        public static Func<IEnumerable<T>, XAssertionOperationResult> Storing<T>(Func<T, bool> query)
        {
            return (expected) => Negate(Is.Storing(query)(expected), string.Format("{0} does not contain any elements matching query", expected));
        }

        public static Func<bool, XAssertionOperationResult> True()
        {
            return (expected) => Negate(Is.True()(expected), string.Format("{0} is not true", expected));
        }

        public static Func<Action, XAssertionOperationResult> ErroringWith<T>()
            where T: Exception
        {
            return (method) => Negate(Is.ErroringWith<T>()(method), "Method is throwing exception");
        }
    }
}


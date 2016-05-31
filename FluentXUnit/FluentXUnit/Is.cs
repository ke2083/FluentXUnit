using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FluentXUnit
{
    public static class Is
    {
        public static Func<IEnumerable<T>, bool> Storing<T>(T item)
        {
            return (expected) => expected.Contains(item);
        }

        public static Func<T, bool> EqualTo<T>(T actual)
        {
            return (expected) => expected.Equals(actual);
        }

        public static Func<T, bool> LessThan<T>(T actual)
            where T: struct
        {
            return (expected) => GreaterThan(expected)(actual) == true;
        }

        public static Func<T, bool> GreaterThan<T>(T actual)
            where T: struct
        {
            return (expected) =>
            {
                var actualParsed = double.Parse(actual.ToString());
                var expectedParsed = double.Parse(expected.ToString());
                return expectedParsed > actualParsed;
            };
        }

        public static Func<IEnumerable, bool> EmptyOrNull()
        {
            return (expected) =>
            {
                if (expected == null)
                    return true;

                var en = expected.GetEnumerator();
                if (en == null)
                    return true;

                en.Reset();
                return !en.MoveNext();
            };
        }

        public static Func<IEnumerable, bool> Empty()
        {
            return (expected) =>
            {
                var en = expected.GetEnumerator();
                en.Reset();
                return !en.MoveNext();
            };
        }

        public static Func<Action, bool> ErroringWith<T>()
            where T: Exception
        {
            return (method) =>
            {
                try
                {
                    method();
                    return false;
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(T))
                        return true;

                    else
                        return false;
                }
            };
        }

        public static Func<string, bool> EmptyString()
        {
            return (expected) => string.IsNullOrEmpty(expected.ToString());
        }

        public static Func<string, bool> MatchFor(string actual)
        {
            return (expected) => expected.Contains(actual);
        }

        public static Func<string, bool> MatchFor(Regex pattern)
        {
            return (expected) => pattern.IsMatch(expected);
        }

        public static Func<object, bool> Null()
        {
            return (expected) => expected == null;
        }
    }
}


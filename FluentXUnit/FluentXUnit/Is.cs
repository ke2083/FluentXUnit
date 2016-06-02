using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FluentXUnit
{
    public static class Is
    {
        public static Func<bool, XAssertionOperationResult> False()
        {
            return (expected) => new XAssertionOperationResult(expected == false, string.Format("{0} is not false.", expected));
        }

        public static Func<IEnumerable<T>, XAssertionOperationResult> Storing<T>(T item)
        {
            return (expected) => new XAssertionOperationResult(expected.Contains(item), string.Format("{0} does not contain {1}", expected, item));
        }

        public static Func<T, XAssertionOperationResult> EqualTo<T>(T actual)
        {
            return (expected) => new XAssertionOperationResult(expected.Equals(actual), string.Format("{0} is not equal to {1}", expected, actual));
        }

        public static Func<T, XAssertionOperationResult> LessThan<T>(T actual)
            where T: struct
        {
            return (expected) => new XAssertionOperationResult(GreaterThan(expected)(actual).Result == true, string.Format("{0} is not greater than {1}", expected, actual));
        }

        public static Func<T, XAssertionOperationResult> GreaterThan<T>(T actual)
            where T: struct
        {
            return (expected) =>
            {
                var actualParsed = double.Parse(actual.ToString());
                var expectedParsed = double.Parse(expected.ToString());
                return new XAssertionOperationResult(expectedParsed > actualParsed, string.Format("{0} is not greater than {1}", expected, actualParsed));
            };
        }

        public static Func<IEnumerable, XAssertionOperationResult> EmptyOrNull()
        {
            return (expected) =>
            {
                if (expected == null)
                    return new XAssertionOperationResult(true, string.Empty);

                var en = expected.GetEnumerator();
                if (en == null)
                    return new XAssertionOperationResult(true, string.Empty);

                en.Reset();
                return new XAssertionOperationResult(!en.MoveNext(), string.Format("{0} is not null and contains at least one element", expected));
            };
        }

        public static Func<IEnumerable, XAssertionOperationResult> Empty()
        {
            return (expected) =>
            {
                var en = expected.GetEnumerator();
                en.Reset();
                return new XAssertionOperationResult(!en.MoveNext(), string.Format("{0} contains at least one element", expected));
            };
        }

        public static Func<Action, XAssertionOperationResult> ErroringWith<T>()
            where T: Exception
        {
            return (method) =>
            {
                try
                {
                    method();
                    return new XAssertionOperationResult(false, string.Format("Exception {0} was not thrown", typeof(T)));
                }
                catch (Exception e)
                {
                    if (e.GetType() == typeof(T))
                        return new XAssertionOperationResult(true, string.Empty);

                    else
                        return new XAssertionOperationResult(false, "Exception was thrown, but was of type " + e.GetType().ToString());
                }
            };
        }

        public static Func<string, XAssertionOperationResult> EmptyString()
        {
            return (expected) => new XAssertionOperationResult(expected == null || string.IsNullOrEmpty(expected.ToString()), "String is not empty");
        }

        public static Func<string, XAssertionOperationResult> MatchFor(string actual)
        {
            return (expected) => new XAssertionOperationResult(expected.Contains(actual), string.Format("{0} does not contain string {1}", expected, actual));
        }

        public static Func<string, XAssertionOperationResult> MatchFor(Regex pattern)
        {
            return (expected) => new XAssertionOperationResult(pattern.IsMatch(expected), string.Format("{0} does not match pattern {1}", expected, pattern));
        }

        public static Func<IEnumerable<T>, XAssertionOperationResult> Storing<T>(Func<T, bool> query)
        {
            return (expected) => new XAssertionOperationResult(expected.Any(query), "IEnumerable does not contain any elements matching query");
        }

        public static Func<bool, XAssertionOperationResult> True()
        {
            return (expected) => new XAssertionOperationResult(expected == true, string.Format("{0} is not true", expected));
        }

        public static Func<T, XAssertionOperationResult> Null<T>()
            where T: class
        {
            return (expected) => new XAssertionOperationResult(expected == null, string.Format("{0} is not null", expected));
        }

        public static Func<object, XAssertionOperationResult> Null()
        {
            return (expected) => new XAssertionOperationResult(expected == null, string.Format("{0} is not null", expected));
        }
    }
}


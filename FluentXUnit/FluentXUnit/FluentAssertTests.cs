using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FluentXUnit
{
    public class FluentAssertTests
    {
        [Fact]
        public void TestEqualityTrue()
        {
            XAssert.That("A", Is.EqualTo("A"));
        }

        [Fact]
        public void TestInequalityTrue()
        {
            XAssert.That("A", IsNot.EqualTo("B"));
        }

        [Fact]
        public void TestEqualityFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That("A", Is.EqualTo("B"));
                });
        }

        [Fact]
        public void TestInequalityFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That("A", IsNot.EqualTo("A"));
                });
        }

        [Fact]
        public void TestLessThanTrue()
        {
            XAssert.That(1, Is.LessThan(2));
        }

        [Fact]
        public void TestLessThanFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That(2, Is.LessThan(1));
                });
        }

        [Fact]
        public void TestNotLessThanTrue()
        {
            XAssert.That(2, IsNot.LessThan(1));
        }

        [Fact]
        public void TestNotLessThanFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That(1, IsNot.LessThan(2));
                });
        }

        [Fact]
        public void TestGreaterThanTrue()
        {
            XAssert.That(2, Is.GreaterThan(1));
        }

        [Fact]
        public void TestGreaterThanFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That(1, Is.GreaterThan(2));
                });
        }

        [Fact]
        public void TestNotGreaterThanTrue()
        {
            XAssert.That(1, IsNot.GreaterThan(2));
        }

        [Fact]
        public void TestNotGreaterThanFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That(2, IsNot.GreaterThan(1));
                });
        }

        [Fact]
        public void TestIsEmptyStringTrue()
        {
            XAssert.That(string.Empty, Is.EmptyString());
        }

        [Fact]
        public void TestIsEmptyStringFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That("Test", Is.EmptyString());
                });
        }

        [Fact]
        public void TestIsNotEmptyStringTrue()
        {
            XAssert.That("Test", IsNot.EmptyString());
        }

        [Fact]
        public void TestIsNotEmptyStringFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That(string.Empty, IsNot.EmptyString());
                });
        }

        [Fact]
        public void TestIsNullTrue()
        {
            XAssert.That(null, Is.Null());
        }

        [Fact]
        public void TestIsNullFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That("test", Is.Null());
                });
        }

        [Fact]
        public void TestNotNullTrue()
        {
            XAssert.That("test", IsNot.Null());
        }

        [Fact]
        public void TestNotNullFalse()
        {
            Assert.Throws<Exception>(() =>
                {
                    XAssert.That(null, IsNot.Null());
                });
        }
    }
}


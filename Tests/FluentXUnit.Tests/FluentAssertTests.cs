using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using System.Text.RegularExpressions;

namespace FluentXUnit.Tests
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
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That("A", Is.EqualTo("B"));
                });
        }

        [Fact]
        public void TestInequalityFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
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
            Assert.Throws<XAssertionFailedException>(() =>
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
            Assert.Throws<XAssertionFailedException>(() =>
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
            Assert.Throws<XAssertionFailedException>(() =>
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
            Assert.Throws<XAssertionFailedException>(() =>
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
            Assert.Throws<XAssertionFailedException>(() =>
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
            Assert.Throws<XAssertionFailedException>(() =>
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
            Assert.Throws<XAssertionFailedException>(() =>
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
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That(null, IsNot.Null());
                });
        }

        [Fact]
        public void TestErroringWithTrue()
        {
            XAssert.That(() =>
                {
                    throw new XAssertionFailedException();
                }, Is.ErroringWith<XAssertionFailedException>());
        }


        [Fact]
        public void TestErroringWithFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That(() =>
                        {
                            throw new XAssertionFailedException();
                        }, Is.ErroringWith<System.IO.DirectoryNotFoundException>());
                });
        }

        [Fact]
        public void TestEmptyOrNullWithTrue()
        {
            ICollection<string> testVar = null;
            XAssert.That(testVar, Is.EmptyOrNull());
        }


        [Fact]
        public void TestEmptyOrNullWithFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    ICollection<string> testVar = new List<string> { "test" };
                    XAssert.That(testVar, Is.EmptyOrNull());
                });
        }

        [Fact]
        public void TestEmptyWithTrue()
        {
            var testVar = new List<string>();
            XAssert.That(testVar, Is.Empty());
        }


        [Fact]
        public void TestEmptyWithFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    var testVar = new List<string> { "test" };
                    XAssert.That(testVar, Is.Empty());
                });
        }

        [Fact]
        public void TestNotErroringWithTrue()
        {
            XAssert.That(() =>
                {
                    var a = 1;
                }, IsNot.ErroringWith<XAssertionFailedException>());
        }


        [Fact]
        public void TestNotErroringWithFalse()
        {
            XAssert.That(() =>
                {
                    var a = 1;
                }, IsNot.ErroringWith<System.IO.DirectoryNotFoundException>());
        }

        [Fact]
        public void TestNotEmptyOrNullWithTrue()
        {
            ICollection<string> testVar = new List<string> { "test" };
            XAssert.That(testVar, IsNot.EmptyOrNull());
        }


        [Fact]
        public void TestNotEmptyOrNullWithFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    ICollection<string> testVar = new List<string>();
                    XAssert.That(testVar, IsNot.EmptyOrNull());
                });
        }

        [Fact]
        public void TestNotEmptyWithTrue()
        {
            var testVar = new List<string>() { "test" };
            XAssert.That(testVar, IsNot.Empty());
        }


        [Fact]
        public void TestNotEmptyWithFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    var testVar = new List<string>();
                    XAssert.That(testVar, IsNot.Empty());
                });
        }

        [Fact]
        public void TestContainsStringTrue()
        {
            XAssert.That("mystring", Is.MatchFor("str"));
        }


        [Fact]
        public void TestContainsStringFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That("bibble", Is.MatchFor("str"));
                });
        }

        [Fact]
        public void TestContainsRegexTrue()
        {
            var re = new Regex("str");
            XAssert.That("mystring", Is.MatchFor(re));
        }


        [Fact]
        public void TestContainsRegexFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    var re = new Regex("str");
                    XAssert.That("bibble", Is.MatchFor(re));
                });
        }

        [Fact]
        public void TestContainsItemTrue()
        {
            var test = new List<string> { "test" };
            XAssert.That(test, Is.Storing("test"));
        }


        [Fact]
        public void TestContainsItemFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {

                    var test = new List<string> { "test" };
                    XAssert.That(test, Is.Storing("test2"));
                });
        }

        [Fact]
        public void TestNotContainsStringTrue()
        {
            XAssert.That("bibble", IsNot.MatchFor("str"));
        }


        [Fact]
        public void TestNotContainsStringFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That("string", IsNot.MatchFor("str"));
                });
        }

        [Fact]
        public void TestNotContainsRegexTrue()
        {
            var re = new Regex("bibble");
            XAssert.That("mystring", IsNot.MatchFor(re));
        }


        [Fact]
        public void TestNotContainsRegexFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    var re = new Regex("str");
                    XAssert.That("string", IsNot.MatchFor(re));
                });
        }

        [Fact]
        public void TestNotContainsItemTrue()
        {
            var test = new List<string> { "test2" };
            XAssert.That(test, IsNot.Storing("test"));
        }


        [Fact]
        public void TestNotContainsItemFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {

                    var test = new List<string> { "test2" };
                    XAssert.That(test, IsNot.Storing("test2"));
                });
        }

        [Fact]
        public void TestsCanBeChained()
        {
            XAssert
                .That("string", IsNot.EmptyString())
                .And(Is.MatchFor("ing"))
                .And(Is.MatchFor("str"));
        }

        [Fact]
        public void TestsCanBeChainedFirstFails()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {

                    XAssert
                        .That(null, IsNot.EmptyString())
                        .And(Is.EqualTo("test"));

                });
        }


        [Fact]
        public void TestsCanBeChainedSecondFails()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {

                    XAssert
                        .That("test2", IsNot.EmptyString())
                        .And(Is.EqualTo("test"));

                });
        }

        [Fact]
        public void TestIsTrueTrue()
        {
            XAssert.That(true, Is.True());
        }

        [Fact]
        public void TestIsTrueFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That(true, Is.False());
                });
        }

        [Fact]
        public void TestIsFalseTrue()
        {
            XAssert.That(false, Is.False());
        }

        [Fact]
        public void TestIsFalseFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That(false, Is.True());
                });
        }

        [Fact]
        public void TestIsNotTrueTrue()
        {
            XAssert.That(false, IsNot.True());
        }

        [Fact]
        public void TestIsNotTrueFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That(true, IsNot.True());
                });
        }

        [Fact]
        public void TestIsNotFalseTrue()
        {
            XAssert.That(true, IsNot.False());
        }

        [Fact]
        public void TestIsNotFalseFalse()
        {
            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That(false, IsNot.False());
                });
        }

        private class Person
        {
            public string Name;
            public int Age;
        }

        [Fact]
        public void TestContainsWithQueryTrue()
        {
            var myList = new List<Person> {
                new Person { Name = "Kaylee", Age = 33 },
                new Person { Name = "Cloud", Age = 29 }
            };

            XAssert.That(myList, Is.Storing<Person>(l => l.Name == "Kaylee"));
        }

        [Fact]
        public void TestContainsWithQueryFalse()
        {
            var myList = new List<Person> {
                new Person { Name = "Kaylee", Age = 33 },
                new Person { Name = "Cloud", Age = 29 }
            };

            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That(myList, Is.Storing<Person>(l => l.Name == "Biff"));
                });
        }

        [Fact]
        public void TestNotContainsWithQueryTrue()
        {
            var myList = new List<Person> {
                new Person { Name = "Kaylee", Age = 33 },
                new Person { Name = "Cloud", Age = 29 }
            };

            Assert.Throws<XAssertionFailedException>(() =>
                {
                    XAssert.That(myList, IsNot.Storing<Person>(l => l.Name == "Kaylee"));
                });
        }

        [Fact]
        public void TestNotContainsWithQueryFalse()
        {
            var myList = new List<Person> {
                new Person { Name = "Kaylee", Age = 33 },
                new Person { Name = "Cloud", Age = 29 }
            };


            XAssert.That(myList, IsNot.Storing<Person>(l => l.Name == "Biff"));
        }

        [Fact]
        public void TestChainedWithQueryTrue()
        {
            var myList = new List<int> { 1, 2, 3 };
            XAssert
                .That(myList, IsNot.Null<List<int>>())
                .And(m => m.Count, Is.EqualTo(3));
        }
    }
}


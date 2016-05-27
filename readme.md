# FluentXUnit

If, like me, you think that the fluent syntax of NUnit 3 is something that you 
miss when working with XUnit then don't fear!

This little DLL will allow you to use an NUnit style syntax for your assertions.

## Example usage
   
   XAssert.That("A", Is.EqualTo("A"));
   XAssert.That("A", IsNot.EqualTo("B"));
   XAssert.That("A", Is.EqualTo("B"));
   XAssert.That("A", IsNot.EqualTo("A"));
   XAssert.That(1, Is.LessThan(2));
   XAssert.That(2, Is.LessThan(1));
   XAssert.That(2, IsNot.LessThan(1));
   XAssert.That(1, IsNot.LessThan(2));
   XAssert.That(2, Is.GreaterThan(1));
   XAssert.That(1, Is.GreaterThan(2));
   XAssert.That(1, IsNot.GreaterThan(2));
   XAssert.That(2, IsNot.GreaterThan(1));
   XAssert.That(string.Empty, Is.EmptyString());
   XAssert.That("Test", Is.EmptyString());
   XAssert.That("Test", IsNot.EmptyString());
   XAssert.That(string.Empty, IsNot.EmptyString());
   XAssert.That(null, Is.Null());
   XAssert.That("test", Is.Null());
   XAssert.That("test", IsNot.Null());
   XAssert.That(null, IsNot.Null());

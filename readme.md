# FluentXUnit

If, like me, you think that the fluent syntax of NUnit 3 is something that you 
miss when working with XUnit then don't fear!

This little DLL allows you to use an NUnit style syntax for your assertions.

## Usage

### Assert that two strings are equal:

    XAssert.That("A", Is.EqualTo("A"));

and negated:

    XAssert.That("A", IsNot.EqualTo("B"));
    
### Assert that one thing is less than another:

    XAssert.That(1, Is.LessThan(2));

and negated:
    
    XAssert.That(2, IsNot.LessThan(1));

### Assert that one thing is greater than another:

    XAssert.That(2, Is.GreaterThan(1));

and negated:
    
    XAssert.That(1, IsNot.GreaterThan(2));

### Assert that a string is empty:

    XAssert.That(string.Empty, Is.EmptyString());

and negated:
    
    XAssert.That("Test", IsNot.EmptyString());

### Assert that something is null:

    XAssert.That(null, Is.Null());

and negated:
    
    XAssert.That("test", IsNot.Null());

### Assert that an action throws a particular exception:

    XAssert.That(() =>
    {
        throw new XAssertionFailedException();
    }, Is.ErroringWith<XAssertionFailedException>());

and negated:

    XAssert.That(() =>
    {
        var a = 1;
    }, IsNot.ErroringWith<XAssertionFailedException>());

### Assert that a collection is empty or null:

    ICollection<string> testVar = null;
    XAssert.That(testVar, Is.EmptyOrNull());

and negated:

    ICollection<string> testVar2 = new List<string> { "test" };
    XAssert.That(testVar2, IsNot.EmptyOrNull());

### Assert that a collection is empty (but not null):

    var testVar = new List<string>();
    XAssert.That(testVar, Is.Empty());

and negated:

    var testVar2 = new List<string>() { "test" };
    XAssert.That(testVar2, IsNot.Empty());

### Assert that one string contains another:

    XAssert.That("mystring", Is.MatchFor("str"));

and negated:

    XAssert.That("bibble", IsNot.MatchFor("str"));

### Assert that a string is matched by a Regex:

    var re = new Regex("str");
    XAssert.That("mystring", Is.MatchFor(re));

and negated:

    var re2 = new Regex("bibble");
    XAssert.That("mystring", IsNot.MatchFor(re2));

### Assert that a collection contains a particular item:

    var test = new List<string> { "test" };
    XAssert.That(test, Is.Storing("test"));

and negated:

    var test2 = new List<string> { "test2" };
    XAssert.That(test2, IsNot.Storing("test"));


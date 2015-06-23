var assert = require('./assert.js');
var code = require('../code.js');
var tests = {
    helloWorldTest: function() {
        assert.areEqual("Hello World!", code.helloWorld());
    },
    capitalizeEveryNthWordTest: function() {
        var sentence = "Lorem ipsum dolor sit amet";
        assert.areEqual("Lorem ipsum Dolor sit Amet", code.capitalizeEveryNthWord(sentence, 0, 2));
        assert.areEqual("Lorem ipsum Dolor Sit Amet", code.capitalizeEveryNthWord(sentence, 2, 1));
    },
    isPrimeTest: function() {
        assert.isFalse(code.isPrime(-1), "IsPrime(-1) should be false.");
        assert.isFalse(code.isPrime(0), "IsPrime(0) should be false.");
        assert.isFalse(code.isPrime(1), "IsPrime(1) should be false.");
        assert.isTrue(code.isPrime(2), "IsPrime(2) should be true.");
        assert.isTrue(code.isPrime(5), "IsPrime(5) should be true.");
        assert.isFalse(code.isPrime(87), "IsPrime(87) should be false.");
        assert.isTrue(code.isPrime(97), "IsPrime(97) should be true.");
    },
    goldenRatioTest: function() {
        // you had a syntax error here
        // you had 1,61806 instead of 1.61806
        // so your range was getting 4 params
        // instead of 3 and failing
        assert.isInRange(1.61800, 1.61806, code.goldenRatio(1.0, 1.0));
        assert.isInRange(1.61800, 1.61806, code.goldenRatio(100, 6));
    },
    fibonacciTest: function() {
        assert.areEqual(0, code.fibonacci(0));
        assert.areEqual(1, code.fibonacci(1));
        assert.areEqual(1, code.fibonacci(2));
        assert.areEqual(2, code.fibonacci(3));
        assert.areEqual(6765, code.fibonacci(20));
    },
    squareRootTest: function() {
        // another mistake!  AreEqual -> areEqual
        // another mistake!  IsInRange -> isInRange
        assert.areEqual(5.0, code.squareRoot(25.0));
        assert.isInRange(1.414, 1.4144, code.squareRoot(2.0));
    }

};
module.exports = tests;


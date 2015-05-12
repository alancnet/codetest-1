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
        assert.IsFalse(code.isPrime(-1), "IsPrime(-1) should be false.");
        assert.IsFalse(code.isPrime(0), "IsPrime(0) should be false.");
        assert.IsFalse(code.isPrime(1), "IsPrime(1) should be false.");
        assert.IsTrue(code.isPrime(2), "IsPrime(2) should be true.");
        assert.IsTrue(code.isPrime(5), "IsPrime(5) should be true.");
        assert.IsFalse(code.isPrime(87), "IsPrime(87) should be false.");
        assert.IsTrue(code.isPrime(97), "IsPrime(97) should be true.");
    }
};
module.exports = tests;


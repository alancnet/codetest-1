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
    }
};
module.exports = tests;


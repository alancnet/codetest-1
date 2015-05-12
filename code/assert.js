var assert = {
    areEqual: function(expected, actual, failText) {
        if (expected !== actual) 
            throw new Error(failText || ["Expected '", expected, "', but got '", actual, "'."].join(''));
    },
    isTrue: function(condition, failText) {
        if (!condition) 
            throw new Error(failText || "Expected true.");
    },
    isFalse: function(condition, failText) {
        if (condition)
            throw new Error(failText || "Expected false.")
    }
}

module.exports = assert;

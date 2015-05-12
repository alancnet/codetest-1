var assert = {
	areEqual: function(expected, actual) {
		if (expected !== actual) throw new Error(["Expected '", expected, "', but got '", actual, "."].join(''));
	}
}

module.exports = assert;

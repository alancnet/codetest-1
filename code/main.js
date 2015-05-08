var code = require('./code.js');

function Program() {
	var assert;
	
	function helloWorldTest() {
		assert.areEqual("Hello World!", code.helloWorld());
	}

	function capitalizeEveryNthWordTest() {
		var sentence = "Lorem ipsum dolor sit amet";
		assert.areEqual("Lorem Ipsum dolor Sit amet", code.capitalizeEveryNthWord(sentence, 0, 2));
		assert.areEqual("Lorem ipsum Dolor Sit Amet", code.capitalizeEveryNthWord(sentence, 2, 1));
		assert.areEqual("Lorem ipsum Dolor sit Amet", code.capitalizeEveryNthWord(sentence, 0, 2));
	}

	
	function test(t, name) {
		try {
			t();
			console.log("PASS:" + name);
		} catch (ex) {
			console.log("FAIL:" + name + ": " + (ex.message || ex));
		}
	}
	
	function main() {
		console.log("\nJavaScript Tests:");
		test(helloWorldTest, "helloWorld()");
		test(capitalizeEveryNthWordTest, "capitalizeEveryNthWord(...)");
		console.log("Done!");
	}
	
	assert = {
		areEqual: function(expected, actual) {
			if (expected !== actual) throw new Error(["Expected '", expected, "', but got '", actual, "."].join(''));
		}
	}
	main();
}

Program();
var code = require('./code.js');

function Program() {
	var assert;
	
	function helloWorldTest() {
		assert.areEqual("Hello World!", code.helloWorld());
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
		test(helloWorldTest, "HelloWorld()");
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
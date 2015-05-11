var code = require('../code.js');
var tests = require('./tests.js');
function Program() {
	
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
		test(tests.helloWorldTest, "helloWorld()");
		console.log("Done!");
	}
	main();
}

Program();
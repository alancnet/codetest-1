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
        var names = Object.getOwnPropertyNames(tests).sort();
        names.forEach(function(name, i) {
            if (/Test$/.test(name)) {
                test(tests[name], name);
            }
        });
        console.log("Done!");
    }
    main();
}

Program();
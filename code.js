var code = {
    // Returns "Hello World!"
    helloWorld: function() {
        return "Hello World!";
    },

    // Take a single-spaced <sentence>, and capitalize every <n>th word starting with <offset>.
    capitalizeEveryNthWord: function(sentence, offset, n) {
      function toWords() { return sentence.split(" "); }
      function toSentence(words) { return words.join(" "); }
      function capitalize(word) { return word[0].toUpperCase() + word.slice(1, word.length); }
      function getOffsetWords(words) { return words.slice(0, offset); }
      function getRemainingWords(words) { return words.slice(offset, words.length); }
      function isNth (n, i) { return !(i % n); }
      function identity (x) { return x; }
      function doOnNth(fn, n, list) {
        return list.map(function(item, i) { return isNth(n, i) ? fn(item) : identity(item); } );
      }

      var words = toWords(sentence);
      var offsetWords = getOffsetWords(words, offset);
      var remainingWords = getRemainingWords(words, offset);

      return toSentence(offsetWords.concat(doOnNth(capitalize, n, remainingWords)));
    },
    
    // Determine if a number is prime
    isPrime: function(n) {
      // no negatives
      if (n < 0) return false;
      // do the first few manually
      if (n === 0) return false;
      if (n === 1) return false;
      if (n === 2) return true;
      if (n === 3) return true;
      // now some quick wins
      if (n % 2 === 0 || n % 3 === 0) { return false; }
      // for n > 4 we need more logic with a bit of optimization
      for (var  i = 5; i * i <= n; i += 6) {
          if (n % i === 0 || n % (i + 2) === 0) { return false; }
      }
      return true;
    },
    
    // Calculate the golden ratio.
    // Given two numbers a and b with a > b > 0, the ratio is b / a.
    // Let c = a + b, then the ratio c / b is closer to the golden ratio.
    // Let d = b + c, then the ratio d / c is closer to the golden ratio. 
    // Let e = c + d, then the ratio e / d is closer to the golden ratio.
    // If you continue this process, the result will trend towards the golden ratio.
    goldenRatio: function(a, b) {
      // NOTE - you had a syntax error in your tests!  You used a comma
      // instead of a period in range's maximum
      // (I've submitted a pull request with the fix)

      var iterations = 1000;
      function estimatedGoldenRatio(a, b, i) {
        i = i || 0;
        if (i > iterations) return b / a;
        var sum = a + b;
        return estimatedGoldenRatio(b, sum, ++i);
      }

      return estimatedGoldenRatio(a, b);
    },

    // Give the nth Fibonacci number
    // Starting with 0, 1, 1, 2, ... a Fibonacci number is the sum of the previous two.
    fibonacci: function(n) {
      // for the first two items in set fibonacci
      if(n === 0) return 0;
      if(n === 1) return 1;
      // for all others, add what the two previous values would be
      return this.fibonacci(n - 1) + this.fibonacci(n - 2);
    },

    // Give the square root of a number
    // Using a binary search algorithm, search for the square root of a given number.
    // Do not use the built-in square root function.
    squareRoot: function(n) {
      var iterations = 10000;
      var tolerance = 0.000000000000001;
      var tooSmall = 0;
      var tooBig = n;
      function honeIn() { return (tooBig - tooSmall) / 2; }
      function estimateSquareRoot(root, i) {
        // return answer
        // case: found perfect square
        if (root * root === n) return root;
        // case: estimate is close enough
        if (tooBig - tooSmall < tolerance) return root;
        i = i || 0;
        // case: hit iteration limit
        if (i > iterations) return root;

        // recurse
        // case: root is too big
        if (root * root > n) {
          tooBig = root;
          return estimateSquareRoot(honeIn(), ++i);
        }
        // case: root is too small
        if (root * root < n) {
          tooSmall = root;
          return estimateSquareRoot(tooSmall + honeIn(), ++i);
        }
      }
      return estimateSquareRoot(honeIn());
    }
};
module.exports = code;

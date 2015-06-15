public class Code {

    // Returns "Hello World!"
    public static String helloWorld() {
        return "Hello World!";
    }

    private static String capitalize(String s) {
        return s.substring(0, 1).toUpperCase() + s.substring(1);
    }

    // Take a single-spaced <sentence>, and capitalize every <n> word starting with <offset>.
    public static String capitalizeEveryNthWord(String sentence, Integer offset, Integer n) {
        String[] words = sentence.split(" ");

        StringBuffer sb = new StringBuffer();
        for (int i=0; i<words.length; i++) {
            if (i<offset) {
                sb.append(words[i]);
            }
            else if (((i-offset)%n) == 0) {
                sb.append(capitalize(words[i]));
            }
            else {
                sb.append(words[i]);
            }
            sb.append(" ");
        }

        // strip off the last character
        return sb.substring(0, sb.length()-1).toString();
    }

    // Determine if a number is prime
    public static Boolean isPrime(Integer n) {

        if (n <= 1) {
            return false;
        }

        boolean foundNonPrime = false;
        for (int i=2; i<((n/2)); i++) {
            //System.out.println("n:" + n + " i:" + i + " n%i:" + n%i);
            if (n%i == 0) {
                // something is equally divisible!
                //System.out.println(i);
                foundNonPrime = true;
                break;
            }
        }

        return !foundNonPrime;

    }

    private static Double rGoldenRatio(Double acc, Double a, Double b) {
        Double last = acc;
        Double newAcc = (a+b)/b;
        //System.out.println(newAcc);
        if (last.equals(newAcc)) {
            return newAcc;
        }
        else {
            return rGoldenRatio(newAcc, b, a+b);
        }
    }

    // Calculate the golden ratio.
    // Given two numbers, a and b, the ratio is a / b.
    // Let c = a + b, then the ratio b / c is closer to the golden ratio.
    // Let d = b + c, then the ratio c / d is closer to the golden ratio.
    // Let e = c + d, then the ratio d / e is closer to the golden ratio.
    // If you continue this process, the result will trend towards the golden ratio.
    public static Double goldenRatio(Double a, Double b) {

        return rGoldenRatio(0.0, a, b);

    }

    // Give the nth Fibionacci number
    // Starting with 1 and 1, a Fibionacci number is the sum of the previous two.
    public static Integer fibionacci(Integer n) {
        if (n == 0) {
            return 0;
        }
        if (n == 1) {
            return 1;
        }
        else {
            int acc = 0;
            int n1 = 0;
            int n2 = 1;

            // we do n-1 because the first iteration is taking both of the first two numbers.
            for (int i=0; i<(n-1); i++) {
                acc = n1 + n2;

                n1 = n2;
                n2 = acc;
            }

            return acc;
        }
    }

    private static Double rSquareRoot(Double acc, Double last, Double lower, Double upper, Double n) {

        //System.out.println("acc: " + acc + " last: " + last + " lower: " + lower + " upper: " + upper + " n: " + n);

        if (acc.equals(last)) {
            //System.out.println("Got result!");
            return last;
        }
        else {
            Double middle = lower + ((upper - lower) / 2);
            if (Math.pow(middle, 2) <= n) {
                //System.out.println("Upper range");
                return rSquareRoot(middle, acc, middle, upper, n);
            }
            else {
                //System.out.println("Lower range");
                return rSquareRoot(middle, acc, lower, middle, n);
            }
        }
    }

    // Give the square root of a number
    // Using a binary search algorithm, search for the square root of a given number.
    // Do not use the built-in square root function.
    public static Double squareRoot(Double n) {
        return rSquareRoot(0.0, n, 0.0, n, n);
    }
}
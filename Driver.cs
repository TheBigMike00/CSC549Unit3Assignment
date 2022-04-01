using System;

namespace Unit3Assignment
{
    class Driver
    {
        #region Exercise 1.31
        //Product function similar to sum defined on pages 77/78
        public delegate double Term(int a);
        public static double Product(Term term, int a, int b)
        {
            if (a > b)
                return 1;
            return term(a) * Product(term, Next(a), b);
        }

        public static int Next(int x)
        {
            return x + 1;
        }

        public static double Identity(int x)
        {
            return x;
        }

        public static double Factorial(int val)
        {
            return Product(Identity, 1, val);
        }

        public static double PiTerm(int x)
        {
            if (x % 2 == 0)
                return (x + 2.0) / (x + 1.0);
            return (x + 1.0) / (x + 2.0);
        }

        public static double EstimatePi(int iterations)
        {
            return 4 * Product(PiTerm, 1, iterations);
        }

        //PART B
        public static double ProductIterative(Term term, int b)
        {
            if (b < 1)
                return 0.0;
            return ProductIterative_iter(term, 1, 1, b);
        }

        public static double ProductIterative_iter(Term term, double result, int currIteration, int limit)
        {
            if (currIteration > limit)
                return result;
            return ProductIterative_iter(term, result * term(currIteration), Next(currIteration), limit);
        }

        public static double EstimatePiIteratively(int iterations)
        {
            return 4 * ProductIterative(PiTerm, iterations);
        }
        #endregion


        #region Exercise 1.34
        public static double f(Term g)
        {
            return g(2);
        }

        // We are unable to evaluate (f f) as it causes an error. 
        //It attempts to resolve its argument to a value of 2 both times but 
        //ultimately doesn't accomplish anything (unlike square, factorial, or lambda below
        #endregion


        #region Exercise 1.40
        public delegate double Exp(double a);
        public static double dx = 0.00001;

        public static Exp Deriv(Exp g)
        {
            return x => (g(x + dx) - g(x)) / dx;
        }

        public static double Cube(double x)
        {
            return x * x * x;
        }

        public static Exp NewtonTransform (Exp g)
        {
            return x => x - (g(x) / Deriv(g)(x));
        }

        public static Exp Cubic(double a, double b, double c)
        {
            return x => Cube(x) + (a * x * x) + (b * x) + c;
        }
        #endregion


        #region Exercise 1.41
        public static Exp Double(Exp ex)
        {
            return x => ex(ex(x));
        }

        public static double Inc(double val)
        {
            return val + 1;
        }
        #endregion


        public static void Main(string[] args)
        {
            //Exercise 1.31
            Console.WriteLine("Factorial: " + Factorial(4) + "\n");
            Console.WriteLine("PI Estimate: " + EstimatePi(10000) + "\n");
            Console.WriteLine("PI Estimate Iteratively: " + EstimatePiIteratively(10000) + "\n\n");

            //Exercise 1.34
            Console.WriteLine("Factorial: " + f(Factorial) + "\n");
            Console.WriteLine("Lambda: " + f(x=>x * (x+1)) + "\n\n");
            //Console.WriteLine("Lambda: " + f(f) + "\n\n"); error

            //Exercise 1.40
            Console.WriteLine("Cubic: " + Cubic( 3, 6, 4)(1) + "\n\n");

            //Exercise 1.41
            Console.WriteLine("Double/Inc: " + Double(Double(Double(Inc)))(5) + "\n\n");
        }
    }
}

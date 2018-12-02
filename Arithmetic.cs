using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticatedCalculator
{
    class Arithmetic
    {
        public static double Add(double x, double y)
        {
            return x + y;
        }

        public static double Subtract(double x, double y)
        {
            return x - y;
        }

        public static double Multiply(double x, double y)
        {
            return x * y;
        }

        public static double Divide(double x, double y)
        {
            return x / y;
        }

        public static double Exponent(double x, int y)
        {
            double z;

            if (y >= 2)
            {
                z = x;
                for (int i = 2; i <= y; i++)
                {
                    z = z * x;
                }
                return z;
            }
            else if (y == 1)
            {
                return z = x;
            }
            else if (y == 0)
            {
                return z = 1;
            }
            else if (y == -1)
            {
                return z = 1 / x;
            }
            else            //condition for y <= -2
            {
                y = -y;
                z = x;
                for (int i = 2; i <= y; i++)
                {
                    z = z * x;
                }
                return z = 1 / z;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RedPillCloud
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class RedPill : IRedPill
    {
        public Guid WhatIsYourToken()
        {
            return new Guid("a6b54f21-0f5d-4455-9ae0-10931dd3f9a6");
        }

        public long FibonacciNumber(long n)
        {
            if (n > 92)
            {
                throw new FaultException<ArgumentOutOfRangeException>(new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow."), new FaultReason("Fib(>92) will cause a 64-bit integer overflow."));
            }
            try
            {
                long finalValue = 0;
                var absN = Math.Abs(n);
                if (absN == 0 || absN == 1)
                {
                    finalValue = absN;
                }
                else if (absN == 2)
                {
                    finalValue = 1;
                }
                else
                {
                    long i1 = 1;
                    long i2 = 1;
                    long i3 = i1 + i2;
                    for (int i = 3; i <= absN; i++)
                    {
                        i3 = i1 + i2;
                        i1 = i2;
                        i2 = i3;
                    }
                    finalValue = i3;
                }
                if (n < 0)
                {
                    double sign = (n / 2) + 1;
                    return finalValue * (long)Math.Pow(-1d, absN + 1);
                }
                else
                {
                    return finalValue;
                }
            }
            catch (Exception exp)
            {
                throw new FaultException("Exception occurred" + exp.ToString());
            }
        }

        public TriangleType WhatShapeIsThis(int a, int b, int c)
        {
            try
            {
                if (a < 0 || b < 0 || c < 0)
                {
                    return TriangleType.Error;
                }

                var sumC = a + b;
                var sumA = b + c;
                var sumB = a + c;

                if (sumC <= c || sumA <= a || sumB <= b)
                {
                    return TriangleType.Error;
                }

                if (a == b && b == c)
                {
                    return TriangleType.Equilateral;
                }
                else if (a != b && b != c && c != a)
                {
                    if (sumC <= c || sumA <= a || sumB <= b)
                    {
                        return TriangleType.Error;
                    }

                    return TriangleType.Scalene;
                }
                else
                {
                    return TriangleType.Isosceles;
                }
            }
            catch
            {
                return TriangleType.Error;
            }
        }

        public string ReverseWords(string s)
        {
            if (s == null)
            {
                throw new FaultException<ArgumentNullException>(new ArgumentNullException("s", "Value cannot be null."), new FaultReason("Value cannot be null."));
            }
            StringBuilder reverse = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                reverse = reverse.Append(s.Substring(i, 1));
            }

            return reverse.ToString();
        }
    }
}

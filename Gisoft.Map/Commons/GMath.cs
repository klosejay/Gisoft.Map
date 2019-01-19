using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gisoft
{
    /// <summary>
    /// 数学库
    /// </summary>
    public static class GMath
    {
        public static void LinearEquationWithTwoUnknows(double[] args1, double[] args2, out double[] result)
        {
            double x = (args1[2] * args2[1] - args2[2] * args1[1]) / (args1[1] * args2[0] - args2[1] * args1[0]);
            double y = (args1[2] * args2[0] - args2[2] * args1[0]) / (args1[0] * args2[1] - args2[0] * args1[1]);
            result = new double[] { x, y };
        }
        public static double[] LinearEquationWithTwoUnknows(double[] args1, double[] args2)
        {
            double[] result;
            LinearEquationWithTwoUnknows(args1, args2, out result);
            return result;
        }
    }
}

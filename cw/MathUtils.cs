using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace cw
{
    public static class MathUtils
    {
        public static double NormalDistribution(double z)
        {
            Chart x = new Chart();
            return x.DataManipulator.Statistics.NormalDistribution(z);
        }

        public static double InverseNormalDistribution(double z)
        {
            Chart x = new Chart();
            return x.DataManipulator.Statistics.InverseNormalDistribution(z);
        }

        public static double StandardNormalDistribution(double z)
        {
            return Math.Exp(-0.5 * z * z) / Math.Sqrt(2 * Math.PI);
        }

    }
}

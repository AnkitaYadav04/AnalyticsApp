using Analytics.API.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Analytics.API.Test.HelperTest
{
    public class MetriceCalculationHelperTest
    {
        [Fact]
        public void MetriceCalculationHelper_CalculateDrawdownYTD_ShouldReturnDrawDownValue()
        {
            List<double> pnlLtd = new List<double> { 1.1, 2.2, 5.5, 10, 3.3 };

            var result = MetriceCalculationHelper.CalculateDrawdownYTD(pnlLtd);

            //Peak PnlLtd = 10, Currentpnltd = 3.3

            Assert.Equal(-6.7, result);
        }

        [Fact]
        public void MetriceCalculationHelper_CalculatePnLLTD_ShouldReturnPnltdsValue()
        {
            List<double> pnlLtd = new List<double> { 1, 3, 5, 10.5 };

            var result = MetriceCalculationHelper.CalculatePnLLTD(pnlLtd);

            var pnltds = result.PnlLtds.ToList();
            var currentPnld = result.currentPnlLtd;
            //1,4,9,19.5

            Assert.Equal(1, pnltds.ElementAt(0));
            Assert.Equal(4, pnltds.ElementAt(1));
            Assert.Equal(9, pnltds.ElementAt(2));
            Assert.Equal(19.5, pnltds.ElementAt(3));
            Assert.Equal(19.5, currentPnld);
        }


        [Fact]
        public void MetriceCalculationHelper_CalculatePnLLTDWithEmptyList_ShouldReturnPnltdsZeroValue()
        {
            List<double> pnlLtd = new List<double> ();

            var result = MetriceCalculationHelper.CalculatePnLLTD(pnlLtd);

            var pnltds = result.PnlLtds.ToList();
            var currentPnld = result.currentPnlLtd;

            Assert.Empty(pnltds);
            Assert.Equal(0, currentPnld);
        }
    }
}

#region Using declarations
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
using NinjaTrader.Custom.AddOns.Test;

namespace NinjaTrader.NinjaScript.Indicators
{
    public class Test2 : Indicator
    {
        protected override void OnStateChange()
        {
            if (State == State.SetDefaults)
            {
                Description = @"Enter the description for your new custom Indicator here.";
                Name = "_Test2";
                Calculate = Calculate.OnBarClose;
                IsOverlay = false;
                DisplayInDataBox = true;
                DrawOnPricePanel = true;
                DrawHorizontalGridLines = true;
                DrawVerticalGridLines = true;
                PaintPriceMarkers = true;
                ScaleJustification = NinjaTrader.Gui.Chart.ScaleJustification.Right;
                //Disable this property if your indicator requires custom values that cumulate with each new market data event. 
                //See Help Guide for additional information.
                IsSuspendedWhileInactive = true;
            }
            else if (State == State.DataLoaded)
            {
                TestEvents.OnSendToTest2 += HandleSendToTest2;
            }
        }

        protected override void OnBarUpdate()
        {
            TestEvents.SendToTest1("Sending to Test1");
        }

        private void HandleSendToTest2(string value)
        {
            Print($"Received from Test1: {value}");
        }
    }
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
    public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
    {
        private Test2[] cacheTest2;
        public Test2 Test2()
        {
            return Test2(Input);
        }

        public Test2 Test2(ISeries<double> input)
        {
            if (cacheTest2 != null)
                for (int idx = 0; idx < cacheTest2.Length; idx++)
                    if (cacheTest2[idx] != null && cacheTest2[idx].EqualsInput(input))
                        return cacheTest2[idx];
            return CacheIndicator<Test2>(new Test2(), input, ref cacheTest2);
        }
    }
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
    public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
    {
        public Indicators.Test2 Test2()
        {
            return indicator.Test2(Input);
        }

        public Indicators.Test2 Test2(ISeries<double> input)
        {
            return indicator.Test2(input);
        }
    }
}

namespace NinjaTrader.NinjaScript.Strategies
{
    public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
    {
        public Indicators.Test2 Test2()
        {
            return indicator.Test2(Input);
        }

        public Indicators.Test2 Test2(ISeries<double> input)
        {
            return indicator.Test2(input);
        }
    }
}

#endregion

#region Using declarations
#endregion

//This namespace holds Indicators in this folder and is required. Do not change it. 
using NinjaTrader.Custom.AddOns.Test;

namespace NinjaTrader.NinjaScript.Indicators
{
    public class Test1 : Indicator
    {
        protected override void OnStateChange()
        {
            if (State == State.SetDefaults)
            {
                Description = @"Enter the description for your new custom Indicator here.";
                Name = "_Test1";
                Calculate = Calculate.OnEachTick;
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
                TestEvents.OnSendToTest1 += HandleSendToTest1;
            }
        }

        protected override void OnBarUpdate()
        {
            TestEvents.SendToTest2("Sending to Test2");
        }

        private void HandleSendToTest1(string value)
        {
            Print($"Received from Test2: {value}");
        }
    }
}

#region NinjaScript generated code. Neither change nor remove.

namespace NinjaTrader.NinjaScript.Indicators
{
    public partial class Indicator : NinjaTrader.Gui.NinjaScript.IndicatorRenderBase
    {
        private Test1[] cacheTest1;
        public Test1 Test1()
        {
            return Test1(Input);
        }

        public Test1 Test1(ISeries<double> input)
        {
            if (cacheTest1 != null)
                for (int idx = 0; idx < cacheTest1.Length; idx++)
                    if (cacheTest1[idx] != null && cacheTest1[idx].EqualsInput(input))
                        return cacheTest1[idx];
            return CacheIndicator<Test1>(new Test1(), input, ref cacheTest1);
        }
    }
}

namespace NinjaTrader.NinjaScript.MarketAnalyzerColumns
{
    public partial class MarketAnalyzerColumn : MarketAnalyzerColumnBase
    {
        public Indicators.Test1 Test1()
        {
            return indicator.Test1(Input);
        }

        public Indicators.Test1 Test1(ISeries<double> input)
        {
            return indicator.Test1(input);
        }
    }
}

namespace NinjaTrader.NinjaScript.Strategies
{
    public partial class Strategy : NinjaTrader.Gui.NinjaScript.StrategyRenderBase
    {
        public Indicators.Test1 Test1()
        {
            return indicator.Test1(Input);
        }

        public Indicators.Test1 Test1(ISeries<double> input)
        {
            return indicator.Test1(input);
        }
    }
}

#endregion
